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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using RDPCOMAPILib;

namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy AdressBookPage.xaml
    /// </summary>
    public partial class ScreenSharing : Page
    {

        ScreenViewer xy = new ScreenViewer();

        public ScreenSharing()
        {
            InitializeComponent();

        }

        RDPSession x = new RDPSession();
        private void Incoming(object Guest)
        {
            IRDPSRAPIAttendee MyGuest = (IRDPSRAPIAttendee)Guest;//???
            MyGuest.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
        }

        private void Button_Viewer_Click(object sender, RoutedEventArgs e)
        {
            string Invitation = textBox_Link.Text;
            xy.Show();
            xy.connection(Invitation); // Do ogarnięcia - wychodzi poza zakres ???
        }

        private void Button_StopSharing_Click(object sender, RoutedEventArgs e)
        {
            x.Close();
            x = null;
            Button_StopSharing.Visibility = Visibility.Hidden;
            Button_Copy.Visibility = Visibility.Hidden;
            Button_Paste.Visibility = Visibility.Visible;
        }

        private void Button_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_StopViewing_Click(object sender, RoutedEventArgs e)
        {
            xy.disconnection();
            xy.Hide();
        }

        private void Button_Host_Click(object sender, RoutedEventArgs e)
        {
            x.OnAttendeeConnected += Incoming;
            x.Open();
            IRDPSRAPIInvitation Invitation = x.Invitations.CreateInvitation("Trial", "MyGroup", "", 10);
            textBox_Link.Text = Invitation.ConnectionString;
            Button_StopSharing.Visibility = Visibility.Visible;
            Button_Copy.Visibility = Visibility.Visible;
            Button_Paste.Visibility = Visibility.Hidden;
        }

        private void Button_Paste_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
