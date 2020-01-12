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
        public DateTime messageSendTime;
        private int myNumber;
        delegate void SetUsersCallBack(List<User> users);
        private List<MyItem> myItems = new List<MyItem>();
        private TrafficController trafficController = TrafficController.TrafficControllerInstance;
        public ChatMessage messageForm;
        List<string> numbers = new List<string>();
        private int[] number;
        public ActiveUsersxaml(ListView listView,int _myNumber)
        {
            InitializeComponent();
            myNumber = _myNumber;
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
            number = new int[numbers.Count+1];
            number[0] = myNumber;
            for (int i = 1; i < number.Length; i++)
            {
                number[i] = Int32.Parse(numbers[i-1]);
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
            string myname = trafficController.FindName(myNumber.ToString());
            foreach (MyItem item in listView.Items)
            {
                if (item.UserName.Equals(myname)) { }
                else
                {
                    if (item.UserState.Equals("AVAILABLE") || item.UserState.Equals("BUSY"))

                        ActiveUsers.Items.Add(item);
                }
            }
                //MyItem selectedItem = (MyItem)ActiveUsers.SelectedItems[0];
                //currentNumber = trafficController.FindNumber(selectedItem.UserName);
                //trafficController.SetState(State.OpenedGate);

            }

        private void EmotikonaButton_Click(object sender, RoutedEventArgs e)
        {
            int id  = 0;
            string numeryaktywne = "";
            number = numeryPolaczen();
            if (number.Count() == 2)
            {
                MessageBox.Show("Do czatu grupowego potrzeba minimum 3 rozmówców");
            }
            else
            {
                for (int i = 0; i < number.Length; i++)
                {
                    numeryaktywne += "?" + number[i];
                }
                for (int i = 0; i < number.Length; i++)
                {
                    messageSendTime = DateTime.Now;
                    trafficController.SMSSend(number[i].ToString(), null, "CONVERSATION" + numeryaktywne, "1", "" + messageSendTime);
                }
                this.Close();
            }
        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void zamknijOkno_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    }
