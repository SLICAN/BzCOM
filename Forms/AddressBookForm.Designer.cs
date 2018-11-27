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
            this.PopUpTimer = new System.Windows.Forms.Timer(this.components);
            this.ComboBoxStatus = new System.Windows.Forms.ComboBox();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.ResizeButton = new System.Windows.Forms.PictureBox();
            this.HideButton = new System.Windows.Forms.PictureBox();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HideButton)).BeginInit();
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
            this.ListViewAddressBook.Location = new System.Drawing.Point(12, 112);
            this.ListViewAddressBook.MultiSelect = false;
            this.ListViewAddressBook.Name = "ListViewAddressBook";
            this.ListViewAddressBook.Size = new System.Drawing.Size(188, 262);
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
            this.labelAvailable.Location = new System.Drawing.Point(12, 386);
            this.labelAvailable.Name = "labelAvailable";
            this.labelAvailable.Size = new System.Drawing.Size(64, 13);
            this.labelAvailable.TabIndex = 25;
            this.labelAvailable.Text = "AVAILABLE";
            // 
            // labelUnavailable
            // 
            this.labelUnavailable.AutoSize = true;
            this.labelUnavailable.BackColor = System.Drawing.Color.LightGray;
            this.labelUnavailable.Location = new System.Drawing.Point(119, 386);
            this.labelUnavailable.Name = "labelUnavailable";
            this.labelUnavailable.Size = new System.Drawing.Size(80, 13);
            this.labelUnavailable.TabIndex = 26;
            this.labelUnavailable.Text = "UNAVAILABLE";
            // 
            // labelBrb
            // 
            this.labelBrb.AutoSize = true;
            this.labelBrb.BackColor = System.Drawing.Color.LightSkyBlue;
            this.labelBrb.Location = new System.Drawing.Point(82, 386);
            this.labelBrb.Name = "labelBrb";
            this.labelBrb.Size = new System.Drawing.Size(29, 13);
            this.labelBrb.TabIndex = 27;
            this.labelBrb.Text = "BRB";
            // 
            // labelBusy
            // 
            this.labelBusy.AutoSize = true;
            this.labelBusy.BackColor = System.Drawing.Color.IndianRed;
            this.labelBusy.Location = new System.Drawing.Point(12, 410);
            this.labelBusy.Name = "labelBusy";
            this.labelBusy.Size = new System.Drawing.Size(36, 13);
            this.labelBusy.TabIndex = 28;
            this.labelBusy.Text = "BUSY";
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
            this.ComboBoxStatus.Location = new System.Drawing.Point(12, 40);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(188, 21);
            this.ComboBoxStatus.TabIndex = 0;
            this.ComboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStatus_SelectedIndexChanged);
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TextBoxDescription.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TextBoxDescription.Location = new System.Drawing.Point(12, 67);
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(188, 18);
            this.TextBoxDescription.TabIndex = 1;
            this.TextBoxDescription.Text = "Wpisz swój opis";
            this.TextBoxDescription.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxDescription_MouseClick);
            this.TextBoxDescription.Enter += new System.EventHandler(this.TextBoxDescription_Enter);
            this.TextBoxDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDescription_KeyPress);
            this.TextBoxDescription.Leave += new System.EventHandler(this.TextBoxDescription_Leave);
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TitlePanel.Controls.Add(this.Title);
            this.TitlePanel.Controls.Add(this.CloseButton);
            this.TitlePanel.Controls.Add(this.ResizeButton);
            this.TitlePanel.Controls.Add(this.HideButton);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(211, 20);
            this.TitlePanel.TabIndex = 29;
            this.TitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(73, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(43, 13);
            this.Title.TabIndex = 30;
            this.Title.Text = "BzCOM";
            // 
            // CloseButton
            // 
            this.CloseButton.Image = global::ChatTest.Properties.Resources._11;
            this.CloseButton.Location = new System.Drawing.Point(184, 2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(16, 16);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 15;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click_1);
            // 
            // ResizeButton
            // 
            this.ResizeButton.Image = global::ChatTest.Properties.Resources._3;
            this.ResizeButton.Location = new System.Drawing.Point(140, 2);
            this.ResizeButton.Name = "ResizeButton";
            this.ResizeButton.Size = new System.Drawing.Size(16, 16);
            this.ResizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ResizeButton.TabIndex = 17;
            this.ResizeButton.TabStop = false;
            // 
            // HideButton
            // 
            this.HideButton.Image = global::ChatTest.Properties.Resources._2;
            this.HideButton.Location = new System.Drawing.Point(162, 2);
            this.HideButton.Name = "HideButton";
            this.HideButton.Size = new System.Drawing.Size(16, 16);
            this.HideButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HideButton.TabIndex = 16;
            this.HideButton.TabStop = false;
            // 
            // AddressBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 444);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.TextBoxDescription);
            this.Controls.Add(this.ComboBoxStatus);
            this.Controls.Add(this.labelBusy);
            this.Controls.Add(this.labelBrb);
            this.Controls.Add(this.labelUnavailable);
            this.Controls.Add(this.labelAvailable);
            this.Controls.Add(this.ListViewAddressBook);
            this.KeyPreview = true;
            this.Name = "AddressBookForm";
            this.Text = "BzCOM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HideButton)).EndInit();
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
        private System.Windows.Forms.Timer PopUpTimer;
        private System.Windows.Forms.ComboBox ComboBoxStatus;
        private System.Windows.Forms.TextBox TextBoxDescription;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.PictureBox ResizeButton;
        private System.Windows.Forms.PictureBox HideButton;
        private System.Windows.Forms.Label Title;
    }
}

