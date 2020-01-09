using System;
using System.Windows;
using System.Windows.Controls;
using RDPCOMAPILib;

namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy AdressBookPage.xaml
    /// </summary>
    public partial class ScreenSharing : Page
    {
        ScreenViewer xy;
        RDPSession x;
        public ScreenSharing()
        {
            InitializeComponent();

        }
        private void Incoming(object Guest)
        {
            IRDPSRAPIAttendee MyGuest = (IRDPSRAPIAttendee)Guest;//???
            MyGuest.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
        }
        private void Button_Viewer_Click(object sender, RoutedEventArgs e)
        {   
            try
            {
                string Invitation = textBox_Link.Text;
                xy = new ScreenViewer();
                xy.Connection(Invitation);// Do ogarnięcia - wychodzi poza zakres ??? 
                xy.Show();
                Button_StopViewing.Visibility = Visibility.Visible;
                Button_Viewer.IsEnabled = false;
            }
            catch(ArgumentException)
            {
                textBox_Link.Text = "Błędne zaproszenie";
            }
        }
        private void Button_StopSharing_Click(object sender, RoutedEventArgs e)
        {
            x.Close();
            x = null;
            Button_StopSharing.Visibility = Visibility.Hidden;
            Button_Copy.Visibility = Visibility.Hidden;
            Button_Paste.Visibility = Visibility.Visible;
            Button_Host.IsEnabled = true;
        }
        private void Button_Copy_Click(object sender, RoutedEventArgs e)
        {
            string Invitation = textBox_Link.Text;
            Clipboard.SetText(Invitation);
        }
        private void Button_StopViewing_Click(object sender, RoutedEventArgs e)
        {
            xy.Disconnection();
            xy.Close();
            Button_StopViewing.Visibility = Visibility.Hidden;
            Button_Viewer.IsEnabled = true;
        }
        private void Button_Host_Click(object sender, RoutedEventArgs e)
        {
            x = new RDPSession();
            x.OnAttendeeConnected += Incoming;
            x.Open();
            IRDPSRAPIInvitation Invitation = x.Invitations.CreateInvitation("Trial", "MyGroup", "", 10);
            textBox_Link.Text = Invitation.ConnectionString;
            Button_StopSharing.Visibility = Visibility.Visible;
            Button_Copy.Visibility = Visibility.Visible;
            Button_Paste.Visibility = Visibility.Hidden;
            Button_Host.IsEnabled = false;
        }
        private void Button_Paste_Click(object sender, RoutedEventArgs e)
        {
            textBox_Link.Text = Clipboard.GetText();
        }
    }
}