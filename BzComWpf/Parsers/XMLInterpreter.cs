using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BzCOMWpf
{
    public class XMLInterpreter
    {
        public List<User> UserInfo = new List<User>();

        private Connection connection;

        public string Error { get; set; }

        private Logger logger = new Logger();

        public XMLInterpreter(Connection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Funkcja zwraca stosowną odpowiedź na polecenie zalogowania
        /// </summary>
        /// <returns></returns>
        public string LogIn(XCTIP packet)
        {
            if (!LogError(packet))
                return CurrentUserInfo();
            return null;
        }



        /// <summary>
        /// Funkcja zwraca informacje o zalogowanym użytkowniku
        /// </summary>
        /// <returns></returns>
        public string CurrentUserInfo()
        {
            string answer = null;
            lock (TrafficController.asyncData)
            {
                for (int i = 0; i < TrafficController.asyncData.Count;)
                {
                    var packet = TrafficController.asyncData[i];
                    if (packet.LogItems != null && packet.LogItems[0].LogInfo_ANS != null)
                    {
                        answer = "Witaj! Twój numer telefonu to: " + packet.LogItems[0].LogInfo_ANS[0].Number;
                        TrafficController.asyncData.RemoveAt(i);
                    }
                    else
                        i++;
                }
            }
            return answer;
        }

        public void GetBook()
        {
            if (connection.State == State.LoggedIn)
            {
                lock (TrafficController.asyncData)
                {
                    for (int i = 0; i < TrafficController.asyncData.Count;)
                    {
                        var packet = TrafficController.asyncData[i];
                        if (packet.SyncItems == null || packet.SyncItems[0].Records_ANS == null)
                        {
                            i++;
                            continue;
                        }
                        foreach (var row in packet.SyncItems[0].Records_ANS[0].Row)
                        {
                            User user = new User();
                            if (row.Contact != null && row.Contact[0].Name != null)
                            {
                                user.UserId = row.Contact[0].IdExtNo;
                                user.UserName = row.Contact[0].Name;
                                user.ContactId = row.Contact[0].ContactId;
                                /// tutaj foreach po phone i pola phone number i phone desc jako tablica słowników, tuple czy cokolwiek
                                if (row.Contact[0].Phone != null)
                                {
                                    user.PhoneNumber = row.Contact[0].Phone[0].Number;
                                    user.PhoneDesc = row.Contact[0].Phone[0].Comment;
                                }

                                user.UserNumber = row.Contact[0].ExtNo;
                                UserInfo.Add(user);
                            }
                        }
                        TrafficController.asyncData.RemoveAt(i);
                    }
                }
            }
            else
            {
                Error = "Najpierw musisz ustanowić połączenie z serwerem i zalogować się";
                logger.Debug($"Error:\n{Error}\n");
            }
        }

        /// <summary>
        /// Pobiera wszystkie statusy - metoda startowa
        /// </summary>
        /// <returns> </returns>
        public List<User> GetStatus()
        {
            List<User> users = new List<User>();
            lock (TrafficController.asyncData)
            {
                for (int i = 0; i < TrafficController.asyncData.Count;)
                {
                    var packet = TrafficController.asyncData[i];
                    if (packet.StatusItems != null && packet.StatusItems[0].Refresh_EV != null)
                    {
                        User user = new User
                        {
                            UserId = packet.StatusItems[0].Refresh_EV[0].Id
                        };
                        foreach (var el in UserInfo)
                        {
                            if (el.UserId == user.UserId)
                            {
                                user.UserName = el.UserName;
                                user.UserNumber = el.UserNumber;
                            }
                        }
                        if (packet.StatusItems[0].Refresh_EV[0].AppState != null)
                            user.UserState = (Status)Enum.Parse(typeof(Status), packet.StatusItems[0].Refresh_EV[0].AppState);
                        else
                            user.UserState = Status.UNAVAILABLE;
                        if (packet.StatusItems[0].Refresh_EV[0].AppInfo != null)
                            user.UserDesc = packet.StatusItems[0].Refresh_EV[0].AppInfo;
                        users.Add(user);
                        TrafficController.asyncData.RemoveAt(i);
                    }
                    else
                        i++;
                }

            }
            UserInfo = users;
            return users;
        }


        /// <summary>
        /// Pobiera aktualizacje statusów
        /// </summary>
        /// <returns></returns>
        public List<User> GetChangedStatus()
        {
            List<User> users = new List<User>();
            User user = new User();
            lock (TrafficController.asyncData)
            {

                for (int i = 0; i < TrafficController.asyncData.Count;)
                {
                    var packet = TrafficController.asyncData[i];

                    if (packet.StatusItems != null && packet.StatusItems[0].Change_EV != null)
                    {
                        user.UserId = packet.StatusItems[0].Change_EV[0].Id;
                        foreach (var el in UserInfo)
                        {
                            if (el.UserId == user.UserId)
                            {
                                user.UserName = el.UserName;
                                user.UserState = el.UserState;
                                if (packet.StatusItems[0].Change_EV[0].AppState != null)
                                {
                                    user.UserState = (Status)Enum.Parse(typeof(Status), packet.StatusItems[0].Change_EV[0].AppState);
                                    packet.StatusItems[0].Change_EV[0].AppState = null;
                                    el.UserState = user.UserState;
                                }

                                if (packet.StatusItems[0].Change_EV[0].AppInfo != null)
                                {
                                    user.UserDesc = packet.StatusItems[0].Change_EV[0].AppInfo;
                                    packet.StatusItems[0].Change_EV[0].AppInfo = null;
                                }
                            }
                        }
                        users.Add(user);
                        TrafficController.asyncData.RemoveAt(i);
                    }
                    else
                        i++;
                }
            }
            return users;
        }

        public List<Message> GetMessageRecords_EV(List<XCTIP> packets)
        {
            Message message = new Message();
            List<Message> messages = new List<Message>();
            for (int i = 0; i < TrafficController.asyncData.Count;)
            {
                var packet = TrafficController.asyncData[i];
                if (packet.SyncItems != null && packet.SyncItems[0].Records_EV != null && packet.SyncItems[0].Records_EV[0].Row != null)
                {
                    foreach (var item in packet.SyncItems[0].Records_EV[0].Row)
                    {
                        message.DateTime = Convert.ToDateTime(item.HistoryMsg[0].Date);
                        message.Number = Convert.ToInt32(item.HistoryMsg[0].Number);
                        message.Text = item.HistoryMsg[0].Text;
                        messages.Add(message);
                    }
                    TrafficController.asyncData.RemoveAt(i);
                }
                else
                    i++;
            }
            return messages;
        }

        public List<Message> GetMessageRecords_ANS()
        {

            List<Message> messages = new List<Message>();
            lock (TrafficController.asyncData)
            {
                for (int i = 0; i < TrafficController.asyncData.Count;)
                {
                    var packet = TrafficController.asyncData[i];
                    if (packet.SyncItems == null || packet.SyncItems[0].Records_ANS == null || packet.SyncItems[0].Records_ANS[0].Row == null)
                    {
                        i++;
                        continue;
                    }
                    foreach (var item in packet.SyncItems[0].Records_ANS[0].Row)
                    {
                        Message message = new Message();
                        if (item.HistoryMsg == null)
                            continue;

                        message.DateTime = Convert.ToDateTime(item.HistoryMsg[0].Date);
                        message.Number = Convert.ToInt32(item.HistoryMsg[0].Number);
                        message.Text = item.HistoryMsg[0].Text;
                        messages.Add(message);
                        TrafficController.asyncData.RemoveAt(i);
                    }
                }
            }
            return messages;
        }

        public Message GetSMSReceive_EV()
        {
            Message message = new Message();
            lock (TrafficController.asyncData)
            {
                for (int i = 0; i < TrafficController.asyncData.Count;)
                {
                    var packet = TrafficController.asyncData[i];
                    if (packet.SMSItems == null || packet.SMSItems[0].Receive_EV == null)
                    {
                        i++;
                        continue;
                    }

                    message.DateTime = Convert.ToDateTime(packet.SMSItems[0].Receive_EV[0].RecvTime);
                    message.Number = Convert.ToInt32(packet.SMSItems[0].Receive_EV[0].Number);
                    message.Text = packet.SMSItems[0].Receive_EV[0].Text;
                    packet.SMSItems[0].Receive_EV = null;
                    TrafficController.asyncData.Remove(packet);
                }
            }
            return message;
        }


        public bool IsSyncChange_EV(List<XCTIP> packets)
        {
            foreach (var packet in packets)
            {
                if (packet.SyncItems == null || packet.SyncItems[0].Change_EV == null)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Error na module SMS - wywoływany zawsze po wysłaniu ramki, bo zawsze otrzymujemy wiadomość i zawsze może ona zawierać error
        /// </summary>
        /// <returns></returns>
        public bool SMSError(XCTIP packet)
        {
            if (packet == null || packet.SMSItems == null || packet.SMSItems[0].Answer == null)
                return true;

            if (packet.SMSItems[0].Answer[0].Error == null)
            {
                return false;
            }
            else
            {
                logger.Debug(packet.SMSItems[0].Answer[0].Error);
                return true;
            }
        }

        /// <summary>
        /// Error na module Sync - wywoływany zawsze po wysłaniu ramki, bo zawsze otrzymujemy wiadomość i zawsze może ona zawierać error
        /// </summary>
        /// <returns></returns>
        public bool SyncError(XCTIP packet)
        {
            if (packet == null || packet.SyncItems == null || packet.SyncItems[0].Answer == null)
                return true;

            if (packet.SyncItems[0].Answer[0].Error == null)
                return false;
            else
            {
                logger.Debug(packet.SyncItems[0].Answer[0].Error);
                return true;
            }
        }

        /// <summary>
        /// Error na module Log - wywoływany zawsze po wysłaniu ramki, bo zawsze otrzymujemy wiadomość i zawsze może ona zawierać error
        /// </summary>
        /// <returns></returns>
        public bool LogError(XCTIP packet)
        {
            if (packet == null || packet.LogItems == null || packet.LogItems[0].Answer == null)
                return true;

            if (packet.LogItems[0].Answer[0].Error == null)
                return false;
            else
            {
                logger.Debug(packet.LogItems[0].Answer[0].Error);
                return true;
            }
        }

        /// <summary>
        /// Error na module Status - wywoływany zawsze po wysłaniu ramki, bo zawsze otrzymujemy wiadomość i zawsze może ona zawierać error
        /// </summary>
        /// <returns></returns>
        public bool StatusError(XCTIP packet)
        {
            if (packet == null || packet.StatusItems == null || packet.StatusItems[0].Answer == null)
            {
                logger.Debug("Format pakietu jest niezgodny");
                return true;
            }

            if (packet.StatusItems[0].Answer[0].Error == null)
                return false;
            else
            {
                logger.Debug($"Error: {packet.StatusItems[0].Answer[0].Error}");
                return true;
            }
        }

        public async Task<List<XCTIP>> ParsePacket()
        {
            List<XCTIP> packets = new List<XCTIP>();
            foreach (var item in await connection.GetFramesList())
            {
                var packet = ServiceXML.GenericDeserialize<XCTIP>(item);
                packets.Add(packet);
            }
            return packets;
        }
    }
}
