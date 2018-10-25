using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChatTest
{
    public partial class AddInfoForm : Form
    {
        private XCTIP xctip = new XCTIP();

        private XCTIPSync xCTIPSync = new XCTIPSync();

        private Dictionary<string, string> contactId;

        Connection connection;

        public AddInfoForm(string currentName, Dictionary<string, string> dic)
        {
            InitializeComponent();

            connection = new Connection();

            MainForm form1 = new MainForm();

            label3.Text = currentName;

            contactId = dic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connection.SendingPacket(EditContact());
            this.Close();
            MessageBox.Show("Zmiany zostały zapisane!");
        }
    }
}
