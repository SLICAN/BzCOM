using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy ActiveUsersxaml.xaml
    /// </summary>
    public partial class ActiveUsersxaml : Window
    {
        private int myNumber;
        private string currentNumber;
        public DateTime messageSendTime; 
        delegate void SetUsersCallBack(List<User> users);
        private List<MyItem> myItems = new List<MyItem>();
        private TrafficController trafficController = TrafficController.TrafficControllerInstance;
        public ChatMessage messageForm;
        private List<ChatPage> openedConnections;
        List<string> numbers = new List<string>();
        private int[] number;
        public ActiveUsersxaml(ListView listView)
        {
            InitializeComponent();

            Wypelnij(listView);
            
        }

        public int[] NumeryPolaczen
        {
            get { return number; }
        }
        
        private int[] numeryPolaczen()
        {
            foreach (MyItem items in myItems)
            {
                numbers.Add(trafficController.FindNumber(items.UserName));        
            }
            number = new int[numbers.Count];
            for (int i = 0; i < numbers.Count; i++)
            {
                number[i] = Int32.Parse(numbers[i]);
                Console.WriteLine(number[i] + " Połączenie");
        
            }
            return number;
        }
        

        private void ActiveUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(MyItem item in e.RemovedItems)
            {
                myItems.Remove(item);
            }
            foreach(MyItem item in e.AddedItems)
            {
                myItems.Add(item);
            }
        }


        public void Wypelnij(ListView listView)
        {
                foreach(MyItem item in listView.Items)
                {
                if (item.UserState.Equals("AVAILABLE") || item.UserState.Equals("BUSY"))
                    ActiveUsers.Items.Add(item);
                }
                //MyItem selectedItem = (MyItem)ActiveUsers.SelectedItems[0];
                //currentNumber = trafficController.FindNumber(selectedItem.UserName);
                //trafficController.SetState(State.OpenedGate);

            }

        private void EmotikonaButton_Click(object sender, RoutedEventArgs e)
        {
            string numeryaktywne = "";
            number = numeryPolaczen();

            for (int i = 0; i < number.Length; i++)
            {
                numeryaktywne += "?" +number[i];
            }
            for (int i = 0; i < number.Length; i++)
            {
                messageSendTime = DateTime.Now;
                trafficController.SMSSend(number[i].ToString(), null, "CONVERSATION"+numeryaktywne, "1",""+messageSendTime);
            }
        }
    }
    }
