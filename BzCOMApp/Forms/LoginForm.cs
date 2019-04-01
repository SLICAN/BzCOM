using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ChatTest.Forms
{
    public partial class LoginForm : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        private TrafficController trafficController = TrafficController.TrafficControllerInstance;

        private PopUpForm popUpForm = new PopUpForm();

        private bool isClick = false;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public LoginForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
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
        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }

        private void TrafficController_OnLoggedIn(TrafficController sender, string info)
        {
            popUpForm.labelWhat.Text = info;
            /// Changes the status displayed in combobox, when you logged in
            if (trafficController.GetState() == State.LoggedIn)
            {
                if (SaveToFileCheckBox.Checked)
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
                labelLoginInfo.Text = "ZŁY LOGIN LUB HASŁO";
                trafficController.wrongLogin = false;
            }
          
        }

        /// <summary>
        /// Button login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            labelLoginInfo.Text = "";
            if (trafficController.GetState() == State.Connected)
            {
                trafficController.LogIn(TextBoxLogin.Text, TextBoxPassword.Text);
            }
        }

        /// <summary>
        /// Ustaw adres IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxIPAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            trafficController.SetIPAddress(IPAddress.Parse(ComboBoxIPAddress.Text));
        }

        /// <summary>
        /// Ustaw port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownPort_ValueChanged(object sender, EventArgs e)
        {
            trafficController.SetPort(Convert.ToInt32(NumericUpDownPort.Value));
        }

        private void TextBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.ButtonLogin_Click(sender, e);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SettingsImage_Click(object sender, EventArgs e)
        {
            if (!isClick)
            {
                panelSettings.Visible = true;
                isClick = true;
            }
            else
            {
                panelSettings.Visible = false;
                isClick = false;
            }
        }

        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LoginImage_Click(object sender, EventArgs e)
        {

        }

        private void ResizeButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackColor = ColorTranslator.FromHtml("0; 10; 18");
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void buttonExit_MouseDown(object sender, MouseEventArgs e)
        {
            //drag = true;
            //start_point = new Point(e.X, e.Y);
        }

        private void TextBoxLogin_TextChanged(object sender, EventArgs e)
        {
            
          
        }

        private void TextBoxLogin_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            //drag = true;
            //start_point = new Point(e.X, e.Y);
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void buttonMinimize_MouseLeave(object sender, EventArgs e)
        {
            buttonMinimize.BackColor = ColorTranslator.FromHtml("0; 10; 18");
        }

        private void buttonMinimize_MouseEnter(object sender, EventArgs e)
        {
            buttonMinimize.BackColor = Color.Orange;
        }

        private void TextBoxLogin_MouseClick(object sender, MouseEventArgs e)
        {

            
        }

        private void TextBoxLogin_Enter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Aqua;

            if(TextBoxLogin.Text == "Login")
            {
                TextBoxLogin.Text = "";
                TextBoxLogin.ForeColor = Color.White;
            }
        }

        private void TextBoxLogin_Leave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            if (TextBoxLogin.Text == "")
            {
                TextBoxLogin.Text = "Login";
                TextBoxLogin.ForeColor = Color.Silver;
            }
        }

        private void TextBoxPassword_Enter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Aqua;
           

        }

        private void TextBoxPassword_Leave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.White;
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
