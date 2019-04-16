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

        private int nr;

        private bool messageSend = false;

        private List<ChatPage> openedConnections;
        public int idx = 0;

        delegate void SetTextCallBack(string text);

        delegate void SetScrollCallBack();

        private TrafficController trafficController = TrafficController.TrafficControllerInstance;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();



        public ChatMessage()
        {
            InitializeComponent();
        }


        public void Initialize(List<ChatPage> _openedConnection)
        {
            //var temp = Enumerable.Empty<ListViewItem>();
            // if (this.ConnectionsListView.Items.Count > 0)
            //     temp = this.ConnectionsListView.Items.OfType<ListViewItem>();
            // var last = temp.LastOrDefault();
            foreach (ConnectionItem item in ConnectionsListView.Items)
            {
                nr = Int32.Parse(item.UserNumber);
                Console.WriteLine("Numer itemu: " + nr);
            }
            openedConnections = _openedConnection;
            openedConnections.Add(new ChatPage(idx, nr));
            _mainFrame.Navigate(openedConnections[idx]);
            idx++;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
        }

        private void ConnectionsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //ConnectionItem selectedItem = (ConnectionItem)ConnectionsListView.SelectedItems[0];
            var selected = ConnectionsListView.SelectedIndex;
            _mainFrame.Navigate(openedConnections[selected]);
        }
    }
}
    public class ConnectionItem
    {
        public string UserName { get; set; }
        public string UserNumber { get; set; }
    }


        // /// <summary>
        // /// Scrolluj na dół
        // /// </summary>
        //private void SetScroll()
        // {
        // if (Webbrowser.InvokeRequired)
        //     {
        //         Console.WriteLine("SCROOLL");
        //         SetScrollCallBack s = new SetScrollCallBack(SetScroll);
        //         Dispatcher.Invoke(s);
        //     }
        //     else
        //     {
        //         Webbrowser.Document.Window.ScrollTo(0, 2147483);
        //     }
        // }

///// <summary>
///// Wpisz na webBrowser
///// </summary>
///// <param name="text"></param>
//private void SetTextHTML(string text)
//{

//   if (Webbrowser.InvokeRequired)
//    {
//        Console.WriteLine("SetTextHTML");
//        SetTextCallBack f = new SetTextCallBack(SetTextHTML);
//        Dispatcher.Invoke(f, new object[] { text });
//    }
//    else
//        Webbrowser.Document.Write(text);
//}

//        public ChatMessage(int _nr)
//{
//    InitializeComponent();
//    this.nr = _nr;



//    _mainFrame.Navigate(new ChatPage());
//   // Webbrowser.Navigate("about:blank");
//   // Webbrowser.Document.Write("<html><head><style>body,table { font-size: 8pt; font-family: Verdana; margin: 3px 3px 3px 3px; font-color: black; } </style>" +
//   //     "</head><body width=\"" + (Webbrowser.ClientSize.Width - 20).ToString() + "\">");


//}

//public void Initialize(List<ChatMessage> _openedConnection)
//{
//    openedConnections = _openedConnection;
//    openedConnections.Add(this);
//}



//private void InsertTag(string tag)
//{
//    string code = TextBoxMessage.Text;
//    TextBoxMessage.Text = code.Insert(CursorPosition, tag);
//    TextBoxMessage.Focus();
//    if (tag == "<br>" || tag == "<hr>")
//    {
//        TextBoxMessage.Select(CursorPosition + tag.Length, 0);
//        CursorPosition += tag.Length;
//    }
//    else
//    {
//        TextBoxMessage.Select(CursorPosition + tag.Length / 2, 0);
//        CursorPosition += tag.Length / 2;
//    }
//}



//private void ButtonSend_Click_1(object sender, RoutedEventArgs e)
//{
// if (trafficController.GetState() == State.OpenedGate && !TextBoxMessage.Text.Equals(""))
//    {
//        /// Wysyłanie konkretnej wiadomości do kontaktu, z którym mamy otwartego gate'a
//        trafficController.SMSSend(nr.ToString(), null, TextBoxMessage.Text, "", null);
//        messageSend = true;
//    }
//    else MessageBox.Show("Nie wybrałeś kontaktu, do którego chcesz wysłać wiadomość!");
//}


//}
///*
//}


