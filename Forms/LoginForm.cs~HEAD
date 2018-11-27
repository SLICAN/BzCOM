using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ChatTest.Forms
{
    public partial class LoginForm : Form
    {
        public TrafficController trafficController = new TrafficController();
        public bool isClick = false;
        AddressBookForm MainForm = new AddressBookForm();

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

            trafficController.OnLoggedIn += TrafficController_OnLoggedIn;

            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));

            if (File.Exists(@".\file.json"))
            {
                string jsonRead = File.ReadAllText(@".\file.json");
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
                    //File.WriteAllText(@"C:\Users\Michał Adamkowski\Documents\Projects\Slican\file.json", jsonWrite);
                    File.WriteAllText(@".\file.json", jsonWrite);
                }
                this.Hide();
                trafficController.GetUsers();
                MainForm.Show();
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
                //MainForm.Run(TextBoxLogin.Text, TextBoxPassword.Text);
            
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

        private void pictureBox5_Click(object sender, EventArgs e)
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
    }
}
