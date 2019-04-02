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
            this.ListViewAddressBook = new System.Windows.Forms.ListView();
            this.order = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nazwa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PopUpTimer = new System.Windows.Forms.Timer(this.components);
            this.ComboBoxStatus = new System.Windows.Forms.ComboBox();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNick = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonArchives = new System.Windows.Forms.Button();
            this.buttonGroupMaker = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.buttonFavorite = new System.Windows.Forms.Button();
            this.buttonIgnored = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonPad = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonExitMain = new System.Windows.Forms.Button();
            this.buttonMinimalizeMain = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ListViewAddressBook
            // 
            this.ListViewAddressBook.AllowColumnReorder = true;
            this.ListViewAddressBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.ListViewAddressBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListViewAddressBook.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.order,
            this.nazwa,
            this.info});
            this.ListViewAddressBook.FullRowSelect = true;
            this.ListViewAddressBook.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewAddressBook.Location = new System.Drawing.Point(2, 255);
            this.ListViewAddressBook.MultiSelect = false;
            this.ListViewAddressBook.Name = "ListViewAddressBook";
            this.ListViewAddressBook.Size = new System.Drawing.Size(375, 316);
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
            this.ComboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStatus.FormattingEnabled = true;
            this.ComboBoxStatus.Location = new System.Drawing.Point(138, 30);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(135, 21);
            this.ComboBoxStatus.TabIndex = 0;
            this.ComboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStatus_SelectedIndexChanged);
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TextBoxDescription.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TextBoxDescription.Location = new System.Drawing.Point(85, 66);
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(188, 18);
            this.TextBoxDescription.TabIndex = 1;
            this.TextBoxDescription.Text = "Wpisz swój opis";
            this.TextBoxDescription.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxDescription_MouseClick);
            this.TextBoxDescription.Enter += new System.EventHandler(this.TextBoxDescription_Enter);
            this.TextBoxDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDescription_KeyPress);
            this.TextBoxDescription.Leave += new System.EventHandler(this.TextBoxDescription_Leave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.buttonExitMain);
            this.panel2.Controls.Add(this.buttonMinimalizeMain);
            this.panel2.Controls.Add(this.buttonHelp);
            this.panel2.Location = new System.Drawing.Point(2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 33);
            this.panel2.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(42, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "BzCOM";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelNick);
            this.panel1.Controls.Add(this.buttonPad);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.ComboBoxStatus);
            this.panel1.Controls.Add(this.TextBoxDescription);
            this.panel1.Location = new System.Drawing.Point(2, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 99);
            this.panel1.TabIndex = 40;
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.BackColor = System.Drawing.Color.Silver;
            this.labelNick.Location = new System.Drawing.Point(210, 14);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(63, 13);
            this.labelNick.TabIndex = 39;
            this.labelNick.Text = "NICKNAME";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.buttonFavorite);
            this.panel3.Controls.Add(this.buttonIgnored);
            this.panel3.Controls.Add(this.buttonAdd);
            this.panel3.Location = new System.Drawing.Point(2, 187);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 49);
            this.panel3.TabIndex = 41;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(36, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 20);
            this.textBox1.TabIndex = 36;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.buttonSettings);
            this.panel4.Controls.Add(this.buttonArchives);
            this.panel4.Controls.Add(this.buttonGroupMaker);
            this.panel4.Location = new System.Drawing.Point(2, 599);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(375, 49);
            this.panel4.TabIndex = 42;
            // 
            // buttonSettings
            // 
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Image = global::ChatTest.Properties.Resources.settings;
            this.buttonSettings.Location = new System.Drawing.Point(330, 4);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(40, 40);
            this.buttonSettings.TabIndex = 34;
            this.buttonSettings.UseVisualStyleBackColor = true;
            // 
            // buttonArchives
            // 
            this.buttonArchives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArchives.Image = global::ChatTest.Properties.Resources.folder;
            this.buttonArchives.Location = new System.Drawing.Point(54, 5);
            this.buttonArchives.Name = "buttonArchives";
            this.buttonArchives.Size = new System.Drawing.Size(40, 40);
            this.buttonArchives.TabIndex = 33;
            this.buttonArchives.UseVisualStyleBackColor = true;
            // 
            // buttonGroupMaker
            // 
            this.buttonGroupMaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGroupMaker.Image = global::ChatTest.Properties.Resources.group;
            this.buttonGroupMaker.Location = new System.Drawing.Point(8, 5);
            this.buttonGroupMaker.Name = "buttonGroupMaker";
            this.buttonGroupMaker.Size = new System.Drawing.Size(40, 40);
            this.buttonGroupMaker.TabIndex = 32;
            this.buttonGroupMaker.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ChatTest.Properties.Resources.loupe;
            this.pictureBox3.Location = new System.Drawing.Point(3, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 29);
            this.pictureBox3.TabIndex = 37;
            this.pictureBox3.TabStop = false;
            // 
            // buttonFavorite
            // 
            this.buttonFavorite.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(174)))), ((int)(((byte)(207)))));
            this.buttonFavorite.FlatAppearance.BorderSize = 2;
            this.buttonFavorite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFavorite.Image = global::ChatTest.Properties.Resources.user;
            this.buttonFavorite.Location = new System.Drawing.Point(338, 9);
            this.buttonFavorite.Name = "buttonFavorite";
            this.buttonFavorite.Size = new System.Drawing.Size(31, 31);
            this.buttonFavorite.TabIndex = 33;
            this.buttonFavorite.UseVisualStyleBackColor = true;
            // 
            // buttonIgnored
            // 
            this.buttonIgnored.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(174)))), ((int)(((byte)(207)))));
            this.buttonIgnored.FlatAppearance.BorderSize = 2;
            this.buttonIgnored.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIgnored.Image = global::ChatTest.Properties.Resources.block_user;
            this.buttonIgnored.Location = new System.Drawing.Point(300, 9);
            this.buttonIgnored.Name = "buttonIgnored";
            this.buttonIgnored.Size = new System.Drawing.Size(31, 31);
            this.buttonIgnored.TabIndex = 35;
            this.buttonIgnored.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(174)))), ((int)(((byte)(207)))));
            this.buttonAdd.FlatAppearance.BorderSize = 2;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Image = global::ChatTest.Properties.Resources.add_user;
            this.buttonAdd.Location = new System.Drawing.Point(260, 9);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(31, 31);
            this.buttonAdd.TabIndex = 34;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonPad
            // 
            this.buttonPad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPad.Image = global::ChatTest.Properties.Resources.notepad;
            this.buttonPad.Location = new System.Drawing.Point(10, 30);
            this.buttonPad.Name = "buttonPad";
            this.buttonPad.Size = new System.Drawing.Size(40, 48);
            this.buttonPad.TabIndex = 39;
            this.buttonPad.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::ChatTest.Properties.Resources.avatar_1_;
            this.pictureBox1.Location = new System.Drawing.Point(279, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            this.buttonExitMain.Location = new System.Drawing.Point(336, 0);
            this.buttonExitMain.Name = "buttonExitMain";
            this.buttonExitMain.Size = new System.Drawing.Size(34, 28);
            this.buttonExitMain.TabIndex = 25;
            this.buttonExitMain.UseVisualStyleBackColor = true;
            this.buttonExitMain.Click += new System.EventHandler(this.buttonExitMain_Click);
            // 
            // buttonMinimalizeMain
            // 
            this.buttonMinimalizeMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimalizeMain.Image = global::ChatTest.Properties.Resources.substract__3_;
            this.buttonMinimalizeMain.Location = new System.Drawing.Point(296, 0);
            this.buttonMinimalizeMain.Name = "buttonMinimalizeMain";
            this.buttonMinimalizeMain.Size = new System.Drawing.Size(34, 28);
            this.buttonMinimalizeMain.TabIndex = 26;
            this.buttonMinimalizeMain.UseVisualStyleBackColor = true;
            this.buttonMinimalizeMain.Click += new System.EventHandler(this.buttonMinimalizeMain_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHelp.Image = global::ChatTest.Properties.Resources.questions_circular_button;
            this.buttonHelp.Location = new System.Drawing.Point(256, 2);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(34, 28);
            this.buttonHelp.TabIndex = 27;
            this.buttonHelp.UseVisualStyleBackColor = true;
            // 
            // AddressBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(383, 660);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ListViewAddressBook);
            this.KeyPreview = true;
            this.Name = "AddressBookForm";
            this.Text = "BzCOM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonExitMain;
        private System.Windows.Forms.Button buttonMinimalizeMain;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonPad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFavorite;
        private System.Windows.Forms.Button buttonIgnored;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonArchives;
        private System.Windows.Forms.Button buttonGroupMaker;
    }
}

