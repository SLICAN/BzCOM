using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Notifications.Wpf;
namespace BzCOMWpf
{
    public sealed class TrafficController
    {
        private static TrafficController TCInstance = null;
        private static readonly object PadLock = new object();

        private Connection connection = new Connection();

        private XMLCreator xmlCreator = new XMLCreator();

        private XMLInterpreter xmlInterpreter;

        private Logger logger = new Logger();

        private Thread listener;

        public bool wrongLogin = false;

        private List<Message> allMessages; //Wszystkie widomości wysłane i odebrane po włączeniu aplikacji

        public delegate void OnMessageReceivedDelegate(TrafficController sender, Message msg);
        public event OnMessageReceivedDelegate OnMessageReceived;

        public delegate void OnUpdateStatusDelegate(TrafficController sender, List<User> users);
        public event OnUpdateStatusDelegate OnUpdateStatus;

        public delegate void OnAddressBookGetDelegate(TrafficController sender, List<User> users);
        public event OnAddressBookGetDelegate OnAddressBookGet;

        public delegate void OnLoggedInDelegate(TrafficController sender, string info);
        public event OnLoggedInDelegate OnLoggedIn;

        public delegate void OnDeadConnectionDelegate(TrafficController sender);
        public event OnDeadConnectionDelegate OnDeadConnection;

        public delegate void OnSuccessDelegate(TrafficController sender, bool error);
        public event OnSuccessDelegate OnSuccessMessageSend;


        private TrafficController()
        {
            listener = new Thread(Start);
            listener.Start();
            xmlInterpreter = new XMLInterpreter(connection);

            allMessages = new List<Message>();
        }

        public static TrafficController TrafficControllerInstance
        {
            get
            {
                lock (PadLock)
                {
                    if (TCInstance == null)
                    {
                        TCInstance = new TrafficController();
                    }
                    return TCInstance;
                }
            }
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
            {
                wrongLogin = true;
                connection.State = State.Connected;
                OnLoggedIn.Invoke(this, "Wystąpił błąd w trakcie logowania. Spróbuj ponownie.");
            }
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
            List<User> temp = xmlInterpreter.GetStatus();
            OnAddressBookGet?.Invoke(this, temp); // zwraca ramki z obecnymi statusami do listy obiektów
            //}
        }

        public async void SetDescription(string status, string info)
        {
            try
            {
                await connection.SendingPacket(xmlCreator.StatusUpdate_REQ(null, info, out string rid));
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
            //OnDeadConnection.Invoke(this);
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
            OnSuccessMessageSend.Invoke(this, xmlInterpreter.SMSError(GetResponse(rid)));

            Message message = new Message();
            message.Text = text;
            message.Number = Int32.Parse(number);
            message.DateTime = DateTime.Now;
            message.IsMine = true;
            message.Buffer = dontBuffer;
            allMessages.Add(message); //Zapisywanie wysłanej wiadomosci
            //}
        }

        public void GetMessage()
        {
            Message message = xmlInterpreter.GetSMSReceive_EV();
            if (message.Text == null)
                return;
            OnMessageReceived?.Invoke(this, message);
            allMessages.Add(message);
            Toast(message);//Zapisywanie otrzymanej wiadomosci
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

        public string GetDescriptionByNumber(string number)
        {
            string description = "";
            xmlInterpreter.UserInfo.ForEach(item =>
            {
                if (number == item.UserNumber)
                    description = item.UserDesc;
            });
            return description;
        }

        public bool protection_unavailable(string name)
        {
            string currentNumber = "";
            bool test = false;
            xmlInterpreter.UserInfo.ForEach(it =>
            {
                if (it.UserName == name)
                {
                    currentNumber = it.UserNumber;
                    if (it.UserState == Status.UNAVAILABLE)
                        test = true;
                }

            });
            return test;
        }

        public List<Message> GetMessagesByNumber(int nr) //Wiadomosci dla konkretnej konwersacji, szukane po id rozmowcy
        {
            List<Message> messages = new List<Message>();
            foreach (Message message in allMessages)
                if (nr == message.Number)
                    messages.Add(message);      
            return messages;
        }

        public void Toast(Message message)
        {
            var notificationManager = new NotificationManager();
            string m = "";
            if (message.Text.Contains("CONVERSATION"))
            {
                return;
            }
            if (message.Text.Contains("xxxcoco")){
                string x = "xxxcoco";
                m = message.Text.Replace(x,string.Empty);
            }
            else { m = message.Text; }
            notificationManager.Show(new NotificationContent
            {
                Title = "Wiadomość od użytkownika:" + FindName(message.Number.ToString()),        
                Message = m,         
                Type = NotificationType.Information
            });
        }

    }
}
