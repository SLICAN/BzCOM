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
using System.Collections;

namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy ChatMessage.xaml
    /// </summary>
    public partial class ChatMessage : Window
    {
       
        public int nr_z_sel_item;
        public int[] nr_conv;
       
        private int myNumber;
        private List<ChatPage> openedConnections;
        private List<ConversationPage> conversationConnections;
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


        public void Initialize(List<ChatPage> _openedConnection,int nr,int _mynumber)
        {
            istnieje = false;
            idx = 0;
            myNumber = _mynumber;
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
                ChatPage strona = new ChatPage(nr,myNumber);
                openedConnections.Add(strona);
                idx = openedConnections.IndexOf(strona);
                Console.WriteLine("Index w elsie"+ idx);
                _mainFrame.Navigate(openedConnections[idx]); //Bug wyswietlil idx 1
            }
            
            
        }
        public void Initialize(List<ConversationPage> _openedConnection, int[] nr, int _mynumber)
        {
            istnieje = false;
            idx = 0;
            myNumber = _mynumber;
            //nr_z_sel_item = Int32.Parse(selected);
            conversationConnections = _openedConnection;
            //openedConnections.Add(new ChatPage(idx, nr));
            
            foreach (ConversationPage chatPage in conversationConnections)
            {
                IStructuralEquatable se1 = chatPage.conversation_numbers;
                if (se1.Equals(nr,StructuralComparisons.StructuralEqualityComparer)) { istnieje = true; } // tu jest blad pewnie cos takiego jak converstation_numbers jst 
            }
            if (istnieje == true)
            {
                foreach (ConversationPage convPage in conversationConnections)
                {
                    IStructuralEquatable se1 = convPage.conversation_numbers;
                    if (se1.Equals(nr, StructuralComparisons.StructuralEqualityComparer))
                    {
                        idx = conversationConnections.IndexOf(convPage);
                    }
                }
                _mainFrame.Navigate(conversationConnections[idx]);
            }
            else
            {
              ConversationPage strona = new ConversationPage(nr, myNumber);
              conversationConnections.Add(strona);
              idx = conversationConnections.IndexOf(strona);
              _mainFrame.Navigate(conversationConnections[idx]); //Bug wyswietlil idx 1
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
            int idxconv;
            int idxchat;
            int breakid;

            idxchat = 0;
            idxconv = 0;
            breakid = 0;
            ConnectionItem selectedType = (ConnectionItem)ConnectionsListView.SelectedItems[0];
            var selected = ConnectionsListView.SelectedIndex;

            foreach (ConnectionItem item in ConnectionsListView.Items)
            {
                if (breakid <= selected)
                {
                    if (item.IsConv == true) { idxconv++; breakid++; }
                    else { idxchat++; breakid++; }
                }
                else
                {
                    break;
                }
            }
            if (ConnectionsListView.HasItems)
            {
                if (selectedType.IsConv == true) { _mainFrame.Navigate(conversationConnections[selected - idxchat]); }
                else { _mainFrame.Navigate(openedConnections[selected - idxconv]); }

            }
            else { };
            // if (selectedType.IsConv == true) { _mainFrame.Navigate }
            // if (ConnectionsListView.HasItems) { _mainFrame.Navigate(conversationConnections[selected]); }


            // selected = ConnectionsListView.SelectedIndex;     
            //if (ConnectionsListView.HasItems) {

            //     _mainFrame.Navigate(openedConnections[selected]); }
            // else { };

        }

        private void DeleteConnection(object sender, RoutedEventArgs e)
        {
            //var selected = ConnectionsListView.SelectedIndex;

            Button b = sender as Button;
            ConnectionItem item = b.CommandParameter as ConnectionItem;
            int idxconv;
            int idxchat;
            int breakid;

            idxchat = 0;
            idxconv = 0;
            breakid = 0;

            var selected = ConnectionsListView.SelectedIndex;

            foreach (ConnectionItem con in ConnectionsListView.Items)
            {
                if (breakid <= selected)
                {
                    if (con.IsConv == true) { idxconv++; breakid++; }
                    else { idxchat++; breakid++; }
                }
                else
                {
                    break;
                }
            }

            /*foreach (var chatPage in openedConnections)
            {
                Console.WriteLine(chatPage.ToString());
                Console.WriteLine(selected);
            }*/
            ConnectionsListView.Items.Remove(item);

            if (ConnectionsListView.HasItems == false)
            {
                _mainFrame.Navigate("");
            }


        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MenuPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void buttonListView_MouseEnter(object sender, MouseEventArgs e)
        {
          
        }
    }
}
    public class ConnectionItem
    {
        public string UserName { get; set; }
        public string UserNumber { get; set; }
        public bool IsConv { get; set; }
    }


