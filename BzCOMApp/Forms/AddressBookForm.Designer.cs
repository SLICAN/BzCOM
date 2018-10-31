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
            this.labelAvailable = new System.Windows.Forms.Label();
            this.labelUnavailable = new System.Windows.Forms.Label();
            this.labelBrb = new System.Windows.Forms.Label();
            this.labelBusy = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ComboBoxStatus = new System.Windows.Forms.ComboBox();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // ListViewAddressBook
            // 
            this.ListViewAddressBook.AllowColumnReorder = true;
            this.ListViewAddressBook.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ListViewAddressBook.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewAddressBook.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.order,
            this.nazwa,
            this.info});
            this.ListViewAddressBook.FullRowSelect = true;
            this.ListViewAddressBook.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewAddressBook.Location = new System.Drawing.Point(16, 138);
            this.ListViewAddressBook.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListViewAddressBook.MultiSelect = false;
            this.ListViewAddressBook.Name = "ListViewAddressBook";
            this.ListViewAddressBook.Size = new System.Drawing.Size(251, 322);
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
            // labelAvailable
            // 
            this.labelAvailable.AutoSize = true;
            this.labelAvailable.BackColor = System.Drawing.Color.LightGreen;
            this.labelAvailable.Location = new System.Drawing.Point(16, 475);
            this.labelAvailable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAvailable.Name = "labelAvailable";
            this.labelAvailable.Size = new System.Drawing.Size(81, 17);
            this.labelAvailable.TabIndex = 25;
            this.labelAvailable.Text = "AVAILABLE";
            // 
            // labelUnavailable
            // 
            this.labelUnavailable.AutoSize = true;
            this.labelUnavailable.BackColor = System.Drawing.Color.LightGray;
            this.labelUnavailable.Location = new System.Drawing.Point(159, 475);
            this.labelUnavailable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUnavailable.Name = "labelUnavailable";
            this.labelUnavailable.Size = new System.Drawing.Size(101, 17);
            this.labelUnavailable.TabIndex = 26;
            this.labelUnavailable.Text = "UNAVAILABLE";
            // 
            // labelBrb
            // 
            this.labelBrb.AutoSize = true;
            this.labelBrb.BackColor = System.Drawing.Color.LightSkyBlue;
            this.labelBrb.Location = new System.Drawing.Point(109, 475);
            this.labelBrb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBrb.Name = "labelBrb";
            this.labelBrb.Size = new System.Drawing.Size(36, 17);
            this.labelBrb.TabIndex = 27;
            this.labelBrb.Text = "BRB";
            // 
            // labelBusy
            // 
            this.labelBusy.AutoSize = true;
            this.labelBusy.BackColor = System.Drawing.Color.IndianRed;
            this.labelBusy.Location = new System.Drawing.Point(16, 505);
            this.labelBusy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBusy.Name = "labelBusy";
            this.labelBusy.Size = new System.Drawing.Size(45, 17);
            this.labelBusy.TabIndex = 28;
            this.labelBusy.Text = "BUSY";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            // 
            // ComboBoxStatus
            // 
            this.ComboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStatus.FormattingEnabled = true;
            this.ComboBoxStatus.Location = new System.Drawing.Point(16, 49);
            this.ComboBoxStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(249, 24);
            this.ComboBoxStatus.TabIndex = 0;
            this.ComboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStatus_SelectedIndexChanged);
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TextBoxDescription.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TextBoxDescription.Location = new System.Drawing.Point(16, 82);
            this.TextBoxDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(249, 21);
            this.TextBoxDescription.TabIndex = 1;
            this.TextBoxDescription.Text = "Wpisz swój opis";
            this.TextBoxDescription.Enter += new System.EventHandler(this.TextBoxDescription_Enter);
            this.TextBoxDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDescription_KeyPress);
            this.TextBoxDescription.Leave += new System.EventHandler(this.TextBoxDescription_Leave);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 25);
            this.panel1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "BzCOM";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ChatTest.Properties.Resources._11;
            this.pictureBox2.Location = new System.Drawing.Point(245, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ChatTest.Properties.Resources._3;
            this.pictureBox4.Location = new System.Drawing.Point(187, 2);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(21, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 17;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ChatTest.Properties.Resources._2;
            this.pictureBox3.Location = new System.Drawing.Point(216, 2);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(21, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // AddressBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 546);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TextBoxDescription);
            this.Controls.Add(this.ComboBoxStatus);
            this.Controls.Add(this.labelBusy);
            this.Controls.Add(this.labelBrb);
            this.Controls.Add(this.labelUnavailable);
            this.Controls.Add(this.labelAvailable);
            this.Controls.Add(this.ListViewAddressBook);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddressBookForm";
            this.Text = "BzCOM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView ListViewAddressBook;
        private System.Windows.Forms.ColumnHeader nazwa;
        private System.Windows.Forms.ColumnHeader info;
        private System.Windows.Forms.Label labelAvailable;
        private System.Windows.Forms.Label labelUnavailable;
        private System.Windows.Forms.Label labelBrb;
        private System.Windows.Forms.Label labelBusy;
        private System.Windows.Forms.ColumnHeader order;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox ComboBoxStatus;
        private System.Windows.Forms.TextBox TextBoxDescription;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
    }
}

