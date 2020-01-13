using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy ScreenViewer.xaml
    /// </summary>
    public partial class ScreenViewer : Window
    {
        ChatPage activePage;
        public ScreenViewer(ChatPage screen)
        {
            InitializeComponent();
            activePage = screen;
        }
        public void Connection(String Invitation) {
            //RdpViewer.Connect(Invitation, "User1", "");
            String inv = Invitation;
            RdpViewer.Connect(inv, "User1", "");
            RdpViewer.SmartSizing = true;
        }
        public void Disconnection() {
          RdpViewer.Disconnect();
        }

        private void ScreenViewerWindow_Closed(object sender, EventArgs e)
        {
            activePage.StopViewing();
        }
    }
}
