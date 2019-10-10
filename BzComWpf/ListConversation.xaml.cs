using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy AdressBookPage.xaml
    /// </summary>
    public partial class ListConversation : Page
    {
        int i = 0;
        int[] numbers;
        private int myNumber;
        public bool znaleziony;
        private TrafficController trafficController = TrafficController.TrafficControllerInstance;
        public ChatMessage messageForm;
        private List<ChatPage> openedConnections;
        private List<ConversationPage> conversationConnections;
        ListView lista;
        bool checkUpdate = false;
        int[] numers = { 111, 112 };

        public ListConversation(ChatMessage _messageForm, List<ChatPage> _openedConnections, List<ConversationPage> _conversationConnections, ListView listView)
        {
            InitializeComponent();
            messageForm = _messageForm;
            openedConnections = _openedConnections;
            conversationConnections = _conversationConnections;
            lista = listView;
            trafficController.OnMessageReceived += TrafficController_OnMessageReceived;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += timer_Tick;
            timer.Start();

            //SetIntervalTimer(CheckUpdate(checkUpdate), 10000);
        }

        public void SetConversationBook(List<ConversationPage> conversations)
        {
            if (ListViewConversations.Dispatcher.Thread == Thread.CurrentThread)
            {
                foreach (var item in conversations)
                {
                    if (ListViewConversations.HasItems)
                    {
                        foreach (ConversationsItem listitem in ListViewConversations.Items)
                        {
                            if (listitem.UsersNumbers == item.Mynumber)
                            {

                            }
                            else {  }
                        }                
                    }
                    else { ListViewConversations.Items.Add(new ConversationsItem { idConversation = i, UsersNames = "Konwersacja", UsersNumbers = item.Mynumber }); }              
                }
            }

        }

        void timer_Tick(object sender , EventArgs a)
        {
            checkUpdateExist(checkUpdate);
        }

        public bool checkUpdateExist(bool checkUpdate)
        {
           if(checkUpdate == true)
            {           
                stworz_konw(numers, 111);
                return false;
               
            }
            else { return false; }
        }

        private void TrafficController_OnMessageReceived(TrafficController sender, Message msgNow)
        {
            //bool isConnectionOpened = false;
           
            string[] lines = msgNow.Text.Split(new Char[] { '?', '!' });
            int[] connection_numbers= new int[lines.Length - 1];
            for (int i = 0; i < connection_numbers.Length; i++)
            {
                connection_numbers[i] = Int32.Parse(lines[i + 1]);
            }
 
            if (lines[0].Equals("CONVERSATION"))
            {
                checkUpdate = true;

            }


            //Console.WriteLine("Pasuje");
            //ConversationPage page = new ConversationPage(numers, 111);
            //ChatPage page = new ChatPage(112, 111);
            //openedConnections.Add(page);
            //Console.WriteLine("Wszystko gra");
            //ConnectionItem connectionItem = new ConnectionItem { UserName = "Konwersacja", UserNumber = lines[1], IsConv = true };
            // stworz_konw(numers, numers[0]);
            //messageForm.ConnectionsListView.Items.Add(connectionItem);
            // messageForm.Initialize(conversationConnections, numers, numers[0]);
            //SetConversationBook(conversationConnections);
            //conversationConnections.Add(page);

            //conversationPage.TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text + " To bedzie conv", msgNow.DateTime);
        }

            private void Button_Create_Click(object sender, RoutedEventArgs e) {

            var Active = new ActiveUsersxaml(lista);
            Active.ShowDialog();

            numbers = Active.NumeryPolaczen;

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Numer uzytkownika " + numbers[i]);
            }

            znaleziony = false;
            if (trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate)
            {
                trafficController.SetState(State.OpenedGate);         
                if (!trafficController.protection_unavailable(numbers[0].ToString()))
                {

                    trafficController.SetState(State.OpenedGate);
                    messageForm.Show();

                    string users = "";
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        users += numbers[i].ToString();
                    }

                    ConnectionItem connectionItem = new ConnectionItem { UserName = "Konwersacja", UserNumber = users, IsConv = true };

                    if (messageForm.ConnectionsListView.HasItems == true) //Sprawdz czy lista posiada itemy jesli nie to dodaj
                    {
                        foreach (ConnectionItem item in messageForm.ConnectionsListView.Items)
                        {
                            if (item.UserName.Equals("Konwersacja"))
                            {
                                znaleziony = true;
                            }
                        }
                        if (znaleziony == true)                          //Jesli lista posiada juz ten item 
                        {
                            Console.WriteLine("Połączenie juz istnieje");
                        }
                        else
                        {
                            messageForm.ConnectionsListView.Items.Add(connectionItem);
                            messageForm.Initialize(conversationConnections, numbers, myNumber);
                            SetConversationBook(conversationConnections);
                        }
                    }
                    else
                    {
                        messageForm.ConnectionsListView.Items.Add(connectionItem);
                        messageForm.Initialize(conversationConnections, numbers, myNumber);
                        SetConversationBook(conversationConnections);
                    }
                }
            }
            else
                MessageBox.Show("Najpierw musisz ustanowić połączenie!", "Warning");

        }

        public void stworz_konw(int[] _number, int my_number)
        {
                znaleziony = false;
                checkUpdate = false;
                //messageForm.ConnectionsListView.Items.Add(new ConnectionItem { UserName = "test", UserNumber = "test" });
                if (trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate)
                {
                    //MyItem selectedItem = (MyItem)ListViewAddressBook.SelectedItems[0];
                    //currentNumber = trafficController.FindNumber(selectedItem.UserName);
                    trafficController.SetState(State.OpenedGate);


                    if (!trafficController.protection_unavailable(_number[0].ToString()))
                    {

                        trafficController.SetState(State.OpenedGate);
                        messageForm.Show();

                        string users = "";
                        for (int i = 0; i < _number.Length; i++)
                        {
                            users += _number[i].ToString();
                        }

                        ConnectionItem connectionItem = new ConnectionItem { UserName = "Konwersacja", UserNumber = users, IsConv = true };

                        if (messageForm.ConnectionsListView.HasItems == true) //Sprawdz czy lista posiada itemy jesli nie to dodaj
                        {
                            foreach (ConnectionItem item in messageForm.ConnectionsListView.Items)
                            {
                                if (item.UserName.Equals("Konwersacja"))
                                {
                                    znaleziony = true;
                                }
                            }
                            if (znaleziony == true)                          //Jesli lista posiada juz ten item 
                            {
                                Console.WriteLine("Połączenie juz istnieje");
                            }
                            else
                            {
                               
                                messageForm.ConnectionsListView.Items.Add(connectionItem);
                                messageForm.Initialize(conversationConnections, _number, my_number);

                            }
                        }
                        else
                        {
                            messageForm.ConnectionsListView.Items.Add(connectionItem);
                            messageForm.Initialize(conversationConnections, _number, my_number);   
                            SetConversationBook(conversationConnections);
                        }
                    }
                }
            }
     


        private void ListViewAddressBook_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected = lista.SelectedItem;
         
            stworz_konw(numers,111);
        }
    }
}

public class ConversationsItem
{
    public int idConversation { get; set; }
    public string UsersNames { get; set; }
    public int UsersNumbers { get; set; }
}
