namespace ChatTest
{
    partial class AddressBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddressBookForm));
            this.ListViewAddressBook = new System.Windows.Forms.ListView();
            this.order = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nazwa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PopUpTimer = new System.Windows.Forms.Timer(this.components);
            this.ComboBoxStatus = new System.Windows.Forms.ComboBox();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonExitMain = new System.Windows.Forms.Button();
            this.buttonMinimalizeMain = new System.Windows.Forms.Button();
            this.labelNick = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ListViewAddressBook
            // 
            this.ListViewAddressBook.AllowColumnReorder = true;
            this.ListViewAddressBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ListViewAddressBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListViewAddressBook.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.order,
            this.nazwa,
            this.info});
            this.ListViewAddressBook.FullRowSelect = true;
            this.ListViewAddressBook.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewAddressBook.Location = new System.Drawing.Point(3, 165);
            this.ListViewAddressBook.MultiSelect = false;
            this.ListViewAddressBook.Name = "ListViewAddressBook";
            this.ListViewAddressBook.Size = new System.Drawing.Size(300, 460);
            this.ListViewAddressBook.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListViewAddressBook.TabIndex = 24;
            this.ListViewAddressBook.UseCompatibleStateImageBehavior = false;
            this.ListViewAddressBook.View = System.Windows.Forms.View.Details;
            this.ListViewAddressBook.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.ListViewAddressBook_ItemMouseHover);
            this.ListViewAddressBook.DoubleClick += new System.EventHandler(this.ListViewAddressBook_DoubleClick);
            this.ListViewAddressBook.MouseLeave += new System.EventHandler(this.ListViewAddressBook_MouseLeave);
            // 
            // order
            // 
            this.order.Text = "Lp";
            // 
            // nazwa
            // 
            this.nazwa.Text = "nazwa";
            this.nazwa.Width = 43;
            // 
            // info
            // 
            this.info.Text = "info";
            // 
            // PopUpTimer
            // 
            this.PopUpTimer.Interval = 2000;
            this.PopUpTimer.Tick += new System.EventHandler(this.PopUpTimer_Tick);
            // 
            // ComboBoxStatus
            // 
            this.ComboBoxStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ComboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStatus.FormattingEnabled = true;
            this.ComboBoxStatus.Location = new System.Drawing.Point(56, 43);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(139, 21);
            this.ComboBoxStatus.TabIndex = 0;
            this.ComboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStatus_SelectedIndexChanged);
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(174)))), ((int)(((byte)(207)))));
            this.TextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TextBoxDescription.ForeColor = System.Drawing.SystemColors.Desktop;
            this.TextBoxDescription.Location = new System.Drawing.Point(56, 22);
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(139, 18);
            this.TextBoxDescription.TabIndex = 1;
            this.TextBoxDescription.Text = "Wpisz swój opis";
            this.TextBoxDescription.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxDescription_MouseClick);
            this.TextBoxDescription.Enter += new System.EventHandler(this.TextBoxDescription_Enter);
            this.TextBoxDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDescription_KeyPress);
            this.TextBoxDescription.Leave += new System.EventHandler(this.TextBoxDescription_Leave);
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.titlePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titlePanel.Controls.Add(this.label1);
            this.titlePanel.Controls.Add(this.pictureBox2);
            this.titlePanel.Controls.Add(this.buttonExitMain);
            this.titlePanel.Controls.Add(this.buttonMinimalizeMain);
            this.titlePanel.Location = new System.Drawing.Point(3, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(300, 35);
            this.titlePanel.TabIndex = 37;
            this.titlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlePanel_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(174)))), ((int)(((byte)(207)))));
            this.label1.Location = new System.Drawing.Point(41, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "BzCOM";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ChatTest.Properties.Resources.group_1_;
            this.pictureBox2.Location = new System.Drawing.Point(4, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // buttonExitMain
            // 
            this.buttonExitMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitMain.Image = global::ChatTest.Properties.Resources.multiply1;
            this.buttonExitMain.Location = new System.Drawing.Point(277, 3);
            this.buttonExitMain.Name = "buttonExitMain";
            this.buttonExitMain.Size = new System.Drawing.Size(15, 15);
            this.buttonExitMain.TabIndex = 25;
            this.buttonExitMain.UseVisualStyleBackColor = true;
            this.buttonExitMain.Click += new System.EventHandler(this.buttonExitMain_Click);
            // 
            // buttonMinimalizeMain
            // 
            this.buttonMinimalizeMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimalizeMain.Image = global::ChatTest.Properties.Resources.substract__3_;
            this.buttonMinimalizeMain.Location = new System.Drawing.Point(256, 3);
            this.buttonMinimalizeMain.Name = "buttonMinimalizeMain";
            this.buttonMinimalizeMain.Size = new System.Drawing.Size(15, 15);
            this.buttonMinimalizeMain.TabIndex = 26;
            this.buttonMinimalizeMain.UseVisualStyleBackColor = true;
            this.buttonMinimalizeMain.Click += new System.EventHandler(this.buttonMinimalizeMain_Click);
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(174)))), ((int)(((byte)(207)))));
            this.labelNick.Location = new System.Drawing.Point(3, 3);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(39, 16);
            this.labelNick.TabIndex = 39;
            this.labelNick.Text = "NAME";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox7);
            this.panel3.Controls.Add(this.pictureBox6);
            this.panel3.Controls.Add(this.pictureBox5);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Location = new System.Drawing.Point(3, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 40);
            this.panel3.TabIndex = 41;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::ChatTest.Properties.Resources.icons8_speech_bubble_32;
            this.pictureBox7.Location = new System.Drawing.Point(8, 3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox7.TabIndex = 3;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::ChatTest.Properties.Resources.icons8_bookmark_32;
            this.pictureBox6.Location = new System.Drawing.Point(93, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.TabIndex = 2;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::ChatTest.Properties.Resources.icons8_notification_32;
            this.pictureBox5.Location = new System.Drawing.Point(181, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ChatTest.Properties.Resources.icons8_settings_32;
            this.pictureBox4.Location = new System.Drawing.Point(262, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(3, 625);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 35);
            this.panel4.TabIndex = 42;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "BzCOM";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panel1.Controls.Add(this.ComboBoxStatus);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelNick);
            this.panel1.Controls.Add(this.TextBoxDescription);
            this.panel1.Location = new System.Drawing.Point(3, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 70);
            this.panel1.TabIndex = 43;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(50);
            this.pictureBox1.Size = new System.Drawing.Size(45, 45);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // AddressBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(307, 660);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.ListViewAddressBook);
            this.KeyPreview = true;
            this.Name = "AddressBookForm";
            this.Text = "BzCOM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.AddressBookForm_Load);
            this.Resize += new System.EventHandler(this.AddressBookForm_Resize);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView ListViewAddressBook;
        private System.Windows.Forms.ColumnHeader nazwa;
        private System.Windows.Forms.ColumnHeader info;
        private System.Windows.Forms.ColumnHeader order;
        private System.Windows.Forms.Timer PopUpTimer;
        private System.Windows.Forms.ComboBox ComboBoxStatus;
        private System.Windows.Forms.TextBox TextBoxDescription;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonExitMain;
        private System.Windows.Forms.Button buttonMinimalizeMain;
        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}

