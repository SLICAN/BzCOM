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
        public int nr_z_sel_item;
        private bool messageSend = false;

        private List<ChatPage> openedConnections;
        public int idx;
        private bool istnieje;
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
            istnieje = false;
            idx = 0;
            //nr_z_sel_item = Int32.Parse(selected);
            openedConnections = _openedConnection;
            //openedConnections.Add(new ChatPage(idx, nr));
            foreach (ChatPage chatPage in openedConnections)
            {
                if(chatPage.nr == nr){istnieje = true;}
            }
            if (istnieje == true)
            {
                foreach (ChatPage chatPage in openedConnections)
                {
                    if(chatPage.nr == nr_z_sel_item)
                    {
                        idx = openedConnections.IndexOf(chatPage);
                    }
                }
                _mainFrame.Navigate(openedConnections[idx]); }
            else {
                ChatPage strona = new ChatPage(nr);
                openedConnections.Add(strona);
                idx = openedConnections.IndexOf(strona);
                Console.WriteLine("Index w elsie"+ idx);
                _mainFrame.Navigate(openedConnections[idx]); //Bug wyswietlil idx 1
            }
            
            
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
            ConnectionsListView.Items.Remove(item);        
                  
            
        }
    }
}
    public class ConnectionItem
    {
        public string UserName { get; set; }
        public string UserNumber { get; set; }
        
    }


