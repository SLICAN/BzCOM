using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BzCOMWpf
{
   
    /// <summary>
    /// Logika interakcji dla klasy Chat.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        public int nr;
        private TrafficController trafficController = TrafficController.TrafficControllerInstance;
        delegate void SetTextCallBack(string text);
        delegate void SetScrollCallBack();
        private bool messageSend = false;

        public DateTime messageSendTime; // Zmienna pod dokładny czas wysłania wiadomości.


       



        public ChatPage(int _nr)
        {
           
            nr = _nr;
       
            InitializeComponent();
            Title = nr.ToString();
            trafficController.OnSuccessMessageSend += TrafficController_OnSuccessMessageSend;
            trafficController.OnMessageReceived += TrafficController_OnMessageReceived;
           /* Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
            {
                var navWindow = Window.GetWindow(this) as NavigationWindow;
                if (navWindow != null) navWindow.ShowsNavigationUI = false;
            }));*/
        
            

            LoadMessages(trafficController.GetMessagesByNumber(nr));
         
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
                    TypeText("ja", TextBoxMessage.Text, messageSendTime);
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
            //Chat.Text += who + " : " + message;
            SetTextHTML(who + ": " + datatime + "\n");
            SetTextHTML("" + message + "\n");
            SetTextHTML("");
            //SetScroll();
        }
        private void SetTextHTML(string text)
        {
            if (Chat.Dispatcher.Thread == Thread.CurrentThread)
            {

                Chat.Text += text;
            }
            else
            {
                Console.WriteLine("SetTextHTML");
                SetTextCallBack f = new SetTextCallBack(SetTextHTML);
                Dispatcher.Invoke(f, new object[] { text });
            }
        }


        // Ważna informacja względem możliwej chęci użycia userData:
        // Parametr ten służy do przesyłania dodatkowych informacji takich jak "czy drugi użytkownik pisze w tej chwili 
        // wiadomość". Obecnie ta zmienna jest wykorzystywana do przechowywania dokładnego czasu wysłania wiadomości
        // dzięki czemu i u nadawcy jak i u odbiorcy czas dokładnie się zgadza.
        // Jednakże, jeżeli ktoś będzie chciał chciał dodatkowo wykorzystać ten parametr, należy będzie
        // stworzyć interpreter który oddzieli informacje o czasie, jakiejś dodatkowej rzeczy
        // i ich nie pomyli. W przeciwnym wypadku będzie walić błędami.

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (trafficController.GetState() == State.OpenedGate && !TextBoxMessage.Text.Equals(""))
            {
                messageSendTime = DateTime.Now;

                /// Wysyłanie konkretnej wiadomości do kontaktu, z którym mamy otwartego gate'a
                trafficController.SMSSend(nr.ToString(), null, TextBoxMessage.Text, "", "" + messageSendTime);
                messageSend = true;
            }
            else MessageBox.Show("Nie wybrałeś kontaktu, do którego chcesz wysłać wiadomość!");
        }

        private void SendButton_MouseEnter(object sender, MouseEventArgs e)
        {
           
            send.Source = new BitmapImage(new Uri(@"/Images/ChatPage/WyslijAW.png", UriKind.Relative));
            send.Stretch = Stretch.None;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            clip.Source = new BitmapImage(new Uri(@"/Images/ChatPage/clipWhite.png", UriKind.Relative));
            clip.Stretch = Stretch.None;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            clip.Source = new BitmapImage(new Uri(@"/Images/ChatPage/clipSilver.png", UriKind.Relative));
            clip.Stretch = Stretch.None;
        }

        private void SendButton_LostFocus(object sender, RoutedEventArgs e)
        {
            send.Source = new BitmapImage(new Uri(@"/Images/ChatPage/wyslijAqua.png", UriKind.Relative));
            send.Stretch = Stretch.None;
        }

        private void SendButton_MouseLeave(object sender, MouseEventArgs e)
        {
            send.Source = new BitmapImage(new Uri(@"/Images/ChatPage/wyslijAqua.png", UriKind.Relative));
            send.Stretch = Stretch.None;
        }

        private void EmotikonaButton_MouseEnter(object sender, MouseEventArgs e)
        {
            emotikona.Source = new BitmapImage(new Uri(@"/Images/ChatPage/emotikonaWhite.png", UriKind.Relative));
            emotikona.Stretch = Stretch.None;
        }

        private void EmotikonaButton_MouseLeave(object sender, MouseEventArgs e)
        {
            emotikona.Source = new BitmapImage(new Uri(@"/Images/ChatPage/emotikonaSilver.png", UriKind.Relative));
            emotikona.Stretch = Stretch.None;
        }
    }
}


