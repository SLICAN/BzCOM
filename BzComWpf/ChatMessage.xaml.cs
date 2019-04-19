using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Navigation;

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

            ConnectionsListView.Items.Clear();
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void ConnectionsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //ConnectionItem selectedItem = (ConnectionItem)ConnectionsListView.SelectedItems[0];
            var selected = ConnectionsListView.SelectedIndex;
            _mainFrame.Navigate(openedConnections[selected]);
        }

        private void DeleteConnection(object sender, RoutedEventArgs e)
        {
            var selected = ConnectionsListView.SelectedIndex;

            Button b = sender as Button;
            ConnectionItem item = b.CommandParameter as ConnectionItem;
            
            foreach (var chatPage in openedConnections)
            {
                Console.WriteLine(chatPage.ToString());
                Console.WriteLine(selected);
            }

            openedConnections.RemoveAt(selected);
            //Console.WriteLine(selected);
            //int index = openedConnections.FindIndex()
            ConnectionsListView.Items.Remove(item);        
            idx--;
            
            //Nie usuwa sie ChatPage
            //Dalej jest kilka polaczen xd, albo to dlatego                           
            
        }
    }
}
    public class ConnectionItem
    {
        public string UserName { get; set; }
        public string UserNumber { get; set; }
        
    }


