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
using System.IO;
using System.Web.Script.Serialization;


namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy AddressBookForm.xaml
    /// </summary>
    public partial class AddressBookForm : Window
    {

        private int myNumber;
        private string currentNumber;
        private string descrption;
        int[] numbers;
        //private ListViewItem item;
        //ImageSource MyImage= new BitmapImage(new Uri("", UriKind.Relative));
        string url1 = "/Images/GrafikiMenu/avatar_placeholder.png";
        //private List<ChatPage> openedConnections;
        //private List<ConversationPage> conversationConnections;
        //public ChatMessage messageForm;
        delegate void SetUsersCallBack(List<User> users);
        private List<Page> pages = new List<Page>();
        private TrafficController trafficController = TrafficController.TrafficControllerInstance;
        private List<ChatPage> openedConnections;
        private List<ConversationPage> conversationConnections;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public bool znaleziony;
        public ChatMessage messageForm;
        ListConversation conversationList;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        public AddressBookForm()
        {
            InitializeComponent();
            messageForm = new ChatMessage();

            openedConnections = new List<ChatPage>();
            conversationConnections = new List<ConversationPage>();
            AdressBookPage adressBookPage = new AdressBookPage(messageForm, openedConnections, conversationConnections);
            conversationList = new ListConversation(messageForm, openedConnections, conversationConnections, adressBookPage.ListViewAddressBook);
            pages.Add(adressBookPage);
            pages.Add(conversationList);
            _mainFrame.Navigate(pages[0]);
            Console.WriteLine(pages.Count);



            Console.WriteLine(messageForm.Title);
            messageForm.Hide();

        }


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
            //Console.WriteLine(ComboBoxStatus.Text);
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
                myNumber = Int32.Parse(login);
            }
            else { return; }



        }



            private void ButtonExit_Click(object sender, RoutedEventArgs e)
            {
                Environment.Exit(0);
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

            public void Utworz_pliki_json(User user)
            {
            }


            private void MessageBoxButtons_Click_1(object sender, RoutedEventArgs e)
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".png";
                //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
                Nullable<bool> result = dlg.ShowDialog();


                // Get the selected file name and display in a TextBox 
                if (result == true)
                {
                    // Open document 

                    string filename = dlg.FileName;
                    var img = new BitmapImage(new Uri(filename, UriKind.Relative));
                    //MyImage = img;

                }
            }

            private void ButtonPicture_Click(object sender, RoutedEventArgs e)

            {

                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".png";
                // dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
                Nullable<bool> result = dlg.ShowDialog();


                // Get the selected file name and display in a TextBox 
                if (result == true)
                {
                    imgPhoto.ImageSource = new BitmapImage(new Uri(dlg.FileName));
                    // Open document 

                    string filename = dlg.FileName;

                    //MyImage = img;

                }
            }

            private void ButtonAdd_Click(object sender, RoutedEventArgs e)
            {
                _mainFrame.Navigate(pages[0]);
            }

            private void ButtonFav_Click(object sender, RoutedEventArgs e)
            {
            }

            private void UserControl_Loaded(object sender, RoutedEventArgs e)
            {
            }

            private void ButtonTeam_Click(object sender, RoutedEventArgs e)
            {
                _mainFrame.Navigate(pages[1]);
            }

            private void ButtonArchive_Click(object sender, RoutedEventArgs e)
            {
            }

            private void ButtonSetting_Click(object sender, RoutedEventArgs e)
            {
            }

            private void ListViewAddressBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            }

            private void Logout_Click(object sender, RoutedEventArgs e)
            {
                if (trafficController.GetState() == State.LoggedIn)
                {
                    trafficController.LogOut();
                    System.Windows.Forms.Application.Restart();
                    System.Windows.Application.Current.Shutdown();

                }

            }
        }


        public class MyItem
        {
            public string UserState { get; set; }
            public string UserName { get; set; }
            public string UserDesc { get; set; }
            public ImageSource Image { get; set; }

        }
    }


