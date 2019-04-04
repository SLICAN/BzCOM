using ChatTest.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
namespace ChatTest
{
    public partial class AddressBookForm : Form
    {
        // test zmian
        private string currentNumber;

        private ListViewItem item;

        private List<MessageForm> openedConnections;

        delegate void SetUsersCallBack(List<User> users);

        private TrafficController trafficController = TrafficController.TrafficControllerInstance;

        //private PopUpForm popUpForm = new PopUpForm();

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

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        public AddressBookForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
           // Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));

            //PopUpTimer.Tick += new EventHandler(PopUpTimer_Tick);

            trafficController.OnUpdateStatus += TrafficController_OnUpdateStatus;
            trafficController.OnAddressBookGet += TrafficController_OnAddressBookGet;
            trafficController.OnDeadConnection += TrafficController_OnDeadConnection;
            trafficController.OnMessageReceived += TrafficController_OnMessageReceived;

            foreach (var item in Enum.GetValues(typeof(Status)))
            {
                if (item.ToString() != Status.UNKNOWN.ToString())
                    ComboBoxStatus.Items.Add(item);
            }

            openedConnections = new List<MessageForm>();
        }
        private void TrafficController_OnMessageReceived(TrafficController sender, Message msgNow)
        {
            bool isConnectionOpened = false;
            foreach (MessageForm messageForm in openedConnections)
                if (msgNow.Number == messageForm.nr)
                    isConnectionOpened = true;

            if (!isConnectionOpened)
            {

                //PopUpTimer.Enabled = true;
                //popUpForm.labelWho.Text = trafficController.FindName(msgNow.Number.ToString());
                //popUpForm.labelWhat.Text = msgNow.Text;
                //popUpForm.ShowDialog();
            }
           
        }


        private void TrafficController_OnAddressBookGet(TrafficController sender, List<User> users)
        {
            
            SetBook(users);
            /// Manages the initial import of statuses and description
            SetColor(trafficController.SetColor(users));
            /// Register sms module
            trafficController.RegisterToModules();
            if (trafficController.GetState() == State.LoggedIn)
            {
                ChangeComboBox(Status.AVAILABLE.ToString());
            }
            this.Show();
        }

        private void TrafficController_OnDeadConnection(TrafficController sender)
        {
            MessageBox.Show("Brak odpowiedzi z serwera.\nSprawdź czy masz połączenie z Internetem lub zgłoś awarię do administratora.\nAplikacja zostanie zamknięta.", "Error", MessageBoxButtons.OK);
            Application.Exit();
        }


        /// <summary>
        /// Edytuj książkę i ustaw odpowiedni kolor - otrzymano zmianę statusu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="users"></param>
        private void TrafficController_OnUpdateStatus(TrafficController sender, List<User> users)
        {
            foreach (var item in users)
            {
                if (item.UserState != Status.UNKNOWN)
                    SetColor(trafficController.SetColor(users));
            }
            EditBook(users);
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
                /*
                if (CheckOpened(messageForm.Text))
                {
                    MessageBox.Show("Juz otwarte");
                    //messageForm.Dispose();
                    messageForm.Show();
                }
                else {
                    messageForm.Show();
                }
                */
                // tworzenie obiektów formatki to nigdy nie jest dobry pomysł
                

                if (!trafficController.protection_unavailable(selectedItem.SubItems[1].Text))
                {
                    MessageForm messageForm = new MessageForm(Int32.Parse(currentNumber));
                    trafficController.SetState(State.OpenedGate);
                    messageForm.labelWho.Text = "Rozmowa z " + selectedItem.SubItems[1].Text;
                    messageForm.Show();                    
                    messageForm.Initialize(openedConnections);
                }
                
            }
            else
                MessageBox.Show("Najpierw musisz ustanowić połączenie!", "Warning");
        }

        //private bool CheckOpened(string name)
        //{
        //    FormCollection fc = Application.OpenForms;

        //    foreach (Form frm in fc)
        //    {
        //        if (frm.Text == name)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

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
        /// Ustaw książkę, ukryj pierszą kolumnę 
        /// (będzie ona służyła tylko do rozpoznawania statusów w kodzie, 
        /// w interfejsie status będzie rozróżniany poprzez kolory)
        /// </summary>
        /// <param name="bookList"></param>
        public void SetBook(List<User> bookList)
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
                                //SetText("Użytkownik " + item.UserName + " zaktualizował swój status!");

                                //PopUpTimer.Enabled = true;
                                Console.WriteLine(stateIndex.ToString());
                                //popUpForm.labelWho.Text = item.UserName;
                                //popUpForm.labelWhat.Text = "Użytkownik zaktualizował swój status!";
                                //popUpForm.ShowDialog();

                                ListViewAddressBook.Sort();
                            }
                            if (item.UserDesc != null && item.UserDesc != "")
                            {
                                lvi.SubItems[2].Text = item.UserDesc;
                                //SetText("Użytkownik " + item.UserName + " zaktualizował swój opis!");

                                //PopUpTimer.Enabled = true;
                                //popUpForm.labelWho.Text = item.UserName;
                                //popUpForm.labelWhat.Text = "Użytkownik zaktualizował swój opis!";
                                //popUpForm.ShowDialog();
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
        public void SetColor(List<User> colorList)
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            trafficController.CloseConnection();
        }

        private void ListViewAddressBook_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            /*item = e.Item;
            e.Item.BackColor = Color.Black;*/
        }

        private void ListViewAddressBook_MouseLeave(object sender, EventArgs e)
        {
            if (item != null)
            {
                //iteam.BackColor = Color.Bisque;
            }
        }

        private void TextBoxDescription_MouseClick(object sender, MouseEventArgs e)
        {
            this.TextBoxDescription.Text = String.Empty;
        }

        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PopUpTimer_Tick(object sender, EventArgs e)
        {
            // Set the caption to the current time.  
            Console.WriteLine("Tick");
            //popUpForm.Hide();
            PopUpTimer.Enabled = false;
        }

        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void buttonExitMain_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void buttonMinimalizeMain_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmaps|*.bmp|jpegs|*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
            }
        }

        private void AddressBookForm_Resize(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void AddressBookForm_Load(object sender, EventArgs e)
        {

        }


        private void panel2_MouseDown(object sender, MouseEventArgs e)

        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
