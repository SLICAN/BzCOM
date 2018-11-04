using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ChatTest.Forms
{
    public partial class MessageForm : Form
    {
        private int CursorPosition;

        private PopUpForm popUpForm = new PopUpForm();

        public string nr;

        delegate void SetTextCallBack(string text);

        delegate void SetScrollCallBack();

        private TrafficController trafficController = TrafficController.TrafficControllerInstance;

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

        public MessageForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));

            trafficController.OnMessageReceived += TrafficController_OnMessageReceived;
            trafficController.OnSuccessMessageSend += TrafficController_OnSuccessMessageSend;

            webBrowser11.Navigate("about:blank");
            webBrowser11.Document.Write("<html><head><style>body,table { font-size: 8pt; font-family: Verdana; margin: 3px 3px 3px 3px; font-color: black; } </style></head><body width=\"" + (webBrowser11.ClientSize.Width - 20).ToString() + "\">");
        }

        private void TrafficController_OnSuccessMessageSend(TrafficController sender, bool error)
        {
            if (!error)
            {
                TypeText("ja", TextBoxMessage.Text, DateTime.Now);
                TextBoxMessage.Clear();
            }
            else
                MessageBox.Show("Nie udało się wysłać wiadomości", "Error");
        }

        /// <summary>
        /// Wpisz na formatkę otrzymaną wiadomość i uruchom popUpForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msgNow"></param>
        private void TrafficController_OnMessageReceived(TrafficController sender, Message msgNow)
        {
            TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text, msgNow.DateTime);

            if (CheckOpened(Text))
            {
                //MessageBox.Show("OTWARTE OKNO");
            }
            else
            {
                //MessageBox.Show("NIE OTWARTE OKNO");
                //timer1.Enabled = true;
                popUpForm.labelWho.Text = trafficController.FindName(msgNow.Number.ToString());
                popUpForm.labelWhat.Text = msgNow.Text;
                popUpForm.ShowDialog();
            }
        }

        /// <summary>
        /// Button send
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (trafficController.GetState() == State.OpenedGate)
            {
                /// Wysyłanie konkretnej wiadomości do kontaktu, z którym mamy otwartego gate'a
                trafficController.SMSSend(nr, null, TextBoxMessage.Text, "", null);
            }
            else MessageBox.Show("Nie wybrałeś kontaktu, do którego chcesz wysłać wiadomość!");
        }

        /// <summary>
        /// Wpisz wiadomość na formatkę  
        /// </summary>
        /// <param name="who"></param>
        /// <param name="message"></param>
        /// <param name="datatime"></param>
        public void TypeText(string who, string message, DateTime datatime)
        {
            SetTextHTML("<table><tr><td width=\"10%\"><b><font size=1>" + who + "</font></b></td><td width=\"90%\"><font size=1>(" + datatime + "):</font></td></tr>");
            SetTextHTML("<tr><td colspan=2><font size=1>" + message + "</font></td></tr></table>");
            SetTextHTML("<hr>");
            SetScroll();
        }

        /// <summary>
        /// Scrolluj na dół
        /// </summary>
        private void SetScroll()
        {
            if (webBrowser11.InvokeRequired)
            {
                Console.WriteLine("SCROOLL");
                SetScrollCallBack s = new SetScrollCallBack(SetScroll);
                Invoke(s);
            }
            else
            {
                //webBrowser11.Document.Window.ScrollTo(0, int.MaxValue);
                webBrowser11.Document.Window.ScrollTo(0, 2147483);
            }
        }

        /// <summary>
        /// Wpisz na webBrowser
        /// </summary>
        /// <param name="text"></param>
        private void SetTextHTML(string text)
        {
            if (webBrowser11.InvokeRequired)
            {
                Console.WriteLine("SetTextHTML");
                SetTextCallBack f = new SetTextCallBack(SetTextHTML);
                Invoke(f, new object[] { text });
            }
            else
                webBrowser11.Document.Write(text);
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser11.Navigate("about:blank");
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    try
                    {
                        sw.Write(webBrowser11.DocumentText);
                    }
                    catch
                    {
                        MessageBox.Show("Nie można zapisać pliku: " + saveFileDialog1.FileName);
                    }
            }
        }


        private void InsertTag(string tag)
        {
            string code = TextBoxMessage.Text;
            TextBoxMessage.Text = code.Insert(CursorPosition, tag);
            TextBoxMessage.Focus();
            if (tag == "<br>" || tag == "<hr>")
            {
                TextBoxMessage.Select(CursorPosition + tag.Length, 0);
                CursorPosition += tag.Length;
            }
            else
            {
                TextBoxMessage.Select(CursorPosition + tag.Length / 2, 0);
                CursorPosition += tag.Length / 2;
            }
        }

        private void TextBoxMessage1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.ButtonSend_Click(sender, e);
            CursorPosition = TextBoxMessage.SelectionStart;
        }

        private void TextBoxMessage1_KeyUp(object sender, KeyEventArgs e)
        {
            CursorPosition = TextBoxMessage.SelectionStart;
        }

        private void TextBoxMessage1_MouseUp(object sender, MouseEventArgs e)
        {
            CursorPosition = TextBoxMessage.SelectionStart;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown
                || e.CloseReason == CloseReason.ApplicationExitCall
                || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                return;
            }
            e.Cancel = true;
            //assuming you want the close-button to only hide the form, 
            //and are overriding the form's OnFormClosing method:
            this.Hide();
        }

        private void ButtonBold_Click(object sender, EventArgs e)
        {
            InsertTag("<b></b>");
        }

        private void ButtonItalic_Click(object sender, EventArgs e)
        {
            InsertTag("<i></i>");
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
