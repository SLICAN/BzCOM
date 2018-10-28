namespace ChatTest.Forms
{
    partial class MessageForm
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
            this.webBrowser11 = new System.Windows.Forms.WebBrowser();
            this.TextBoxMessage1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelWho = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonItalic = new System.Windows.Forms.Button();
            this.ButtonBold = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ButtonSend1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser11
            // 
            this.webBrowser11.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser11.Location = new System.Drawing.Point(0, 19);
            this.webBrowser11.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser11.MinimumSize = new System.Drawing.Size(15, 16);
            this.webBrowser11.Name = "webBrowser11";
            this.webBrowser11.Size = new System.Drawing.Size(434, 285);
            this.webBrowser11.TabIndex = 0;
            this.webBrowser11.WebBrowserShortcutsEnabled = false;
            // 
            // TextBoxMessage1
            // 
            this.TextBoxMessage1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxMessage1.Location = new System.Drawing.Point(0, 0);
            this.TextBoxMessage1.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxMessage1.Multiline = true;
            this.TextBoxMessage1.Name = "TextBoxMessage1";
            this.TextBoxMessage1.Size = new System.Drawing.Size(434, 39);
            this.TextBoxMessage1.TabIndex = 1;
            this.TextBoxMessage1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxMessage1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxMessage1_KeyPress);
            this.TextBoxMessage1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxMessage1_KeyUp);
            this.TextBoxMessage1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBoxMessage1_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.labelWho);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 20);
            this.panel1.TabIndex = 19;
            // 
            // labelWho
            // 
            this.labelWho.AutoSize = true;
            this.labelWho.Location = new System.Drawing.Point(12, 4);
            this.labelWho.Name = "labelWho";
            this.labelWho.Size = new System.Drawing.Size(43, 13);
            this.labelWho.TabIndex = 18;
            this.labelWho.Text = "BzCOM";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ButtonItalic);
            this.panel2.Controls.Add(this.ButtonBold);
            this.panel2.Controls.Add(this.ButtonSend1);
            this.panel2.Controls.Add(this.TextBoxMessage1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 308);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 67);
            this.panel2.TabIndex = 20;
            // 
            // ButtonItalic
            // 
            this.ButtonItalic.Location = new System.Drawing.Point(29, 44);
            this.ButtonItalic.Name = "ButtonItalic";
            this.ButtonItalic.Size = new System.Drawing.Size(20, 20);
            this.ButtonItalic.TabIndex = 12;
            this.ButtonItalic.Text = "I";
            this.ButtonItalic.UseVisualStyleBackColor = true;
            this.ButtonItalic.Click += new System.EventHandler(this.ButtonItalic_Click);
            // 
            // ButtonBold
            // 
            this.ButtonBold.Location = new System.Drawing.Point(3, 44);
            this.ButtonBold.Name = "ButtonBold";
            this.ButtonBold.Size = new System.Drawing.Size(20, 20);
            this.ButtonBold.TabIndex = 11;
            this.ButtonBold.Text = "B";
            this.ButtonBold.UseVisualStyleBackColor = true;
            this.ButtonBold.Click += new System.EventHandler(this.ButtonBold_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Location = new System.Drawing.Point(0, 305);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(434, 3);
            this.panel3.TabIndex = 21;
            // 
            // ButtonSend1
            // 
            this.ButtonSend1.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonSend1.BackgroundImage = global::ChatTest.Properties.Resources.send_button;
            this.ButtonSend1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonSend1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSend1.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonSend1.Location = new System.Drawing.Point(405, 40);
            this.ButtonSend1.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSend1.Name = "ButtonSend1";
            this.ButtonSend1.Size = new System.Drawing.Size(25, 25);
            this.ButtonSend1.TabIndex = 2;
            this.ButtonSend1.UseVisualStyleBackColor = false;
            this.ButtonSend1.Click += new System.EventHandler(this.ButtonSend1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ChatTest.Properties.Resources._11;
            this.pictureBox2.Location = new System.Drawing.Point(393, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
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
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 375);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser11);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser webBrowser11;
        public System.Windows.Forms.TextBox TextBoxMessage1;
        public System.Windows.Forms.Button ButtonSend1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label labelWho;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ButtonBold;
        private System.Windows.Forms.Button ButtonItalic;
    }
}