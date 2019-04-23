using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;
using System.Web.Script.Serialization;

namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy AddressBookForm.xaml
    /// </summary>
    public partial class AddressBookForm : Window
    {
        private string currentNumber;
        private string descrption;
        //private ListViewItem item;

        private List<ChatPage> openedConnections;
        public ChatMessage messageForm;
        delegate void SetUsersCallBack(List<User> users);

        private TrafficController trafficController = TrafficController.TrafficControllerInstance;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public bool znaleziony;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        

        public AddressBookForm()
        {
            InitializeComponent();
            trafficController.OnUpdateStatus += TrafficController_OnUpdateStatus;
            trafficController.OnAddressBookGet += TrafficController_OnAddressBookGet;
            trafficController.OnDeadConnection += TrafficController_OnDeadConnection;
            trafficController.OnMessageReceived += TrafficController_OnMessageReceived;
            messageForm = new ChatMessage();
       
            messageForm.Hide();
            openedConnections = new List<ChatPage>();
              
        }

        #region TrafficController
        private void TrafficController_OnMessageReceived(TrafficController sender, Message msgNow)
        {
            bool isConnectionOpened = false;
            foreach (ChatPage messageForm in openedConnections)
                if (msgNow.Number == messageForm.nr)
                    isConnectionOpened = true;

            
            if (!isConnectionOpened)
            {

                //PopUpTimer.Enabled = true;
                //popUpForm.labelWho.Text = trafficController.FindName(msgNow.Number.ToString());
                //popUpForm.labelWhat.Text = msgNow.Text;
                //popUpForm.ShowDialog();
            }
        }


        private void TrafficController_OnAddressBookGet(TrafficController sender, List<User> users)
        {

            SetBook(users);
            /// Manages the initial import of statuses and description
            //SetColor(trafficController.SetColor(users));
            /// Register sms module
            trafficController.RegisterToModules();
            if (trafficController.GetState() == State.LoggedIn)
            {
                ChangeComboBox(Status.AVAILABLE.ToString());
            }
            this.Show();
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

        #endregion

        #region Ksiazka
        /// <summary>
        /// Ustaw książkę, ukryj pierszą kolumnę 
        /// (będzie ona służyła tylko do rozpoznawania statusów w kodzie, 
        /// w interfejsie status będzie rozróżniany poprzez kolory)
        /// </summary>
        /// <param name="bookList"></param>
        public void SetBook(List<User> bookList)
        {
             if (ListViewAddressBook.Dispatcher.Thread == Thread.CurrentThread)
            {
                foreach (var item in bookList)
                {
                    ListViewAddressBook.Items.Add(new MyItem { UserState = item.UserState.ToString(), UserName = item.UserName, UserDesc = item.UserDesc});
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
                        foreach(MyItem item in ListViewAddressBook.Items)
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

                    ConnectionItem connectionItem = new ConnectionItem { UserName = selectedItem.UserName, UserNumber = currentNumber };

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
                            messageForm.Initialize(openedConnections);
                        }
                    }
                    else
                    {
                        messageForm.ConnectionsListView.Items.Add(connectionItem);
                        messageForm.Initialize(openedConnections);
                    }
                    }
                }
                else
                    MessageBox.Show("Najpierw musisz ustanowić połączenie!", "Warning");

            }
        #endregion

        #region ComboBoxStatus
        private void ComboBoxStatus_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(Status)))
            {
               if (item.ToString() != Status.UNKNOWN.ToString())

                    ComboBoxStatus.Items.Add(item);
            }
            ComboBoxStatus.SelectedItem = ComboBoxStatus.Items[0];
        }

        /// <summary>
        /// Wyślij informacje o zmianie statusu na serwer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate)
                trafficController.SetStatus((Status)Enum.Parse(typeof(Status), ComboBoxStatus.SelectedItem.ToString()));
            Console.WriteLine(ComboBoxStatus.Text);
        }

        /// <summary>
        /// Zmień status w ComboBox'ie
        /// </summary>
        /// <param name="text"></param>
        private void ChangeComboBox(string text)
        {
            ComboBoxStatus.Text = text;
        }

        #endregion

        #region Opis
        /// <summary>
        /// Wyślij chęć zmiany opisu na serwer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if ((trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate) && e.Key == Key.Enter)
                trafficController.SetDescription(ComboBoxStatus.Text, TextBoxDescription.Text);
        }
        /// <summary>
        /// Symuluje hint'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDescription_Leave(object sender, EventArgs e)
        {
            if (TextBoxDescription.Text == "")
            {
                TextBoxDescription.Text = "Wpisz i naciśnij enter";
                // TextBoxDescription.ForeColor = Color.Silver;
            }
        }

        /// <summary>
        /// Symuluje hint'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDescription_Enter(object sender, EventArgs e)
        {
            if (TextBoxDescription.Text == "Wpisz i naciśnij enter")
            {
                TextBoxDescription.Text = "";

            }
        }
        #endregion





        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        /*  private void PopUpTimer_Tick(object sender, EventArgs e)
          {
              // Set the caption to the current time.  
              Console.WriteLine("Tick");
              //popUpForm.Hide();
              PopUpTimer.Enabled = false;
          }*/

        //private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        ReleaseCapture();
        //        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        //    }
        //}

        private void buttonExitMain_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            trafficController.CloseConnection();
        }

        private void MessageBoxButtons_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string login;
            string jsonRead;
            if (File.Exists(path2 + "BzCOMfile.json"))
            {
                jsonRead = File.ReadAllText(path2 + "BzCOMfile.json");
                dynamic resultRead = new JavaScriptSerializer().Deserialize<dynamic>(jsonRead);
                login = resultRead["login"];
                descrption = trafficController.GetDescriptionByNumber(login);
                TextBoxDescription.Text = descrption;
            }
            else { return; }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void GridGlowny_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void TextBoxDescription_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //TextBoxDescription.Background = Brushes.Aqua;
            //    TextBoxDescription.Background = new SolidColorBrush(Color.FromRgb(21, 21, 21));
            // TextBoxDescription.BorderBrush = Brushes.Red;
            TextBoxDescription.Foreground = Brushes.White;

            if (TextBoxDescription.Text == "Wpisz opis i naciśnij enter")
            {

                TextBoxDescription.Text = "";
               

            }
        }

        private void TextBoxDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
           // TextBoxDescription.Foreground = Brushes.Aqua;
        }

        private void TextBoxDescription_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void TextBoxDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDescription.Foreground = Brushes.Silver;
            if (TextBoxDescription.Text == "")
            {
                TextBoxDescription.Text = "Wpisz opis i naciśnij enter";
                TextBoxDescription.Background = new SolidColorBrush(Color.FromRgb(13, 13, 13));
                // TextBoxDescription.ForeColor = Color.Silver;
            }
        }
    }



    public class MyItem
    {
        public string UserState { get; set; }
        public string UserName { get; set; }
        public string UserDesc { get; set; }
        public string UserNumber { get; set; }
           
    }
}

