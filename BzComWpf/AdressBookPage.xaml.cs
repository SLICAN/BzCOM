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

namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy AdressBookPage.xaml
    /// </summary>
    public partial class AdressBookPage : Page
    {
        private int myNumber;
        private string currentNumber;
        private string descrption;
        int[] numbers;
        //private ListViewItem item;
        //ImageSource MyImage= new BitmapImage(new Uri("", UriKind.Relative));
        string url1 = "/Images/GrafikiMenu/avatar_placeholder.png";
        private List<ChatPage> openedConnections;
        private List<ConversationPage> conversationConnections;
        public ChatMessage messageForm;
        delegate void SetUsersCallBack(List<User> users);
        private ConversationPage page;
        private TrafficController trafficController = TrafficController.TrafficControllerInstance;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public bool znaleziony;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public AdressBookPage(ChatMessage _messageForm ,List<ChatPage> _openedConnections, List<ConversationPage> _conversationConnections)
        {
            InitializeComponent();
            trafficController.OnUpdateStatus += TrafficController_OnUpdateStatus;
            trafficController.OnAddressBookGet += TrafficController_OnAddressBookGet;
            trafficController.OnDeadConnection += TrafficController_OnDeadConnection;
            trafficController.OnMessageReceived += TrafficController_OnMessageReceived;
            messageForm = _messageForm;

           
            openedConnections = _openedConnections;
            conversationConnections = _conversationConnections;
        }


        private void TrafficController_OnMessageReceived(TrafficController sender, Message msgNow)
        {
            bool isConnectionOpened = false;
            foreach (ChatPage messageForm in openedConnections)
                if (msgNow.Number == messageForm.nr) {
                    isConnectionOpened = true; }


        }


        private void TrafficController_OnAddressBookGet(TrafficController sender, List<User> users)
        {
            SetBook(users);
            trafficController.RegisterToModules();
            if (trafficController.GetState() == State.LoggedIn)
            {
                 //ChangeComboBox(Status.AVAILABLE.ToString());
            }
            //this.Show();
        }

        private void TrafficController_OnDeadConnection(TrafficController sender)
        {
            MessageBox.Show("Brak odpowiedzi z serwera.\nSprawdź czy masz połączenie z Internetem lub zgłoś awarię do administratora.\nAplikacja zostanie zamknięta.", "Error", MessageBoxButton.OK);
            Application.Current.Shutdown();
        }


        /// <summary>
        /// Edytuj książkę i ustaw odpowiedni kolor - otrzymano zmianę statusu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="users"></param>
        private void TrafficController_OnUpdateStatus(TrafficController sender, List<User> users)
        {
            EditBook(users);
        }

        /// <summary>
        /// Ustaw książkę, ukryj pierszą kolumnę 
        /// (będzie ona służyła tylko do rozpoznawania statusów w kodzie, 
        /// w interfejsie status będzie rozróżniany poprzez kolory)
        /// </summary>
        /// <param name="bookList"></param>
        public void SetBook(List<User> bookList)
        {

            var path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var img = new BitmapImage(new Uri("/Images/GrafikiMenu/avatar_placeholder.png", UriKind.Relative));
            if (ListViewAddressBook.Dispatcher.Thread == Thread.CurrentThread)
            {
                bookList = bookList.OrderBy(x => x.UserState).ToList();
                foreach (var item in bookList)
                {
                    ListViewAddressBook.Items.Add(new MyItem { UserState = item.UserState.ToString(), UserName = item.UserName, UserDesc = item.UserDesc, Image = img });
                    //Utworz_pliki_json(item);
                    //Wypelnij_pliki_json(item);
                }
            }
            else
            {
                SetUsersCallBack f = new SetUsersCallBack(SetBook);
                Dispatcher.Invoke(f, new object[] { bookList });
            }
        }
        /// <summary>
        /// Edytuj książkę po otrzymaniu zmian, sortuj kontakty od dostępnego
        /// </summary>
        /// <param name="bookList"></param>
        private void EditBook(List<User> bookList)
        {

            if (ListViewAddressBook.Dispatcher.Thread == Thread.CurrentThread)
            {
                foreach (var user_item in bookList)
                {
                    foreach (MyItem item in ListViewAddressBook.Items)
                    {
                        if (item.UserName == user_item.UserName)
                        {
                            if (user_item.UserState != Status.UNKNOWN)
                            {
                                item.UserState = user_item.UserState.ToString();
                                Console.WriteLine(item.UserState);
                                //view.SortDescriptions.Add(new SortDescription("UserState", ListSortDirection.Ascending));
                            }
                            if (user_item.UserDesc != null && user_item.UserDesc != "")
                            {
                                item.UserDesc = user_item.UserDesc;
                                Console.Write(item.UserDesc);
                            }
                        }
                    }
                }
                ListViewAddressBook.Items.SortDescriptions.Add(new SortDescription("UserState", ListSortDirection.Ascending));
                ListViewAddressBook.Items.Refresh();
            }

            else
            {
                SetUsersCallBack f = new SetUsersCallBack(EditBook);
                Dispatcher.Invoke(f, new object[] { bookList });
            }
        }

        /// <summary>
        /// Podwójne kliknięcie na danym kontakcie otwiera z nim rozmowę, numer telefonu zostaje zapisany jako bieżący
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewAddressBook_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            znaleziony = false;
            //messageForm.ConnectionsListView.Items.Add(new ConnectionItem { UserName = "test", UserNumber = "test" });
            if (trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate)
            {
                MyItem selectedItem = (MyItem)ListViewAddressBook.SelectedItems[0];
                currentNumber = trafficController.FindNumber(selectedItem.UserName);
                trafficController.SetState(State.OpenedGate);


                if (!trafficController.protection_unavailable(selectedItem.UserName))
                {

                    trafficController.SetState(State.OpenedGate);
                    messageForm.Show();

                    ConnectionItem connectionItem = new ConnectionItem { UserName = selectedItem.UserName, UserNumber = currentNumber, IsConv = false };

                    if (messageForm.ConnectionsListView.HasItems == true) //Sprawdz czy lista posiada itemy jesli nie to dodaj
                    {
                        foreach (ConnectionItem item in messageForm.ConnectionsListView.Items)
                        {
                            if (item.UserName == selectedItem.UserName)
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
                            messageForm.Initialize(openedConnections, Int32.Parse(currentNumber), myNumber);
                        }
                    }
                    else
                    {
                        messageForm.ConnectionsListView.Items.Add(connectionItem);
                        messageForm.Initialize(openedConnections, Int32.Parse(currentNumber), myNumber);
                    }
                }
            }
            else
                MessageBox.Show("Najpierw musisz ustanowić połączenie!", "Warning");


        } } }
    

public class MyItem
{
    public string UserState { get; set; }
    public string UserName { get; set; }
    public string UserDesc { get; set; }
    public ImageSource Image { get; set; }

}




