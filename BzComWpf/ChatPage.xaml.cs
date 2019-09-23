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
    public partial class ChatPage : Page
    {
        public int mynumber;
        public int nr;
        private TrafficController trafficController = TrafficController.TrafficControllerInstance;
        delegate void SetTextCallBack(string text);
        delegate void SetScrollCallBack();
        private bool messageSend = false;
        private bool upload = false;
        static string token = "AIzaSyDiVSBxUhhiAJopIvM3oEQ1PuYwyOje4EQ";
        public DateTime messageSendTime; // Zmienna pod dokładny czas wysłania wiadomości.
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "BzCom";

        

        public ChatPage(int _nr,int _myNumber)
        {
           
            nr = _nr;
            mynumber = _myNumber;
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

        private void UploadToDrive(DriveService service, string file_to_upload,string path,string type,string folder)
        {
            

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = file_to_upload,
                Parents = new List<string> { folder}
            };
            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
            {
                if (type == ".jpg"){
                    request = service.Files.Create(fileMetadata, stream, "image/jpeg");
                }
                else if (type == ".png")
                {
                    request = service.Files.Create(fileMetadata, stream, "image/png");
                }
                else if (type == ".svg")
                {
                    request = service.Files.Create(fileMetadata, stream, "image/svg+xml");
                }
                else if (type == ".pdf")
                {
                    request = service.Files.Create(fileMetadata, stream, "application/pdf");
                }
                else if (type == ".txt")
                {
                    request = service.Files.Create(fileMetadata, stream, "text/plain");
                }
                else if (type == ".doc")
                {
                    request = service.Files.Create(fileMetadata, stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document ");
                }
                else if (type == ".odt")
                {
                    request = service.Files.Create(fileMetadata, stream, "application/vnd.oasis.opendocument.text");
                }
                else if (type == ".rtf")
                {
                    request = service.Files.Create(fileMetadata, stream, "application/rtf");
                }
                else if (type == ".csv")
                {
                    request = service.Files.Create(fileMetadata, stream, "text/csv");
                }
                else if (type == ".json")
                {
                    request = service.Files.Create(fileMetadata, stream, "application/vnd.google-apps.script+json");
                }
                else
                {
                    request = service.Files.Create(fileMetadata, stream, "text/plain");
                }

                request.Fields = "id";
                request.Upload();
            }

            var file = request.ResponseBody;
            Console.WriteLine("File ID:" + file.Id);
        }

        private static string CreateFolderDrive(DriveService service, string folderName)
        {
            var file = new Google.Apis.Drive.v3.Data.File();
            file.Name = folderName;
            file.MimeType = "application/vnd.google-apps.folder";
            var request = service.Files.Create(file);
           
            request.Fields = "id";
            var result = request.Execute();
            return result.Id;
        }

        private string CheckFolderDriveExist(DriveService service , string folderName)
        {
            string folderid = "";
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 600;
            listRequest.Fields = "nextPageToken, files(id, name)";
            bool exist = false;
            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            Console.WriteLine("Files:");
            if(files.Count == 0)
            {
                folderid = CreateFolderDrive(service, folderName);
                Console.WriteLine("Hallloo " + folderid);
                return folderid;
            }
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (folderName == file.Name) { exist = true; folderid = file.Id; return folderid; }                                   
                    Console.WriteLine("{0} ({1}) {2}", file.Name, file.Id, exist);
                    
                }
                if (exist == false) { folderid = CreateFolderDrive(service, folderName); return folderid; }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            return folderid;

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
                    Console.WriteLine("SEND: " + upload.ToString());
                    //if (upload == true) { TypeText("Ja", TextBoxMessage.Text, messageSendTime,upload=true); }
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
            if (nr == msgNow.Number)
            {
                Console.WriteLine("RECIEVE: " + upload.ToString());
                if (upload == true) { TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text, msgNow.DateTime, true); }
                else { TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text, msgNow.DateTime); }
                upload = false;
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
        public void TypeText(string who, string message, DateTime datatime,bool hyper=false)
        {
            //Chat.Text += who + " : " + message;        
            if (hyper == true) { SetHyperlink((who + ": " + datatime + "\n" + "?" + message + "\n")); }
            else {
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
                else {
                    borderOkienka.Background = new SolidColorBrush(Color.FromRgb(68,68,68));
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

                string[] lines = text.Split(new Char[] { '?','!' });
                //int index = text.IndexOf("?");
                //int lastindex = text.- 1;
                //Console.WriteLine(index);
                //string text1 = text.Substring(0, index);
                //string hiperlink = text.Substring(index + 1, lastindex);

                var h = new Hyperlink();
                h.Inlines.Add(lines[1]);
                h.Click += (s, a) => { download(); };
                TextBlock textBlock = new TextBlock();
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Inlines.Add(lines[0]);
                textBlock.Inlines.Add(h);
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

        private void ClipButton_Click(object sender, RoutedEventArgs e)
        {
            UserCredential credential;
            using (var stream = new FileStream("credential.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);

            }
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            string spath="";
            string typ="";
            string filename = "";
            string folder_id = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            Nullable<bool> dialogOK = fileDialog.ShowDialog();
            if (dialogOK == true)
            {
                spath = fileDialog.FileName;
                typ = System.IO.Path.GetExtension(spath);
                filename = System.IO.Path.GetFileName(spath);

            }
            folder_id = CheckFolderDriveExist(service, mynumber.ToString() + "_" + nr.ToString());
            UploadToDrive(service, filename, spath, typ,folder_id);
            Console.WriteLine("Nazwa "+ folder_id);
            Console.WriteLine("Typ "+ typ);
            

            if (trafficController.GetState() == State.OpenedGate)
            {
                messageSendTime = DateTime.Now;
                /// Wysyłanie konkretnej wiadomości do kontaktu, z którym mamy otwartego gate'a
                TextBoxMessage.Text = "Plik wysłany";
                upload = true;
                trafficController.SMSSend(nr.ToString(), null, filename,"" , "" + messageSendTime);
                messageSend = true;
                
            }
            

        }
        public void download()
        {
            MessageBox.Show("Pobrano");
        }

        
        /// Tworzy folder uzytkownik_adresat wysyła tam plik , podczas downloadu wysyła do folderu uzytkownika i usuwa folder uzytkownik_adresat #BEDZIEKOZAK
       
    }
}


