using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ChatTest
{
    public class TrafficController
    {
        private Connection connection = new Connection();

        private XMLCreator xmlCreator = new XMLCreator();

        private XMLInterpreter xmlInterpreter;

        private Logger logger = new Logger();

        private Thread listener;

        public delegate void OnMessageReceivedDelegate(TrafficController sender, Message msg);
        public event OnMessageReceivedDelegate OnMessageReceived;

        public delegate void OnUpdateStatusDelegate(TrafficController sender, List<User> users);
        public event OnUpdateStatusDelegate OnUpdateStatus;
        public event OnUpdateStatusDelegate OnAddressBookGet;

        public delegate void OnLoggedInDelegate(TrafficController sender, string info);
        public event OnLoggedInDelegate OnLoggedIn;

        public delegate void OnDeadConnectionDelegate(TrafficController sender);
        public event OnDeadConnectionDelegate OnSetConnection;
        public event OnDeadConnectionDelegate OnDeadConnection;

        public delegate void OnSuccessDelegate(TrafficController sender, bool error);
        public event OnSuccessDelegate OnSuccess;

        public TrafficController()
        {
            listener = new Thread(Start);
            listener.Start();
            xmlInterpreter = new XMLInterpreter(connection);
        }

        public async void Start()
        {
            if (connection.SetConnection())
            {
                //if (GetState() == State.LoggedIn)
                //OnSetConnection.Invoke(this);
                while (true)
                {
                    try
                    {
                        {
                            /// odpowiada za ciągłe pobieranie danych i zapisywanie ich do określonych zmiennych
                            await GetData();

                            /// sprawdza czy nie zmienił się status, któregoś z użytkowników 
                            GetChangedStatus();

                            /// sprawdza czy nie przyszła żadna nowa wiadomość
                            GetMessage();
                        }
                    }
                    catch (Exception e)
                    {
                        logger.Debug($"Exception: {e}");
                    }
                    Thread.Sleep(500);
                }
            }
            else
            {
                Start();
                Thread.Sleep(3000);
            }
        }

        public void CloseConnection()
        {
            listener.Abort();
            connection.CloseConnection();
        }

        public State GetState()
        {
            return connection.State;
        }

        public void SetState(State state)
        {
            connection.State = state;
        }

        public void SetIPAddress(IPAddress ip)
        {
            connection.AddressIP = ip;
        }

        public void SetPort(int port)
        {
            connection.Port = port;
        }

        public async Task LogIn(string login, string pass)
        {
            //lock (connection)
            //{
            await connection.SendingPacket(xmlCreator.MakeLog(login, pass, out string rid));
            XCTIP packet = GetResponse(rid);
            var temp = xmlInterpreter.LogIn(packet);
            if (temp != null)
            {
                SetStatus(Status.AVAILABLE);
                connection.State = State.LoggedIn;
                OnLoggedIn.Invoke(this, $"{temp}");
            }
            else
                OnLoggedIn.Invoke(this, "Wystąpił błąd w trakcie logowania. Spróbuj ponownie.");
            //}
        }

        public async Task LogOut()
        {
            //lock (connection)
            //{
            await connection.SendingPacket(xmlCreator.Logout());
            //}
        }

        public async Task GetAddressBook()
        {
            //lock (connection)
            //{
            await connection.SendingPacket(xmlCreator.Sync_REQ("Book", out string rid));
            if (xmlInterpreter.SyncError(GetResponse(rid)))
                return;

            xmlInterpreter.GetBook();
            //}
        }

        public async void SetStatus(Status status)
        {
            try
            {
                await connection.SendingPacket(xmlCreator.StatusUpdate_REQ(status.ToString(), null, out string rid));
                if (xmlInterpreter.StatusError(GetResponse(rid)))
                    OnDeadConnection.Invoke(this);
            }
            catch
            {
                OnDeadConnection.Invoke(this);
            }
        }

        public async Task GetUsers()
        {
            //lock (connection)
            //{
            await GetAddressBook();
            await connection.SendingPacket(xmlCreator.StatusRegister_REQ(out string rid)); // zgłaszamy, że chcemy obserwować zmiany statusów
            if (xmlInterpreter.StatusError(GetResponse(rid))) return;

            OnAddressBookGet.Invoke(this, xmlInterpreter.GetStatus()); // zwraca ramki z obecnymi statusami do listy obiektów
            //}
        }

        public async void SetDescription(string status, string info)
        {
            try
            {
                await connection.SendingPacket(xmlCreator.StatusUpdate_REQ(status, info, out string rid));
                xmlInterpreter.StatusError(GetResponse(rid));
            }
            catch
            {
                OnDeadConnection.Invoke(this);
            }
        }

        public void GetChangedStatus()
        {
            List<User> users = xmlInterpreter.GetChangedStatus();
            if (users.Count == 0)
                return;
            OnUpdateStatus?.Invoke(this, users);
        }

        public List<User> SetColor(List<User> listToSet)
        {
            List<User> users = new List<User>();
            foreach (var user in listToSet)
            {
                if (user.UserState == Status.AVAILABLE)
                {
                    user.StateColor = Color.LightGreen;
                }
                if (user.UserState == Status.BRB)
                {
                    user.StateColor = Color.LightSkyBlue;
                }
                else if (user.UserState == Status.BUSY)
                {
                    user.StateColor = Color.IndianRed;
                }
                else if (user.UserState == Status.UNAVAILABLE)
                {
                    user.StateColor = Color.LightGray;
                }
                users.Add(user);
            }

            return users;
        }

        public static ConcurrentDictionary<string, XCTIP> responses = new ConcurrentDictionary<string, XCTIP>();
        public static List<XCTIP> asyncData = new List<XCTIP>();

        public XCTIP GetResponse(string id, int timeoutMs = 10000)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds < timeoutMs)
            {
                if (responses.TryRemove(id, out XCTIP result))
                    return result;
            }
            OnDeadConnection.Invoke(this);
            return null;
        }

        public async Task RegisterToModules()
        {
            //lock (connection)
            //{
            await connection.SendingPacket(xmlCreator.SMSRegister_REQ(out string sid));
            xmlInterpreter.SMSError(GetResponse(sid));
            //connection.SendingPacket(xmlCreator.SyncRegister_REQ());
            await connection.SendingPacket(xmlCreator.SyncAutoChange_REQ("HistoryMsg", out string rid));
            xmlInterpreter.SyncError(GetResponse(rid));
            /// udało się zarejestrować do modułów
            //}
        }

        public async Task SMSSend(string number, string smsId, string text, string dontBuffer, string userData)
        {
            //lock (connection)
            //{
            await connection.SendingPacket(xmlCreator.SMSSend_REQ(number, smsId, text, dontBuffer, userData, out string rid));
            OnSuccess.Invoke(this, xmlInterpreter.SMSError(GetResponse(rid)));
            //}
        }

        public void GetMessage()
        {
            Message message = xmlInterpreter.GetSMSReceive_EV();
            if (message.Text == null)
                return;
            OnMessageReceived?.Invoke(this, message);
        }

        public List<Message> GetMessagesExtended(List<XCTIP> data)
        {
            List<Message> messages = xmlInterpreter.GetMessageRecords_EV(data);
            if (messages.Count == 0)
                return null;

            return messages;
        }

        public async Task<List<Message>> GetMessagesSimple(List<XCTIP> data)
        {
            //lock (connection)
            //{
            if (!xmlInterpreter.IsSyncChange_EV(data))
                return null;

            await connection.SendingPacket(xmlCreator.Sync_REQ("HistoryMsg", out string rid, "30"));

            if (xmlInterpreter.SyncError(GetResponse(rid)))
                return null;

            return xmlInterpreter.GetMessageRecords_ANS();
            //}
        }

        public async Task GetData()
        {
            var packets = await xmlInterpreter.ParsePacket();
            foreach (var packet in packets)
            {
                if (packet.LogItems?[0].Answer != null)
                    responses.TryAdd(packet.LogItems[0].Answer[0].CId, packet);
                else if (packet.SyncItems?[0].Answer != null)
                    responses.TryAdd(packet.SyncItems[0].Answer[0].CId, packet);
                else if (packet.StatusItems?[0].Answer != null)
                    responses.TryAdd(packet.StatusItems[0].Answer[0].CId, packet);
                else if (packet.SMSItems?[0].Answer != null)
                    responses.TryAdd(packet.SMSItems[0].Answer[0].CId, packet);
                else
                {
                    lock (asyncData)
                    {
                        asyncData.Add(packet);
                    }
                }
            }
        }

        public string FindName(string number)
        {
            string name = number;
            xmlInterpreter.UserInfo.ForEach(item =>
            {
                if (number == item.UserNumber)
                    name = item.UserName;
            });
            return name;
        }

        public string FindNumber(string name)
        {
            string currentNumber = "";
            xmlInterpreter.UserInfo.ForEach(item =>
            {
                if (item.UserName == name)
                    currentNumber = item.UserNumber;
            });
            return currentNumber;
        }
    }
}
