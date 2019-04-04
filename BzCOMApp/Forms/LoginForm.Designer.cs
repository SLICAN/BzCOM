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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.TextBoxLogin = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.SaveToFileCheckBox = new System.Windows.Forms.CheckBox();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.labelLoginInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.textBoxIP = new System.Windows.Forms.MaskedTextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SettingsImage = new System.Windows.Forms.PictureBox();
            this.LoginImage = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(174)))), ((int)(((byte)(207)))));
            this.ButtonLogin.FlatAppearance.BorderSize = 0;
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Font = new System.Drawing.Font("Arial", 11F);
            this.ButtonLogin.Location = new System.Drawing.Point(97, 279);
            this.ButtonLogin.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(203, 31);
            this.ButtonLogin.TabIndex = 0;
            this.ButtonLogin.Text = "Login";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // TextBoxLogin
            // 
            this.TextBoxLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.TextBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxLogin.Font = new System.Drawing.Font("Arial", 11F);
            this.TextBoxLogin.ForeColor = System.Drawing.Color.Silver;
            this.TextBoxLogin.Location = new System.Drawing.Point(120, 193);
            this.TextBoxLogin.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxLogin.Multiline = true;
            this.TextBoxLogin.Name = "TextBoxLogin";
            this.TextBoxLogin.Size = new System.Drawing.Size(180, 19);
            this.TextBoxLogin.TabIndex = 1;
            this.TextBoxLogin.Text = "Login";
            this.TextBoxLogin.Click += new System.EventHandler(this.TextBoxLogin_Click);
            this.TextBoxLogin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxLogin_MouseClick);
            this.TextBoxLogin.TextChanged += new System.EventHandler(this.TextBoxLogin_TextChanged);
            this.TextBoxLogin.Enter += new System.EventHandler(this.TextBoxLogin_Enter);
            this.TextBoxLogin.Leave += new System.EventHandler(this.TextBoxLogin_Leave);
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.TextBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxPassword.Font = new System.Drawing.Font("Arial", 11F);
            this.TextBoxPassword.ForeColor = System.Drawing.Color.White;
            this.TextBoxPassword.Location = new System.Drawing.Point(120, 229);
            this.TextBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '*';
            this.TextBoxPassword.Size = new System.Drawing.Size(180, 17);
            this.TextBoxPassword.TabIndex = 3;
            this.TextBoxPassword.UseSystemPasswordChar = true;
            this.TextBoxPassword.WordWrap = false;
            this.TextBoxPassword.TextChanged += new System.EventHandler(this.TextBoxPassword_TextChanged);
            this.TextBoxPassword.Enter += new System.EventHandler(this.TextBoxPassword_Enter);
            this.TextBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPassword_KeyPress);
            this.TextBoxPassword.Leave += new System.EventHandler(this.TextBoxPassword_Leave);
            // 
            // SaveToFileCheckBox
            // 
            this.SaveToFileCheckBox.AutoSize = true;
            this.SaveToFileCheckBox.ForeColor = System.Drawing.Color.White;
            this.SaveToFileCheckBox.Location = new System.Drawing.Point(156, 330);
            this.SaveToFileCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.SaveToFileCheckBox.Name = "SaveToFileCheckBox";
            this.SaveToFileCheckBox.Size = new System.Drawing.Size(87, 17);
            this.SaveToFileCheckBox.TabIndex = 6;
            this.SaveToFileCheckBox.Text = "Remeber Me";
            this.SaveToFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.TitlePanel.Controls.Add(this.pictureBox1);
            this.TitlePanel.Controls.Add(this.buttonMinimize);
            this.TitlePanel.Controls.Add(this.buttonExit);
            this.TitlePanel.Controls.Add(this.Title);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(401, 32);
            this.TitlePanel.TabIndex = 18;
            this.TitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChatTest.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 23);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Image = global::ChatTest.Properties.Resources.substract__3_;
            this.buttonMinimize.Location = new System.Drawing.Point(328, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(35, 29);
            this.buttonMinimize.TabIndex = 27;
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.button2_Click);
            this.buttonMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.buttonMinimize.MouseEnter += new System.EventHandler(this.buttonMinimize_MouseEnter);
            this.buttonMinimize.MouseLeave += new System.EventHandler(this.buttonMinimize_MouseLeave);
            this.buttonMinimize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button2_MouseMove);
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Image = global::ChatTest.Properties.Resources.multiply1;
            this.buttonExit.Location = new System.Drawing.Point(362, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(39, 29);
            this.buttonExit.TabIndex = 26;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.button1_Click);
            this.buttonExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonExit_MouseDown);
            this.buttonExit.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.buttonExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.Gainsboro;
            this.Title.Location = new System.Drawing.Point(45, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(59, 16);
            this.Title.TabIndex = 18;
            this.Title.Text = "BzCOM";
            // 
            // labelLoginInfo
            // 
            this.labelLoginInfo.AutoSize = true;
            this.labelLoginInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.labelLoginInfo.ForeColor = System.Drawing.Color.Silver;
            this.labelLoginInfo.Location = new System.Drawing.Point(81, 373);
            this.labelLoginInfo.Name = "labelLoginInfo";
            this.labelLoginInfo.Size = new System.Drawing.Size(0, 25);
            this.labelLoginInfo.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(97, 217);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 1);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(97, 251);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 1);
            this.panel2.TabIndex = 25;
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.panelSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSettings.Controls.Add(this.textBoxIP);
            this.panelSettings.Controls.Add(this.textBoxPort);
            this.panelSettings.Location = new System.Drawing.Point(8, 101);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(107, 59);
            this.panelSettings.TabIndex = 26;
            this.panelSettings.Visible = false;
            this.panelSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSettings_Paint);
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.Silver;
            this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxIP.Location = new System.Drawing.Point(3, 12);
            this.textBoxIP.Mask = "###.###.###.###";
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(99, 13);
            this.textBoxIP.SkipLiterals = false;
            this.textBoxIP.TabIndex = 2;
            this.textBoxIP.Text = "221122223102";
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxIP.Enter += new System.EventHandler(this.textBoxIP_Enter);
            this.textBoxIP.Leave += new System.EventHandler(this.textBoxIP_Leave);
            this.textBoxIP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBoxIP_MouseUp);
            // 
            // textBoxPort
            // 
            this.textBoxPort.BackColor = System.Drawing.Color.Silver;
            this.textBoxPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxPort.Location = new System.Drawing.Point(3, 31);
            this.textBoxPort.MaxLength = 4;
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(99, 13);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "5529";
            this.textBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPort.Enter += new System.EventHandler(this.textBoxPort_Enter);
            this.textBoxPort.Leave += new System.EventHandler(this.textBoxPort_Leave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ChatTest.Properties.Resources._lock;
            this.pictureBox3.Location = new System.Drawing.Point(97, 229);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 19);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ChatTest.Properties.Resources.person;
            this.pictureBox2.Location = new System.Drawing.Point(97, 193);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 19);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // SettingsImage
            // 
            this.SettingsImage.Image = global::ChatTest.Properties.Resources.settings_gears1;
            this.SettingsImage.Location = new System.Drawing.Point(12, 59);
            this.SettingsImage.Name = "SettingsImage";
            this.SettingsImage.Size = new System.Drawing.Size(47, 36);
            this.SettingsImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SettingsImage.TabIndex = 19;
            this.SettingsImage.TabStop = false;
            this.SettingsImage.Click += new System.EventHandler(this.SettingsImage_Click);
            this.SettingsImage.MouseEnter += new System.EventHandler(this.SettingsImage_MouseEnter);
            this.SettingsImage.MouseLeave += new System.EventHandler(this.SettingsImage_MouseLeave);
            // 
            // LoginImage
            // 
            this.LoginImage.Image = ((System.Drawing.Image)(resources.GetObject("LoginImage.Image")));
            this.LoginImage.Location = new System.Drawing.Point(137, 43);
            this.LoginImage.Name = "LoginImage";
            this.LoginImage.Size = new System.Drawing.Size(128, 128);
            this.LoginImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoginImage.TabIndex = 10;
            this.LoginImage.TabStop = false;
            this.LoginImage.Click += new System.EventHandler(this.LoginImage_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "BzCOM";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(401, 463);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelLoginInfo);
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
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.TextBox TextBoxLogin;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.CheckBox SaveToFileCheckBox;
        private System.Windows.Forms.PictureBox LoginImage;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.PictureBox SettingsImage;
        private System.Windows.Forms.Label labelLoginInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.MaskedTextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}