using ChatTest.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace ChatTest
{
    public partial class AddressBookForm : Form
    {
        public string currentNumber;

        private int CursorPosition;

        private ListViewItem iteam;

        delegate void SetUsersCallBack(List<User> users);

        delegate void SetTextCallBack(string text);

        delegate void SetScrollCallBack();

        public TrafficController trafficController = new TrafficController();

        private MessageForm messageForm = new MessageForm();

        private Logger logger = new Logger();

        private PopUpForm popUpForm = new PopUpForm();

        private bool loggerActive = false;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public AddressBookForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));

            timer1.Tick += new EventHandler(timer1_Tick);

            trafficController.OnMessageReceived += TrafficController_OnMessageReceived;
            trafficController.OnUpdateStatus += TrafficController_OnUpdateStatus;
            //trafficController.OnLoggedIn += TrafficController_OnLoggedIn;
            trafficController.OnAddressBookGet += TrafficController_OnAddressBookGet;
            trafficController.OnSuccess += TrafficController_OnSuccess;
            trafficController.OnDeadConnection += TrafficController_OnDeadConnection;
            trafficController.OnSetConnection += TrafficController_OnSetConnection;
            logger.OnLoggerMessage += Logger_OnLoggerMessage;

            foreach (var item in Enum.GetValues(typeof(Status)))
            {
                if (item.ToString() != Status.UNKNOWN.ToString())
                    ComboBoxStatus.Items.Add(item);
            }
        }

        private void TrafficController_OnSetConnection(TrafficController sender)
        {
            SetText("Udało się ustanowić połączenie z serwerem.");
            SetText("Proszę się zalogować.");
        }

        private void TrafficController_OnDeadConnection(TrafficController sender)
        {
            SetText("Brak odpowiedzi z serwera.");
            SetText("Sprawdź czy masz połączenie z Internetem lub zgłoś awarię do administratora.");
            SetText("Aplikacja zamknie się za 10 sekund");
            var sleep = 10000;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds <= sleep)
            {
                SetText((10 - Convert.ToInt32(stopwatch.ElapsedMilliseconds / 1000)).ToString());
                Thread.Sleep(1000);
            }
            Application.Exit();
            //ListViewAddressBook.Clear();
        }

        private void TrafficController_OnSuccess(TrafficController sender, bool error)
        {
            if (!error)
            {
                //TypeText("ja", TextBoxMessage.Text, DateTime.Now);
            }
            else
                SetText("Nie udało się wysłać wiadomości");
        }

        private void TrafficController_OnAddressBookGet(TrafficController sender, List<User> users)
        {
            SetBook(users);
            /// Manages the initial import of statuses and description
            SetColor(trafficController.SetColor(users));
            /// Register sms module
            trafficController.RegisterToModules();

        }

        //private void TrafficController_OnLoggedIn(TrafficController sender, string info)
        //{
        //    SetText(info);
        //    /// Changes the status displayed in combobox, when you logged in
        //    if (trafficController.GetState() == State.LoggedIn)
        //    {
        //        ChangeComboBox(Status.AVAILABLE.ToString());
        //    }

        //    /// Manages the initial import of the adress book and statuses
        //    trafficController.GetUsers();
        //}

        /// <summary>
        /// Ustaw wiadomości z loggera, jeśli logowanie ustawiono na aktywne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        private void Logger_OnLoggerMessage(Logger sender, string msg)
        {
            if (loggerActive)
                SetText(msg);
        }

        /// <summary>
        /// Edytuj książkę i ustaw odpowiedni kolor - otrzymano zmianę statusu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="users"></param>
        private void TrafficController_OnUpdateStatus(TrafficController sender, List<User> users)
        {
            EditBook(users);
            foreach (var item in users)
            {
                if (item.UserState != Status.UNKNOWN)
                    SetColor(trafficController.SetColor(users));
            }
        }

        /// <summary>
        /// Wpisz na formatkę otrzymaną wiadomość i uruchom popUpForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msgNow"></param>
        private void TrafficController_OnMessageReceived(TrafficController sender, Message msgNow)
        {
            messageForm.TypeText(trafficController.FindName(msgNow.Number.ToString()), msgNow.Text, msgNow.DateTime);

            if (CheckOpened(messageForm.Text))
            {
                //MessageBox.Show("OTWARTE OKNO");
            }
            else
            {
                //MessageBox.Show("NIE OTWARTE OKNO");
                timer1.Enabled = true;
                popUpForm.labelWho.Text = trafficController.FindName(msgNow.Number.ToString());
                popUpForm.labelWhat.Text = msgNow.Text;
                popUpForm.ShowDialog();
            }
            //timer1.Enabled = true;
            //popUpForm.labelWho.Text = trafficController.FindName(msgNow.Number.ToString());
            //popUpForm.labelWhat.Text = msgNow.Text;
            //popUpForm.ShowDialog();
        }

        private void timer1_Tick(object Sender, EventArgs e)
        {
            // Set the caption to the current time.  
            Console.WriteLine("Tick");
            popUpForm.Hide();
            timer1.Enabled = false;
        }

        

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            messageForm.webBrowser11.Navigate("about:blank");
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    try
                    {
                        sw.Write(messageForm.webBrowser11.DocumentText);
                    }
                    catch
                    {
                        MessageBox.Show("Nie można zapisać pliku: " + saveFileDialog1.FileName);
                    }
            }
        }

        
        /// <summary>
        /// Wyślij chęć zmiany opisu na serwer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate) && e.KeyChar == (char)13)
                trafficController.SetDescription(ComboBoxStatus.Text, TextBoxDescription.Text);

        }

        /// <summary>
        /// Symuluje hint'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDescription_Enter(object sender, EventArgs e)
        {
            if (TextBoxDescription.Text == "Wpisz i naciśnij enter")
            {
                TextBoxDescription.Text = "";
                TextBoxDescription.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Symuluje hint'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDescription_Leave(object sender, EventArgs e)
        {
            if (TextBoxDescription.Text == "")
            {
                TextBoxDescription.Text = "Wpisz i naciśnij enter";
                TextBoxDescription.ForeColor = Color.Silver;
            }
        }

        /// <summary>
        /// Podwójne kliknięcie na danym kontakcie otwiera z nim rozmowę, numer telefonu zostaje zapisany jako bieżący
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewAddressBook_DoubleClick(object sender, EventArgs e)
        {
            if (trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate)
            {
            ListViewItem selectedItem = ListViewAddressBook.SelectedItems[0];
            currentNumber = trafficController.FindNumber(selectedItem.SubItems[1].Text);
            var temp = ListViewAddressBook.FocusedItem.ListView;
            trafficController.SetState(State.OpenedGate);
            SetText($"Rozmowa z {selectedItem.SubItems[1].Text}");
                //if (CheckOpened(messageForm.Text))
                //{
                //    MessageBox.Show("Juz otwarte");
                //    //messageForm.Dispose();
                //    messageForm.Show();
                //}
                //else {
                //    messageForm.Show();
                //}
                messageForm.labelWho.Text = "Rozmowa z " + selectedItem.SubItems[1].Text;
                messageForm.Show();
                messageForm.trafficController = trafficController;
                messageForm.nr = currentNumber;
            }
            else
            SetText("Najpierw musisz ustanowić połączenie!");
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Wyślij informacje o zmianie statusu na serwer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trafficController.GetState() == State.LoggedIn || trafficController.GetState() == State.OpenedGate)
                trafficController.SetStatus((Status)Enum.Parse(typeof(Status), ComboBoxStatus.Text));
        }

        /// <summary>
        /// Ustaw tekst na oknie informacyjnym (loggerze)
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            //if (ListBoxLogger.InvokeRequired)
            //{
            //    SetTextCallBack f = new SetTextCallBack(SetText);
            //    this.Invoke(f, new object[] { text });
            //}
            //else
            //{
            //    ListBoxLogger.Items.Add(text);
            //    ListBoxLogger.TopIndex = ListBoxLogger.Items.Count - 1;
            //}
        }

        /// <summary>
        /// Ustaw książkę, ukryj pierszą kolumnę 
        /// (będzie ona służyła tylko do rozpoznawania statusów w kodzie, 
        /// w interfejsie status będzie rozróżniany poprzez kolory)
        /// </summary>
        /// <param name="bookList"></param>
        private void SetBook(List<User> bookList)
        {
            if (ListViewAddressBook.InvokeRequired)
            {
                SetUsersCallBack f = new SetUsersCallBack(SetBook);
                Invoke(f, new object[] { bookList });
            }
            else
            {
                ListViewAddressBook.View = View.Details;


                int itemHeight = 20;
                ImageList imgList = new ImageList();
                imgList.ImageSize = new Size(1, itemHeight);

                ListViewAddressBook.SmallImageList = imgList;

                foreach (var item in bookList)
                {
                    ListViewItem listViewItem = new ListViewItem(new string[] { item.UserState.ToString(), item.UserName, item.UserDesc });
                    ListViewAddressBook.Items.Add(listViewItem);
                }



                ListViewAddressBook.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                ListViewAddressBook.Columns[0].Width = 0;
            }
        }

        /// <summary>
        /// Edytuj książkę po otrzymaniu zmian, sortuj kontakty od dostępnego
        /// </summary>
        /// <param name="bookList"></param>
        private void EditBook(List<User> bookList)
        {
            if (ListViewAddressBook.InvokeRequired)
            {
                SetUsersCallBack f = new SetUsersCallBack(EditBook);
                this.Invoke(f, new object[] { bookList });
            }
            else
            {
                foreach (ListViewItem lvi in ListViewAddressBook.Items)
                {
                    foreach (var item in bookList)
                    {
                        if (lvi.SubItems[1].Text == item.UserName)
                        {
                            if (item.UserState != Status.UNKNOWN)
                            {
                                int stateIndex = (int)item.UserState;
                                lvi.SubItems[0].Text = stateIndex.ToString();
                                SetText("Użytkownik " + item.UserName + " zaktualizował swój status!");

                                timer1.Enabled = true;
                                Console.WriteLine(stateIndex.ToString());
                                popUpForm.labelWho.Text = item.UserName;
                                popUpForm.labelWhat.Text = "Użytkownik zaktualizował swój status!";
                                popUpForm.ShowDialog();

                                ListViewAddressBook.Sort();
                            }
                            if (item.UserDesc != null && item.UserDesc != "")
                            {
                                lvi.SubItems[2].Text = item.UserDesc;
                                SetText("Użytkownik " + item.UserName + " zaktualizował swój opis!");

                                timer1.Enabled = true;
                                popUpForm.labelWho.Text = item.UserName;
                                popUpForm.labelWhat.Text = "Użytkownik zaktualizował swój opis!";
                                popUpForm.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Zmień status w ComboBox'ie
        /// </summary>
        /// <param name="text"></param>
        private void ChangeComboBox(string text)
        {
            ComboBoxStatus.Text = text;
        }

        /// <summary>
        /// Ustaw kolory na formatce, zgodnie z listą
        /// </summary>
        /// <param name="colorList"></param>
        private void SetColor(List<User> colorList)
        {
            if (ListViewAddressBook.InvokeRequired)
            {
                SetUsersCallBack f = new SetUsersCallBack(SetColor);
                this.Invoke(f, new object[] { colorList });
            }
            else
            {
                foreach (ListViewItem lvi in ListViewAddressBook.Items)
                {
                    foreach (var item in colorList)
                    {
                        if (lvi.SubItems[1].Text == item.UserName)
                        {
                            lvi.BackColor = item.StateColor;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Button send
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonSend_Click(object sender, EventArgs e)
        {
            //if (trafficController.GetState() == State.OpenedGate)
            //{
            //    Console.WriteLine("current number" + currentNumber);
            //    if (!trafficController.SMSSend(currentNumber, null, messageForm.TextBoxMessage1.Text, "", null))
            //    {
            //        Console.WriteLine("UDALO SIE");
            //        TypeText("ja", messageForm.TextBoxMessage1.Text, DateTime.Now);
            //    }
            //    else
            //        SetText("Nie udało się wysłać wiadomości");
            //    messageForm.TextBoxMessage1.Clear();
            //}
            //else MessageBox.Show("Nie wybrałeś kontaktu, do którego chcesz wysłać wiadomość!");
            ////Clickk(messageForm.test, messageForm.TextBoxMessage1, messageForm.nr);
        }

        public void Run(String login, String password)
        {
            if (trafficController.GetState() == State.Connected)
            {
                trafficController.LogIn(login, password);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.L)
                loggerActive = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            trafficController.CloseConnection();
        }

        private void ListViewAddressBook_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            iteam = e.Item;
            //e.Item.BackColor = Color.Black;
        }

        private void ListViewAddressBook_MouseLeave(object sender, EventArgs e)
        {
            if (iteam != null)
            {
                //iteam.BackColor = Color.Bisque;
            }
        }
    }
}
