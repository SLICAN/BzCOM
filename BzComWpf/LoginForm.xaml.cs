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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;



namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int przelacznik = 0;
        int padlock = 0;
        int kolor = 0;

        //int padlock = 0;

        //bool drag = false;
        Point start_point = new Point(0, 0);
 
        private TrafficController trafficController = TrafficController.TrafficControllerInstance;

        //private PopUpForm popUpForm = new PopUpForm();

        //private bool isClick = false;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        
        public MainWindow()
        {

           
            InitializeComponent();
            

            TextBoxPort.Visibility = Visibility.Hidden;
            TextBoxIp.Visibility = Visibility.Hidden;
            //  Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            trafficController.OnLoggedIn += TrafficController_OnLoggedIn;

            var path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (File.Exists(path2 + "BzCOMfile.json"))
            {
                string jsonRead = File.ReadAllText(path2 + "BzCOMfile.json");
                dynamic resultRead = new JavaScriptSerializer().Deserialize<dynamic>(jsonRead);
                TextBoxLogin.Text = resultRead["login"];
                PasswordBoxPassword.Password = resultRead["password"];
            }
            else
            {
                return;
            }
        }

        private void TrafficController_OnLoggedIn(TrafficController sender, string info)
        {
            //popUpForm.labelWhat.Text = info;
            /// Changes the status displayed in combobox, when you logged in
            if (trafficController.GetState() == State.LoggedIn)
            {
                if (SaveToFileCheckBox.IsChecked==true)
                {
                    SaveToJSON loginFile = new SaveToJSON()
                    {
                        login = TextBoxLogin.Text,
                        password = PasswordBoxPassword.Password
                    };
                    string jsonWrite = new JavaScriptSerializer().Serialize(loginFile);
                    //File.WriteAllText(@".\file.json", jsonWrite);

                    var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    File.WriteAllText(path + "BzCOMfile.json", jsonWrite);
                }

                this.Hide();
                trafficController.GetUsers();
                new AddressBookForm();
                //MainForm.Show();
                //MainForm.Run(TextBoxLogin.Text, TextBoxPassword.Text);
            }

            if (trafficController.wrongLogin)
            {
                labelLoginInfo.Content = "Zły login lub hasło";
                trafficController.wrongLogin = false;
            }

        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            labelLoginInfo.Content = "";
            if (trafficController.GetState() == State.Connected)
            {
                trafficController.LogIn(TextBoxLogin.Text, PasswordBoxPassword.Password);
            }
        }

        private void TextBoxIp_TextChanged(object sender, TextChangedEventArgs e)
        {
            trafficController.SetIPAddress(IPAddress.Parse(TextBoxIp.Text));
        }

        private void TextBoxPort_TextChanged(object sender, TextChangedEventArgs e)
        {
            trafficController.SetPort(Int32.Parse(TextBoxPort.Text));
        }

     

     

    

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        

     
        private void Glowny_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

      

        private void TextBoxLogin_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TextBoxLogin.Text == "Login")
            {
                TextBoxLogin.Text = "";
                TextBoxLogin.Foreground = Brushes.White;
               

            }

            separatorLogin.Background = Brushes.Aqua;   
            imageLogin.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/PersonAqua.png", UriKind.Relative));
        }

        
        private void TextBoxLogin_LostFocus(object sender, RoutedEventArgs e)
        {

            if (TextBoxLogin.Text=="")
            {

                TextBoxLogin.Text = "Login";
                TextBoxLogin.Foreground = Brushes.Silver;

            }
           


            separatorLogin.Background = Brushes.White;
            imageLogin.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/person.png", UriKind.Relative));
        }

        private void TextBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxLogin_Loaded(object sender, RoutedEventArgs e)
        {
         

        }

        private void TextBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            separatorPassword.Background = Brushes.White;
            if (padlock==1)
            {
                imagePassword.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/unlock.png", UriKind.Relative));
                kolor = 0;
            }
           
            else if(padlock==0)
            {
                imagePassword.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/lock.png", UriKind.Relative));
                kolor = 0;
            }
        }

        private void TextBoxPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            separatorPassword.Background = Brushes.Aqua;

            if (padlock == 1)
            {
                imagePassword.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/unlockAqua.png", UriKind.Relative));
                kolor = 1;
            }
            else if (padlock == 0)
            {
                imagePassword.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/lockAqua.png", UriKind.Relative));
                kolor = 1;
            }
          
        }

        private void ImagePassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (padlock == 0)
            {

                PasswordBoxPassword.Visibility = System.Windows.Visibility.Collapsed;
                TextBoxPassword.Visibility = System.Windows.Visibility.Visible;
                TextBoxPassword.Text = PasswordBoxPassword.Password;
                TextBoxPassword.Focus();
                padlock = 1;

                if(kolor==1)
                {
                   
                    imagePassword.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/unlockAqua.png", UriKind.Relative));

                }
                else if (kolor==0)
                {
                    imagePassword.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/unlock.png", UriKind.Relative));

                }

            }
            else if(padlock==1)
            {
                PasswordBoxPassword.Visibility = System.Windows.Visibility.Visible;
                TextBoxPassword.Visibility = System.Windows.Visibility.Collapsed;
                PasswordBoxPassword.Password = TextBoxPassword.Text;
                PasswordBoxPassword.Focus();
                padlock = 0;

                if (kolor == 1)
                {
                    
                    imagePassword.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/lockAqua.png", UriKind.Relative));

                }
                else if (kolor == 0)
                {

                    imagePassword.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/lock.png", UriKind.Relative));
                }
            }

        }

        private void ButtonSetting_Click(object sender, RoutedEventArgs e)
        {
            if (przelacznik == 0)
            {
                imageSetting.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/settingsAqua.png", UriKind.Relative));
                TextBoxPort.Visibility = Visibility.Visible;
                TextBoxIp.Visibility = Visibility.Visible;
                przelacznik = 1;
            }
            else if (przelacznik == 1)
            {
                imageSetting.Source = new BitmapImage(new Uri(@"/Images/GrafikiPanel/settingsWhite.png", UriKind.Relative));

                TextBoxPort.Visibility = Visibility.Hidden;
                TextBoxIp.Visibility = Visibility.Hidden;
                przelacznik = 0;
            }
        }

        private void ButtonSetting_LostFocus(object sender, RoutedEventArgs e)
        {
            
           

            }

        private void TextBoxIp_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBoxIp.Background = new SolidColorBrush(Color.FromRgb(65, 174, 207));
               
        }

        private void TextBoxIp_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBoxIp.Background = Brushes.White;
        }

        private void TextBoxPort_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBoxPort.Background = Brushes.White;
        }

        private void TextBoxPort_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            TextBoxPort.Background = new SolidColorBrush(Color.FromRgb(65, 174, 207));
        }

        private void PasswordBoxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TextBoxPassword.Text = PasswordBoxPassword.Password;
        }

        private void TextBoxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordBoxPassword.Password = TextBoxPassword.Text;
        }
    }
    }

    

