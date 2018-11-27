namespace ChatTest.Forms
{
    partial class LoginForm
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
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.TextBoxLogin = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.SaveToFileCheckBox = new System.Windows.Forms.CheckBox();
            this.ComboBoxIPAddress = new System.Windows.Forms.ComboBox();
            this.NumericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.ResizeButton = new System.Windows.Forms.PictureBox();
            this.HideButton = new System.Windows.Forms.PictureBox();
            this.SettingsImage = new System.Windows.Forms.PictureBox();
            this.LoginImage = new System.Windows.Forms.PictureBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.labelLoginInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPort)).BeginInit();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HideButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginImage)).BeginInit();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ButtonLogin.FlatAppearance.BorderSize = 0;
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Location = new System.Drawing.Point(106, 290);
            this.ButtonLogin.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(233, 50);
            this.ButtonLogin.TabIndex = 0;
            this.ButtonLogin.Text = "Login";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // TextBoxLogin
            // 
            this.TextBoxLogin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TextBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.TextBoxLogin.Location = new System.Drawing.Point(106, 181);
            this.TextBoxLogin.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxLogin.Multiline = true;
            this.TextBoxLogin.Name = "TextBoxLogin";
            this.TextBoxLogin.Size = new System.Drawing.Size(233, 25);
            this.TextBoxLogin.TabIndex = 1;
            this.TextBoxLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TextBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.TextBoxPassword.Location = new System.Drawing.Point(106, 219);
            this.TextBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '*';
            this.TextBoxPassword.Size = new System.Drawing.Size(233, 24);
            this.TextBoxPassword.TabIndex = 3;
            this.TextBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxPassword.UseSystemPasswordChar = true;
            this.TextBoxPassword.WordWrap = false;
            this.TextBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPassword_KeyPress);
            // 
            // SaveToFileCheckBox
            // 
            this.SaveToFileCheckBox.AutoSize = true;
            this.SaveToFileCheckBox.Location = new System.Drawing.Point(180, 265);
            this.SaveToFileCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.SaveToFileCheckBox.Name = "SaveToFileCheckBox";
            this.SaveToFileCheckBox.Size = new System.Drawing.Size(88, 17);
            this.SaveToFileCheckBox.TabIndex = 6;
            this.SaveToFileCheckBox.Text = "Save to file ?";
            this.SaveToFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // ComboBoxIPAddress
            // 
            this.ComboBoxIPAddress.FormattingEnabled = true;
            this.ComboBoxIPAddress.Location = new System.Drawing.Point(8, 19);
            this.ComboBoxIPAddress.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxIPAddress.Name = "ComboBoxIPAddress";
            this.ComboBoxIPAddress.Size = new System.Drawing.Size(92, 21);
            this.ComboBoxIPAddress.TabIndex = 3;
            this.ComboBoxIPAddress.Text = "212.122.223.102";
            this.ComboBoxIPAddress.SelectedIndexChanged += new System.EventHandler(this.ComboBoxIPAddress_SelectedIndexChanged);
            // 
            // NumericUpDownPort
            // 
            this.NumericUpDownPort.Location = new System.Drawing.Point(8, 45);
            this.NumericUpDownPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericUpDownPort.Name = "NumericUpDownPort";
            this.NumericUpDownPort.Size = new System.Drawing.Size(93, 20);
            this.NumericUpDownPort.TabIndex = 4;
            this.NumericUpDownPort.Value = new decimal(new int[] {
            5529,
            0,
            0,
            0});
            this.NumericUpDownPort.ValueChanged += new System.EventHandler(this.NumericUpDownPort_ValueChanged);
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
            this.TitlePanel.Size = new System.Drawing.Size(423, 20);
            this.TitlePanel.TabIndex = 18;
            this.TitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(206, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(43, 13);
            this.Title.TabIndex = 18;
            this.Title.Text = "BzCOM";
            // 
            // CloseButton
            // 
            this.CloseButton.Image = global::ChatTest.Properties.Resources._11;
            this.CloseButton.Location = new System.Drawing.Point(393, 2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(16, 16);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 15;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ResizeButton
            // 
            this.ResizeButton.Image = global::ChatTest.Properties.Resources._3;
            this.ResizeButton.Location = new System.Drawing.Point(345, 2);
            this.ResizeButton.Name = "ResizeButton";
            this.ResizeButton.Size = new System.Drawing.Size(16, 16);
            this.ResizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ResizeButton.TabIndex = 17;
            this.ResizeButton.TabStop = false;
            // 
            // HideButton
            // 
            this.HideButton.Image = global::ChatTest.Properties.Resources._2;
            this.HideButton.Location = new System.Drawing.Point(369, 2);
            this.HideButton.Name = "HideButton";
            this.HideButton.Size = new System.Drawing.Size(16, 16);
            this.HideButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HideButton.TabIndex = 16;
            this.HideButton.TabStop = false;
            // 
            // SettingsImage
            // 
            this.SettingsImage.Image = global::ChatTest.Properties.Resources.cog_icon;
            this.SettingsImage.Location = new System.Drawing.Point(3, 24);
            this.SettingsImage.Name = "SettingsImage";
            this.SettingsImage.Size = new System.Drawing.Size(52, 50);
            this.SettingsImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SettingsImage.TabIndex = 19;
            this.SettingsImage.TabStop = false;
            this.SettingsImage.Click += new System.EventHandler(this.SettingsImage_Click);
            // 
            // LoginImage
            // 
            this.LoginImage.Image = global::ChatTest.Properties.Resources.kisspng_computer_icons_avatar_user_profile_recommender_sys_5afe866a11a941_0921589115266299940724;
            this.LoginImage.Location = new System.Drawing.Point(161, 30);
            this.LoginImage.Name = "LoginImage";
            this.LoginImage.Size = new System.Drawing.Size(128, 128);
            this.LoginImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoginImage.TabIndex = 10;
            this.LoginImage.TabStop = false;
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSettings.Controls.Add(this.ComboBoxIPAddress);
            this.panelSettings.Controls.Add(this.NumericUpDownPort);
            this.panelSettings.Location = new System.Drawing.Point(3, 76);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(108, 82);
            this.panelSettings.TabIndex = 20;
            this.panelSettings.Visible = false;
            // 
            // labelLoginInfo
            // 
            this.labelLoginInfo.AutoSize = true;
            this.labelLoginInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.labelLoginInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelLoginInfo.Location = new System.Drawing.Point(104, 348);
            this.labelLoginInfo.Name = "labelLoginInfo";
            this.labelLoginInfo.Size = new System.Drawing.Size(0, 25);
            this.labelLoginInfo.TabIndex = 21;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(423, 382);
            this.Controls.Add(this.labelLoginInfo);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.SettingsImage);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.LoginImage);
            this.Controls.Add(this.SaveToFileCheckBox);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxLogin);
            this.Controls.Add(this.ButtonLogin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPort)).EndInit();
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HideButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginImage)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.TextBox TextBoxLogin;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.CheckBox SaveToFileCheckBox;
        private System.Windows.Forms.ComboBox ComboBoxIPAddress;
        private System.Windows.Forms.NumericUpDown NumericUpDownPort;
        private System.Windows.Forms.PictureBox LoginImage;
        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.PictureBox HideButton;
        private System.Windows.Forms.PictureBox ResizeButton;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.PictureBox SettingsImage;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelLoginInfo;
    }
}