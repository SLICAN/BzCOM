using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Win32;
using Notifications.Wpf;
using RDPCOMAPILib;
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
        //private bool upload;

        string szyfr = "3t6w9z$C&E)H@McQ";
        string szyfr2 = "St6w9z$C&E)H@McS";
        public DateTime messageSendTime; // Zmienna pod dokładny czas wysłania wiadomości.
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "BzCom";
        string confSzyfr = "xxxcoco";

        #region Udostepnianie Ekranu
        ScreenViewer xy;
        RDPSession x;

        private void Incoming(object Guest)
        {
            IRDPSRAPIAttendee MyGuest = (IRDPSRAPIAttendee)Guest;//???
            MyGuest.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
        }

        private void ButtonHost_Click(object sender, RoutedEventArgs e)
        {
            x = new RDPSession();
            x.OnAttendeeConnected += Incoming;
            x.Open();
            IRDPSRAPIInvitation Invitation = x.Invitations.CreateInvitation("Trial", "MyGroup", "", 10);
            //ButtonHost.Visibility = Visibility.Hidden;
            //ButtonStopHost.Visibility = Visibility.Visible;

            if (trafficController.GetState() == State.OpenedGate)
            {
                messageSendTime = DateTime.Now;
                /// Wysyłanie konkretnej wiadomości do kontaktu, z którym mamy otwartego gate'a
                TextBoxMessage.Text = "Plik wysłany";
                trafficController.SMSSend(nr.ToString(), null, szyfr2 + Invitation, "", "" + messageSendTime);
                messageSend = true;

            }

        }

        private void ButtonHost_MouseEnter(object sender, MouseEventArgs e)
        {
            //send.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/screenSilver.png", UriKind.Relative));
            //send.Stretch = Stretch.None;
        }

        private void ButtonHost_MouseLeave(object sender, MouseEventArgs e)
        {
            //clip.Source = new BitmapImage(new Uri(@"/Images/GrafikiMenu/screenSilver.png", UriKind.Relative));
           // clip.Stretch = Stretch.None;
        }

        private void ButtonStopHost_Click(object sender, RoutedEventArgs e)
        {
            x.Close();
            x = null;
            //ButtonHost.Visibility = Visibility.Visible;
            //ButtonStopHost.Visibility = Visibility.Hidden;
        }

        public void OpenViewer(string Invitation) {
            try
            {
                string inv = Invitation;
                xy = new ScreenViewer();
                xy.Connection(inv);// Do ogarnięcia - wychodzi poza zakres ??? 
                xy.Show();
            }
            catch (ArgumentException)
            {
                //textBox_Link.Text = "Błędne zaproszenie";
            }
        }

        #endregion

        public ChatPage(int _nr, int _myNumber)
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


        private void LoadMessages(List<Message> messages)
        {
            foreach (Message message in messages)
            {
                if (message.Text.Contains(confSzyfr) || message.Text.Contains("CONVERSATION")) { }
                else
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
            if (nr == msgNow.Number)
            {
                bool zawiera = false;
                bool zawiera2 = false;
                if (msgNow.Text.Contains(confSzyfr))
                {
                    
                }
                else
                {
                    if (msgNow.Text.Contains(szyfr) ) { zawiera = true; } //|| msgNow.Text.Contains("CONVERSATION")
                    if (msgNow.Text.Contains(szyfr2) ) { zawiera2 = true; } //|| msgNow.Text.Contains("CONVERSATION")
                    Console.WriteLine(zawiera);
                    if (zawiera == true)
                    {
                        msgNow.Text = msgNow.Text.Replace(szyfr, "");
                        TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text, msgNow.DateTime, true);
                    }
                    if (zawiera2 == true)
                    {
                        msgNow.Text = msgNow.Text.Replace(szyfr2, "");
                        TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text, msgNow.DateTime, false , true);
                    }
                    if (zawiera == false) { TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text, msgNow.DateTime); }
                }

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
        public void TypeText(string who, string message, DateTime datatime, bool hyper = false, bool inv = false)
        {
            //Chat.Text += who + " : " + message;        
            if (hyper == true) { SetHyperlink((who + ": " + datatime + "\n" + "?" + message + "\n")); }
            else if (inv == true) { SetHyperlink2((who + ": " + datatime + "\n" + "?" + message + "\n")); }
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
                    borderOkienka.Background = new SolidColorBrush(Color.FromRgb(3, 145, 253));
                    borderOkienka.HorizontalAlignment = HorizontalAlignment.Right;
                }
                else {
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

                string[] lines = text.Split(new Char[] { '?', '!' });
                //int index = text.IndexOf("?");
                //int lastindex = text.- 1;
                //Console.WriteLine(index);
                //string text1 = text.Substring(0, index);
                //string hiperlink = text.Substring(index + 1, lastindex);
                string folderName = nr.ToString() + "_" + mynumber.ToString();
                var h = new Hyperlink();
                h.Inlines.Add(lines[1]);
                h.Click += (s, a) => { download(lines[1], folderName); };
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
        private void SetHyperlink2(string text)
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

                string[] lines = text.Split(new Char[] { '?', '!' });
                //int index = text.IndexOf("?");
                //int lastindex = text.- 1;
                //Console.WriteLine(index);
                //string text1 = text.Substring(0, index);
                //string hiperlink = text.Substring(index + 1, lastindex);
                Console.WriteLine(lines[1]);
                var h = new Hyperlink();
                h.Inlines.Add(lines[1]);
                Console.WriteLine(lines[1]);
                h.Click += (s, a) => { OpenViewer(lines[1]); };
                TextBlock textBlock = new TextBlock();
                textBlock.TextWrapping = TextWrapping.Wrap;
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
            CheckFolderDriveExist(service, mynumber.ToString());
            string spath = "";
            string typ = "";
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
            UploadToDrive(service, filename, spath, typ, folder_id);
            Console.WriteLine("Nazwa " + folder_id);
            Console.WriteLine("Typ " + typ);


            if (trafficController.GetState() == State.OpenedGate)
            {
                messageSendTime = DateTime.Now;
                /// Wysyłanie konkretnej wiadomości do kontaktu, z którym mamy otwartego gate'a

                TextBoxMessage.Text = "Plik wysłany";
                trafficController.SMSSend(nr.ToString(), null, szyfr + filename, "", "" + messageSendTime);
                messageSend = true;

            }
           DeleteAfter30(service);

        }



        //GOOGLE DRIVE

        public string ExtenionsForMimeType(string type)
        {
            if (type == ".jpg")
            {
                return "image/jpeg";
            }
            else if (type == ".png")
            {
                return "image/png";
            }
            else if (type == ".svg")
            {
                return "image/svg+xml";
            }
            else if (type == ".pdf")
            {
                return "application/pdf";
            }
            else if (type == ".txt")
            {
                return "text/plain";
            }
            else if (type == ".doc")
            {
                return "application/vnd.openxmlformats-officedocument.wordprocessingml.document ";
            }
            else if (type == ".odt")
            {
                return "application/vnd.oasis.opendocument.text";
            }
            else if (type == ".rtf")
            {
                return "application/rtf";
            }
            else if (type == ".csv")
            {
                return "text/csv";
            }
            else if (type == ".json")
            {
                return "application/vnd.google-apps.script+json";
            }
            else
            {
                return "text/plain";
            }
        }

        private void UploadToDrive(DriveService service, string file_to_upload, string path, string type, string folder)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = file_to_upload,
                Parents = new List<string> { folder }
            };
            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
            {
                if (type == ".jpg")
                {
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

        private string CheckFolderDriveExist(DriveService service, string folderName)
        {

            string folderid = "";
            FilesResource.ListRequest listRequest = service.Files.List();

            listRequest.PageSize = 600;
            listRequest.Fields = "nextPageToken, files(id, name)";

            bool exist = false;
            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;

            if (files.Count == 0)
            {
                folderid = CreateFolderDrive(service, folderName);
                return folderid;
            }
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (folderName == file.Name) { exist = true; folderid = file.Id; return folderid; }


                }
                if (exist == false) { folderid = CreateFolderDrive(service, folderName); return folderid; }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            return folderid;

        }

        private string GetIDFolder(DriveService service, string foldername)
        {
            string folderid = "";
            FilesResource.ListRequest listRequest = service.Files.List();

            listRequest.Q = "mimeType='application/vnd.google-apps.folder'";
            listRequest.PageSize = 600;
            listRequest.Fields = "nextPageToken, files(id, name)";


            bool exist = false;
            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (foldername == file.Name) {
                        exist = true; folderid = file.Id; return folderid; }

                }
                if (exist == false) { }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            return folderid;
        }

        public void download(string file, string folderName_)
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
            }
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            string FileId;
            string folderNameID = GetIDFolder(service, mynumber.ToString());
            //MOZE TUTAJ FOLDER PODMIENIC
            CheckFolderDriveExist(service, mynumber.ToString());
            bool movebool = true;
            if (CheckFileinFolderExist(service, file, folderNameID) == true)
             {
                 FileId = GetIDFile(service, file, mynumber.ToString());
                 movebool = false;
             }
            else { FileId = GetIDFile(service, file, folderName_); }
            //FileId = GetIDFile(service, file, folderName_);
            Console.WriteLine("MOVE BOOL " + movebool);

            string spath = "";
            file = file.Remove(file.Length - 1, 1);
            string typ_ = "";
            typ_ = System.IO.Path.GetExtension(file);
            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.Filter = CheckExtensionForSaveDialog(typ_);
            fileDialog.FileName = file;
            fileDialog.AddExtension = true;

            Nullable<bool> dialogOK = fileDialog.ShowDialog();

            if (dialogOK == true)
            {
                spath = fileDialog.FileName;
            }


            GetFileFromDrive(service, FileId, spath);

            Console.WriteLine("ID after download " + folderName_);
            string done = move(service, FileId, folderNameID, folderName_, movebool);
            Console.WriteLine(done);
        }


        public string move(DriveService service, string fileid, string folderid, string folderToDelete, bool move = true)
        {
            if (move == true)
            {
                var request = service.Files.Get(fileid);
                request.Fields = "parents";
                var file = request.Execute();
                string previousParents = String.Join(",", file.Parents);

                var updateRequest = service.Files.Update(new Google.Apis.Drive.v3.Data.File(), fileid);
                updateRequest.Fields = "id,parents";
                updateRequest.AddParents = folderid;
                updateRequest.RemoveParents = previousParents;
                file = updateRequest.Execute();
                folderToDelete = GetIDFolder(service, folderToDelete);
                if (file != null)
                {
                    service.Files.Delete((folderToDelete)).Execute();

                    return "Success";
                }
                else
                {
                    return "Fail";
                }
            }
            else { return "Nie wymagało przesunięcia"; }
        }


        public string CheckExtensionForSaveDialog(string extesion)
        {
            if (extesion == ".jpg" || extesion == ".bmp" || extesion == ".png")
            {
                return extesion = "jpg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";
            }
            if (extesion == ".png")
            {
                return extesion = "PDF File|*.pdf";
            }
            if (extesion == ".doc")
            {
                return extesion = "Doc File|*.doc";
            }
            if (extesion == ".odt")
            {
                return extesion = "Odt File|*.odt";
            }
            if (extesion == ".txt")
            {
                return extesion = "Text File|*.txt";
            }
            else
            {
                return extesion = "Nieznany typ|*.exe";
            }
        }


        public bool CheckFileinFolderExist(DriveService service, string filename, string FolderID)
        {

            filename = filename.Remove(filename.Length - 1, 1);

            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 600;
            listRequest.Fields = "nextPageToken, files(id, name,parents)";

            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
               .Files;


            FilesResource.ListRequest folderRequest = service.Files.List();

            folderRequest.Q = "mimeType='application/vnd.google-apps.folder'";
            folderRequest.PageSize = 600;
            folderRequest.Fields = "nextPageToken, files(id, name)";
            IList<Google.Apis.Drive.v3.Data.File> folders = folderRequest.Execute()
              .Files;


            List<String> FoldersExist = new List<string>();
            List<String[]> FilesExist = new List<string[]>();

      
            if (files.Count == 0)
            {
                Console.WriteLine("Nie istenieje żaden plik");
            }

            if(files != null && files.Count > 0)
            {
                foreach(var file in files)
                {
                    string[] s = { file.Name, file.Id, file.Parents[0] };
                    FilesExist.Add(s);
                }
            }

            if(folders != null && folders.Count > 0)
            {
                foreach ( var folder in folders)
                {
                    FoldersExist.Add(folder.Id);
                }
            }

             for (int i = 0; i < FilesExist.Count; i++)
                {
                    foreach (var folder in FoldersExist)
                    {
                        if (FilesExist[i][1].Equals(folder))
                        {
                            FilesExist.Remove(FilesExist[i]);
                        }
                    }
                }

            for (int i = 0; i < FoldersExist.Count;)
            {
                if (FoldersExist[i].Equals(FolderID))
                {
                    i++;
                }
                else
                {
                    
                    FoldersExist.Remove(FoldersExist[i]);
                    i = 0;

                }
            }
            for (int i = 0; i < FoldersExist.Count; i++)
            {
                for (int j = 0; j < FilesExist.Count; j++)
                {
                    if(FilesExist[j][0].Equals(filename) && FilesExist[j][2].Equals(FoldersExist[i]))
                    {
                        return true;
                    }
                       
                }
            }
            return false;
        }


        public void GetFileFromDrive(DriveService service , string FileId, string where)
        {
            var request = service.Files.Get(FileId);
            var stream = new System.IO.MemoryStream();
            request.MediaDownloader.ProgressChanged +=
                (IDownloadProgress progress) =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                            {
                                Console.WriteLine(progress.BytesDownloaded);
                                break;
                            }
                        case DownloadStatus.Completed:
                            {
                                Console.WriteLine("Download complete.");
                                SaveStream(stream, where);
                                break;
                            }
                        case DownloadStatus.Failed:
                            {
                                Console.WriteLine("Download failed.");
                                break;
                            }
                    }
                };
            request.Download(stream);
        }

        private static void SaveStream(System.IO.MemoryStream stream, string saveTo)
        {
            using (System.IO.FileStream file = new System.IO.FileStream(saveTo, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                stream.WriteTo(file);
            }
        }


        public string GetIDFile(DriveService service, string filename,string folderName)
        {
            filename = filename.Remove(filename.Length - 1, 1);
            string fileid = "";
            FilesResource.ListRequest listRequest = service.Files.List();

            listRequest.PageSize = 600;
            listRequest.Fields = "nextPageToken, files(id, name,parents)";
     
            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;


            FilesResource.ListRequest folderRequest = service.Files.List();

            folderRequest.Q = "mimeType='application/vnd.google-apps.folder'";
            folderRequest.PageSize = 600;
            folderRequest.Fields = "nextPageToken, files(id, name)";
            IList<Google.Apis.Drive.v3.Data.File> folders = folderRequest.Execute()
              .Files;

            Console.WriteLine("Files:");
            if (files.Count == 0)
            {
                Console.WriteLine("Nie istenieje żaden plik");
            }

            if (folders != null && folders.Count > 0)
            {
                string FolderID = GetIDFolder(service, folderName);
                Console.WriteLine("Folder ID in fileID " + FolderID);
                foreach (var folder in folders)
                {
                    Console.WriteLine("foler.id" + folder.Id);
                    if (FolderID.Equals(folder.Id))
                    {
                        if (files != null && files.Count > 0)
                        {
                            foreach (var file in files)
                            {
                                if (filename.Equals(file.Name))
                                {
                                    fileid = file.Id;
                                    return fileid;
                                }
                               
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            return fileid;
        }

        public class SampleHelpers
        {

            public static object ApplyOptionalParms(object request, object optional)
            {
                if (optional == null)
                    return request;

                System.Reflection.PropertyInfo[] optionalProperties = (optional.GetType()).GetProperties();

                foreach (System.Reflection.PropertyInfo property in optionalProperties)
                {
                    // Copy value from optional parms to the request.  They should have the same names and datatypes.
                    System.Reflection.PropertyInfo piShared = (request.GetType()).GetProperty(property.Name);
                    piShared.SetValue(request, property.GetValue(optional, null), null);
                }
                return request;
            }
        }

        public class FilesListOptionalParms
        {
            /// The source of files to list.
            public string Corpus { get; set; }

            /// A comma-separated list of sort keys. Valid keys are 'createdTime', 'folder', 'modifiedByMeTime', 'modifiedTime', 'name', 'quotaBytesUsed', 'recency', 'sharedWithMeTime', 'starred', and 'viewedByMeTime'. Each key sorts ascending by default, but may be reversed with the 'desc' modifier. Example usage: ?orderBy=folder,modifiedTime desc,name. Please note that there is a current limitation for users with approximately one million files in which the requested sort order is ignored.
            public string OrderBy { get; set; }

            /// The maximum number of files to return per page.
            public int PageSize { get; set; }

            /// The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response.
            public string PageToken { get; set; }

            /// A query for filtering the file results. See the "Search for Files" guide for supported syntax.
            public string Q { get; set; }

            /// A comma-separated list of spaces to query within the corpus. Supported values are 'drive', 'appDataFolder' and 'photos'.
            public string Spaces { get; set; }
        }
        public static Google.Apis.Drive.v3.Data.FileList DeleteAfter30(DriveService service, FilesListOptionalParms optional = null)
        {
            DateTime ThirtyDayBeforeToday = DateTime.Now.AddDays(-30);
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");

                // Building the initial request.
                var request = service.Files.List();

                // Applying optional parameters to the request.
                request.Fields = "nextPageToken, files(createdTime ,id, name, mimeType)";

                var pageStreamer = new Google.Apis.Requests.PageStreamer<Google.Apis.Drive.v3.Data.File, FilesResource.ListRequest, Google.Apis.Drive.v3.Data.FileList, string>(
                                                   (req, token) => request.PageToken = token,
                                                   response => response.NextPageToken,
                                                   response => response.Files);

                var allFiles = new Google.Apis.Drive.v3.Data.FileList();
                allFiles.Files = new List<Google.Apis.Drive.v3.Data.File>();

                foreach (var result in pageStreamer.Fetch(request))
                {

                    if (result.MimeType != "application/vnd.google-apps.folder")
                    {
                        if (result.CreatedTime < ThirtyDayBeforeToday) { service.Files.Delete(result.Id).Execute(); }
                        else { Console.WriteLine("Data sie zgdza"); }
                    }
                    else { Console.WriteLine("Nie usunięto"); }
                }
                return allFiles;
            }
            catch (Exception Ex)
            {
                throw new Exception("Request Files.List failed.", Ex);
            }
        }




        private void Konwersacja_Button(object sender, RoutedEventArgs e)
        {
           
        }

        private void TextBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
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
        }

       
    }
}


