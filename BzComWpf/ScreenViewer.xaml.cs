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
        public ScreenViewer()
        {
            InitializeComponent();
        }
        public void connection(String Invitation) {
          RdpViewer.Connect(Invitation, "User1", "");
        }
        public void disconnection(String Invitation) {
          RdpViewer.Disconnect();
        }

        private void Button_Connect_Click(object sender, RoutedEventArgs e)
        {
            string Invitation = textBox_Link.Text;
            RdpViewer.Connect(Invitation, "User1", "");
        }
    }
}
