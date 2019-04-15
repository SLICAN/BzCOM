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

namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy AddressBookForm.xaml
    /// </summary>
    public partial class AddressBookForm : Window
    {
        private string currentNumber;

        private ListViewItem item;

        private List<ChatMessage> openedConnections;

        delegate void SetUsersCallBack(List<User> users);

        private TrafficController trafficController = TrafficController.TrafficControllerInstance;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

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

            foreach (var item in Enum.GetValues(typeof(Status)))
            {
                if (item.ToString() != Status.UNKNOWN.ToString())
                    ComboBoxStatus.Items.Add(item);
            }

        }

        private void TrafficController_OnMessageReceived(TrafficController sender, Message msgNow)
        {
            bool isConnectionOpened = false;
            foreach (ChatMessage messageForm in openedConnections)
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
        /// Zmień status w ComboBox'ie
        /// </summary>
        /// <param name="text"></param>
        private void ChangeComboBox(string text)
        {
            ComboBoxStatus.Text = text;
        }


        private void TextBoxDescription_MouseClick(object sender, MouseEventArgs e)
        {
            this.TextBoxDescription.Text = String.Empty;
        }

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
        /// <summary>
        /// Wyślij informacje o zmianie statusu na serwer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate)
                trafficController.SetStatus((Status)Enum.Parse(typeof(Status), ComboBoxStatus.Text));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            trafficController.CloseConnection();
        }
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
        /// Podwójne kliknięcie na danym kontakcie otwiera z nim rozmowę, numer telefonu zostaje zapisany jako bieżący
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewAddressBook_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate)
            {
                MyItem selectedItem = (MyItem)ListViewAddressBook.SelectedItems[0];
                currentNumber = trafficController.FindNumber(selectedItem.UserName);
                trafficController.SetState(State.OpenedGate);


                if (!trafficController.protection_unavailable(selectedItem.UserState))
                {
                    ChatMessage messageForm = new ChatMessage(Int32.Parse(currentNumber));
                    trafficController.SetState(State.OpenedGate);
                    messageForm.Show();
                    messageForm.Initialize(openedConnections);
                }

            }
            else
                MessageBox.Show("Najpierw musisz ustanowić połączenie!", "Warning");

        }
    }

    public class MyItem
    {
        public string UserState { get; set; }
        public string UserName { get; set; }
        public string UserDesc { get; set; }
           
    }
}

