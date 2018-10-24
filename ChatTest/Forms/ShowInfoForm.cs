using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatTest
{
    public partial class ShowInfoForm : Form
    {
        public ShowInfoForm(string currentName, string currentNumber, string currentDescription)
        {
            InitializeComponent();

            MainForm form1 = new MainForm();

            label3.Text = currentName;

            label4.Text = currentNumber;

            label5.Text = currentDescription;
        }
    }
}
