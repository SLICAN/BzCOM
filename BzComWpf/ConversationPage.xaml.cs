using System;
using System.Collections.Generic;
using System.IO;
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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Win32;

namespace BzCOMWpf
{

    /// <summary>
    /// Logika interakcji dla klasy Chat.xaml
    /// </summary>
    public partial class ConversationPage : Page
    {
        private int mynumber;
        private int nr;
        public int[] conversation_numbers;
        public List<string> users_names;
        private TrafficController trafficController = TrafficController.TrafficControllerInstance;
        delegate void SetTextCallBack(string text);
        delegate void SetScrollCallBack();
        private bool messageSend = false;
        //private bool upload;
        string szyfr = "xxxcoco";
        public DateTime messageSendTime; // Zmienna pod dokładny czas wysłania wiadomości.
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "BzCom";


        public int Mynumber { get { return mynumber; } }



        public ConversationPage(int[] numbers, int _myNumber)
        {
            conversation_numbers = numbers;
            /*for (int i = 0; i < conversation_numbers.Length; i++)
            {
                Console.WriteLine(conversation_numbers[i]);
            }*/

            mynumber = _myNumber;
            InitializeComponent();
            Title = "Konwersacja";
            trafficController.OnSuccessMessageSend += TrafficController_OnSuccessMessageSend;
            trafficController.OnMessageReceived += TrafficController_OnMessageReceived;
            LoadMessages(trafficController.GetMessagesByNumber(nr));
        }

        private void LoadMessages(List<Message> messages)
        {
            foreach (Message message in messages)
            {
                if (message.IsMine)
                {
                    TypeText("Ja", message.Text, message.DateTime);
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
                    TypeText("Ja", TextBoxMessage.Text, messageSendTime);
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
            if (msgNow.Number != mynumber)
            {
                if (msgNow.Text.Contains(szyfr))
                {
                    bool zawiera = false;
                    if (msgNow.Text.Contains(szyfr)) { zawiera = true; }
                    Console.WriteLine(zawiera);
                    if (zawiera == true)
                    {
                        //msgNow.Text = msgNow.Text.Replace(szyfr, "");
                        TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text.Replace(szyfr,""), msgNow.DateTime, false);
                    }
                    if (zawiera == false) { TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text, msgNow.DateTime); }
                }
                else { }
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
        public void TypeText(string who, string message, DateTime datatime, bool hyper = false)
        {
            //Chat.Text += who + " : " + message;        
            if (hyper == true) { SetHyperlink((who + ": " + datatime + "\n" + "?" + message + "\n")); }
            else
            {
                SetTextHTML(who + ": " + datatime + "\n" + "" + message + "\n");
            }
            //  SetTextHTML("" + message + "\n");
            //   SetTextHTML("");
            /*
            Border borderJa = new Border();
            borderJa.Background = new SolidColorBrush(Color.FromRgb(65, 174, 207));
            borderJa.CornerRadius = new CornerRadius(4);
            borderJa.BorderThickness = new Thickness(1);      
            TextBlock textBlock = new TextBlock();
            textBlock.Text = Convert.ToString(who+": "+ datatime + "\n"+"" + message +"\n");
            borderJa.Child = textBlock;
            stackPanelBorder.Children.Add(borderJa);
            */
            //SetScroll();
        }
        private void SetTextHTML(string text)
        {
            if (Chat.Dispatcher.Thread == Thread.CurrentThread)
            {

                //   Chat.Text += text;
                // Chat.Text = Chat.Text + text;
                Border borderOkienka = new Border();
                if (text.Substring(0, 2) == "Ja")
                {
                    borderOkienka.Background = new SolidColorBrush(Color.FromRgb(65, 174, 207));
                    borderOkienka.HorizontalAlignment = HorizontalAlignment.Right;
                }
                else
                {
                    borderOkienka.Background = new SolidColorBrush(Color.FromRgb(68, 68, 68));
                    borderOkienka.HorizontalAlignment = HorizontalAlignment.Left;

                }

                borderOkienka.CornerRadius = new CornerRadius(4);
                borderOkienka.BorderThickness = new Thickness(1);

                //b.BorderThickness = new Thickness{Top=1, Bottom=0, Left=1, Right=1}; 

                TextBlock textBlock = new TextBlock();
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Text += text;
                textBlock.Foreground = new SolidColorBrush(Colors.White);
                borderOkienka.Child = textBlock;
                stackPanelBorder.Children.Add(borderOkienka);
            }
            else
            {
                Console.WriteLine("SetTextHTML");
                SetTextCallBack f = new SetTextCallBack(SetTextHTML);
                Dispatcher.Invoke(f, new object[] { text });
            }
        }


        private void SetHyperlink(string text)
        {
            if (Chat.Dispatcher.Thread == Thread.CurrentThread)
            {

                Border borderOkienka = new Border();
                if (text.Substring(0, 2) == "Ja")
                {
                    borderOkienka.Background = new SolidColorBrush(Color.FromRgb(3, 145, 253));
                    borderOkienka.HorizontalAlignment = HorizontalAlignment.Right;
                }
                else
                {
                    borderOkienka.Background = new SolidColorBrush(Color.FromRgb(68, 68, 68));
                    borderOkienka.HorizontalAlignment = HorizontalAlignment.Left;

                }

                borderOkienka.CornerRadius = new CornerRadius(4);
                borderOkienka.BorderThickness = new Thickness(1);

                string[] lines = text.Split(new Char[] { '?', '!' });
                //int index = text.IndexOf("?");
                //int lastindex = text.- 1;
                //Console.WriteLine(index);
                //string text1 = text.Substring(0, index);
                //string hiperlink = text.Substring(index + 1, lastindex);
                string folderName = nr.ToString() + "_" + mynumber.ToString();
                //var h = new Hyperlink();
                //h.Inlines.Add(lines[1]);
                //h.Click += (s, a) => { download(lines[1], folderName); };
                TextBlock textBlock = new TextBlock();
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Inlines.Add(lines[0]);
                //textBlock.Inlines.Add(h);
                textBlock.Foreground = new SolidColorBrush(Colors.White);
                borderOkienka.Child = textBlock;
                stackPanelBorder.Children.Add(borderOkienka);
            }
            else
            {
                Console.WriteLine("SetTextHTML");
                SetTextCallBack f = new SetTextCallBack(SetHyperlink);
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

            conversation_numbers = conversation_numbers.Where(val => val != mynumber).ToArray();
        
            for (int i = 0; i < conversation_numbers.Length; i++)
            {
                if (trafficController.GetState() == State.OpenedGate && !TextBoxMessage.Text.Equals(""))
                {
                    messageSendTime = DateTime.Now;
                  
                    /// Wysyłanie konkretnej wiadomości do kontaktu, z którym mamy otwartego gate'a
                    trafficController.SMSSend(conversation_numbers[i].ToString(), null, szyfr + TextBoxMessage.Text, "", "" + messageSendTime);
                    messageSend = true;
                }
                else MessageBox.Show("Nie wybrałeś kontaktu, do którego chcesz wysłać wiadomość!");
            }
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

     


        //Gooogle Drive transfer plikow


        private void ClipButton_Click(object sender, RoutedEventArgs e)
        {


        }

        private void TextBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                conversation_numbers = conversation_numbers.Where(val => val != mynumber).ToArray();

                for (int i = 0; i < conversation_numbers.Length; i++)
                {
                    if (trafficController.GetState() == State.OpenedGate && !TextBoxMessage.Text.Equals(""))
                    {
                        messageSendTime = DateTime.Now;

                        /// Wysyłanie konkretnej wiadomości do kontaktu, z którym mamy otwartego gate'a
                        trafficController.SMSSend(conversation_numbers[i].ToString(), null, szyfr + TextBoxMessage.Text, "", "" + messageSendTime);
                        messageSend = true;
                    }
                    else MessageBox.Show("Nie wybrałeś kontaktu, do którego chcesz wysłać wiadomość!");
                }
            }
        }
    }
    
}


