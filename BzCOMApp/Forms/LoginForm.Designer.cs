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
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.TextBoxLogin = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.SaveToFileCheckBox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ComboBoxIPAddress = new System.Windows.Forms.ComboBox();
            this.NumericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Pic_Close_2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.labelLoginInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPort)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Close_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.TextBoxLogin.Font = new System.Drawing.Font("Franklin Gothic Demi", 15.75F);
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
            this.TextBoxPassword.Font = new System.Drawing.Font("Franklin Gothic Demi", 15.75F);
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
            // timer1
            // 
            this.timer1.Interval = 30;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Pic_Close_2);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 20);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "BzCOM";
            // 
            // Pic_Close_2
            // 
            this.Pic_Close_2.Image = global::ChatTest.Properties.Resources._11;
            this.Pic_Close_2.Location = new System.Drawing.Point(393, 2);
            this.Pic_Close_2.Name = "Pic_Close_2";
            this.Pic_Close_2.Size = new System.Drawing.Size(16, 16);
            this.Pic_Close_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pic_Close_2.TabIndex = 15;
            this.Pic_Close_2.TabStop = false;
            this.Pic_Close_2.Click += new System.EventHandler(this.Pic_Close_2_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ChatTest.Properties.Resources._3;
            this.pictureBox4.Location = new System.Drawing.Point(345, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 17;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ChatTest.Properties.Resources._2;
            this.pictureBox3.Location = new System.Drawing.Point(369, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::ChatTest.Properties.Resources.cog_icon;
            this.pictureBox5.Location = new System.Drawing.Point(3, 24);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(52, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChatTest.Properties.Resources.kisspng_computer_icons_avatar_user_profile_recommender_sys_5afe866a11a941_0921589115266299940724;
            this.pictureBox1.Location = new System.Drawing.Point(161, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
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
            this.labelLoginInfo.Location = new System.Drawing.Point(206, 360);
            this.labelLoginInfo.Name = "labelLoginInfo";
            this.labelLoginInfo.Size = new System.Drawing.Size(0, 13);
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
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SaveToFileCheckBox);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxLogin);
            this.Controls.Add(this.ButtonLogin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPort)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Close_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.TextBox TextBoxLogin;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.CheckBox SaveToFileCheckBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox ComboBoxIPAddress;
        private System.Windows.Forms.NumericUpDown NumericUpDownPort;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Pic_Close_2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelLoginInfo;
    }
}