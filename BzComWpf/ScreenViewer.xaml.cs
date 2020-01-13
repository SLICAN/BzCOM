using System;
using System.Windows;

namespace BzCOMWpf
{
    /// <summary>
    /// Logika interakcji dla klasy ScreenViewer.xaml
    /// </summary>
    public partial class ScreenViewer : Window
    {
        ScreenSharing activePage;
        public ScreenViewer()
        {
            InitializeComponent();
            activePage = null;
        }
        public ScreenViewer(ScreenSharing screen)
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
            if (activePage != null)
            {
                activePage.StopViewing();
            }
        }
    }
}
