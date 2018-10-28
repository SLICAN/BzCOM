using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatTest.Forms
{
    public partial class MessageForm : Form
    {
        private int CursorPosition;

        public string nr;

        delegate void SetTextCallBack(string text);

        delegate void SetScrollCallBack();

        public TrafficController trafficController = new TrafficController();

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

            webBrowser11.Navigate("about:blank");
            webBrowser11.Document.Write("<html><head><style>body,table { font-size: 8pt; font-family: Verdana; margin: 3px 3px 3px 3px; font-color: black; } </style></head><body width=\"" + (webBrowser11.ClientSize.Width - 20).ToString() + "\">");
        }

        /// <summary>
        /// Button send
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSend1_Click(object sender, EventArgs e)
        {

            if (trafficController.GetState() == State.OpenedGate)
            {
                if (!trafficController.SMSSend(nr, null, TextBoxMessage1.Text, "", null))
                    TypeText("ja", TextBoxMessage1.Text, DateTime.Now);
                else
                    MessageBox.Show("Nie udalo sie nawiazac rozmowy");

                TextBoxMessage1.Clear();
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

        private void TrafficController_OnMessageReceived(TrafficController sender, Message msgNow)
        {
            //Console.WriteLine("WORK TRAFFIC CINTROLER ON MESEAGE RECEIVED");
            //TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text, msgNow.DateTime);
        }

        private void InsertTag(string tag)
        {
            string code = TextBoxMessage1.Text;
            TextBoxMessage1.Text = code.Insert(CursorPosition, tag);
            TextBoxMessage1.Focus();
            if (tag == "<br>" || tag == "<hr>")
            {
                TextBoxMessage1.Select(CursorPosition + tag.Length, 0);
                CursorPosition += tag.Length;
            }
            else
            {
                TextBoxMessage1.Select(CursorPosition + tag.Length / 2, 0);
                CursorPosition += tag.Length / 2;
            }
        }

        private void TextBoxMessage1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.ButtonSend1_Click(sender, e);
            CursorPosition = TextBoxMessage1.SelectionStart;
        }

        private void TextBoxMessage1_KeyUp(object sender, KeyEventArgs e)
        {
            CursorPosition = TextBoxMessage1.SelectionStart;
        }

        private void TextBoxMessage1_MouseUp(object sender, MouseEventArgs e)
        {
            CursorPosition = TextBoxMessage1.SelectionStart;
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
    }
}
