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
           
            //  Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            trafficController.OnLoggedIn += TrafficController_OnLoggedIn;

            var path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (File.Exists(path2 + "BzCOMfile.json"))
            {
                string jsonRead = File.ReadAllText(path2 + "BzCOMfile.json");
                dynamic resultRead = new JavaScriptSerializer().Deserialize<dynamic>(jsonRead);
                TextBoxLogin.Text = resultRead["login"];
                TextBoxPassword.Text = resultRead["password"];
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
                        password = TextBoxPassword.Text
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
                trafficController.LogIn(TextBoxLogin.Text, TextBoxPassword.Text);
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
    }
}
