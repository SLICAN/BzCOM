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
        private string login;
        private string descrption;
        //private ListViewItem item;
        //ImageSource MyImage= new BitmapImage(new Uri("", UriKind.Relative));
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
        Information informationPage;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        public AddressBookForm()
        {
            InitializeComponent();
            messageForm = new ChatMessage();
            LoadLogin();
          
            openedConnections = new List<ChatPage>();
            conversationConnections = new List<ConversationPage>();
            AdressBookPage adressBookPage = new AdressBookPage(messageForm, openedConnections, conversationConnections,myNumber);
            conversationList = new ListConversation(messageForm, openedConnections, conversationConnections, adressBookPage.ListViewAddressBook,myNumber);
            ScreenSharing screenSharing = new ScreenSharing();
            informationPage = new Information();
            pages.Add(adressBookPage);
            pages.Add(conversationList);
            pages.Add(informationPage);
            pages.Add(screenSharing);

            _mainFrame.Navigate(pages[0]);

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
            //    Console.WriteLine(ComboBoxStatus.Text);



            //   Console.WriteLine((ComboBoxStatus.SelectedIndex).ToString());
            if (ComboBoxStatus.SelectedIndex == 0) { imgPhoto.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/statusAVAperson.png", UriKind.Relative)); }
            else if (ComboBoxStatus.SelectedIndex == 1) { imgPhoto.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/statusBRBperson.png", UriKind.Relative)); }
            else if (ComboBoxStatus.SelectedIndex == 2) { imgPhoto.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/statusBUSYperson.png", UriKind.Relative)); }
            else if (ComboBoxStatus.SelectedIndex == 3) { imgPhoto.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/statusUNAperson.png", UriKind.Relative)); }
            
           



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

        public void LoadLogin()
        {
            var path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
          
            string jsonRead;


           
            if (File.Exists(path2 + "BzCOMfile.json"))
            {
                jsonRead = File.ReadAllText(path2 + "BzCOMfile.json");
                dynamic resultRead = new JavaScriptSerializer().Deserialize<dynamic>(jsonRead);
                login = resultRead["login"];
                
                myNumber = Int32.Parse(login);
            }
            else { return; }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            descrption = trafficController.GetDescriptionByNumber(login);
            TextBoxDescription.Text = descrption;
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

            

            private void ButtonAdd_Click(object sender, RoutedEventArgs e)
            {
                _mainFrame.Navigate(pages[0]);
            }

            private void ButtonFav_Click(object sender, RoutedEventArgs e)
            {
            _mainFrame.Navigate(pages[2]);
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
            _mainFrame.Navigate(pages[3]);
        }

            private void ButtonSetting_Click(object sender, RoutedEventArgs e)
            {
            }

            private void ListViewAddressBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            }

            private void Logout_Click(object sender, RoutedEventArgs e)
            {
                    trafficController.LogOut();
                    System.Windows.Forms.Application.Restart();
                    System.Windows.Application.Current.Shutdown();


            }

        private void Logout_MouseEnter(object sender, MouseEventArgs e)
        {
            logout.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/logoutOrange.png", UriKind.Relative));
            logout.Stretch = Stretch.None;
        }

        private void Logout_MouseLeave(object sender, MouseEventArgs e)
        {
            logout.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/logoutSilver.png", UriKind.Relative));
            logout.Stretch = Stretch.None;
        }

        private void ButtonAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            UserList.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/listing-optionWhite.png", UriKind.Relative));
            UserList.Stretch = Stretch.None;
        }

        private void ButtonAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            UserList.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/listing-optionSilver.png", UriKind.Relative));
            UserList.Stretch = Stretch.None;
        }

        private void ButtonArchive_MouseEnter(object sender, MouseEventArgs e)
        {
         
            Archive.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/screenWhite.png", UriKind.Relative));
            Archive.Stretch = Stretch.None;
        }

        private void ButtonArchive_MouseLeave(object sender, MouseEventArgs e)
        {
            Archive.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/screenSilver.png", UriKind.Relative));
            Archive.Stretch = Stretch.None;
        }

        private void ButtonTeam_MouseEnter(object sender, MouseEventArgs e)
        {
           
                  Team.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/groupWhite.png", UriKind.Relative));
            Team.Stretch = Stretch.None;
        }

        private void ButtonTeam_MouseLeave(object sender, MouseEventArgs e)
        {
            Team.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/groupSilver.png", UriKind.Relative));
            Team.Stretch = Stretch.None;
        }

        private void ButtonFav_MouseEnter(object sender, MouseEventArgs e)
        {
            UserInfo.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/infoWhite.png", UriKind.Relative));
            UserInfo.Stretch = Stretch.None;
        }

        private void ButtonFav_MouseLeave(object sender, MouseEventArgs e)
        {
            UserInfo.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/infoSilver.png", UriKind.Relative));
            UserInfo.Stretch = Stretch.None;
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


