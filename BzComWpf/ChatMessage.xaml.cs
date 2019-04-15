using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.IO;

namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy ChatMessage.xaml
    /// </summary>
    public partial class ChatMessage : Window
    {
        private int CursorPosition;

        //private PopUpForm popUpForm = new PopUpForm();

        public int nr;

        private bool messageSend = false;

        private List<ChatMessage> openedConnections { get; set; }

        delegate void SetTextCallBack(string text);

        delegate void SetScrollCallBack();

        private TrafficController trafficController = TrafficController.TrafficControllerInstance;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public ChatMessage(int _nr)
        {
            InitializeComponent();
            this.nr = _nr;

           
            trafficController.OnSuccessMessageSend += TrafficController_OnSuccessMessageSend;
            trafficController.OnMessageReceived += TrafficController_OnMessageReceived;
            Webbrowser.Navigate("about:blank");
            Webbrowser.Document.Write("<html><head><style>body,table { font-size: 8pt; font-family: Verdana; margin: 3px 3px 3px 3px; font-color: black; } </style>" +
                "</head><body width=\"" + (Webbrowser.ClientSize.Width - 20).ToString() + "\">");

            LoadMessages(trafficController.GetMessagesByNumber(nr));
        }

        public void Initialize(ChatMessage connection)
        {   
            openedConnections.Add(connection);
        }

        private void LoadMessages(List<Message> messages)
        {
            foreach (Message message in messages)
            {
                if (message.IsMine)
                {
                    TypeText("ja", message.Text, message.DateTime);
                }
                else
                {
                    TypeText(trafficController.FindName(message.Number.ToString()), message.Text, message.DateTime);
                }
            }

        }
        private void TrafficController_OnSuccessMessageSend(TrafficController sender, bool error)
        {
            if (messageSend)
            {
                if (!error)
                {
                    TypeText("ja", TextBoxMessage.Text, DateTime.Now);
                    TextBoxMessage.Clear();
                    messageSend = false;
                }
                else
                    MessageBox.Show("Nie udało się wysłać wiadomości", "Error");
            }

        }
        /// <summary>
        /// Wpisz na formatkę otrzymaną wiadomość i uruchom popUpForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msgNow"></param>
        private void TrafficController_OnMessageReceived(TrafficController sender, Message msgNow)
        {    
            if (nr == msgNow.Number)
            {
                
                TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text, msgNow.DateTime);
            }
            else
            {
                Console.WriteLine("MSG" + msgNow.Number);
            }

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
            if (Webbrowser.InvokeRequired)
            {
                Console.WriteLine("SCROOLL");
                SetScrollCallBack s = new SetScrollCallBack(SetScroll);
                Dispatcher.Invoke(s);
            }
            else
            {
                Webbrowser.Document.Window.ScrollTo(0, 2147483);
            }
        }

        /// <summary>
        /// Wpisz na webBrowser
        /// </summary>
        /// <param name="text"></param>
        private void SetTextHTML(string text)
        {
            
            if (Webbrowser.InvokeRequired)
            {
                Console.WriteLine("SetTextHTML");
                SetTextCallBack f = new SetTextCallBack(SetTextHTML);
                Dispatcher.Invoke(f, new object[] { text });
            }
            else
                Webbrowser.Document.Write(text);
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
        }

        private void ButtonSend_Click_1(object sender, RoutedEventArgs e)
        {
            if (trafficController.GetState() == State.OpenedGate && !TextBoxMessage.Text.Equals(""))
            {
                /// Wysyłanie konkretnej wiadomości do kontaktu, z którym mamy otwartego gate'a
                trafficController.SMSSend(nr.ToString(), null, TextBoxMessage.Text, "", null);
                messageSend = true;
            }
            else MessageBox.Show("Nie wybrałeś kontaktu, do którego chcesz wysłać wiadomość!");
        }
    }
}
