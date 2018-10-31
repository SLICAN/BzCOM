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
            this.components = new System.ComponentModel.Container();
            this.webBrowser11 = new System.Windows.Forms.WebBrowser();
            this.TextBoxMessage = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelWho = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonItalic = new System.Windows.Forms.Button();
            this.ButtonBold = new System.Windows.Forms.Button();
            this.ButtonSend1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser11
            // 
            this.webBrowser11.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser11.Location = new System.Drawing.Point(0, 23);
            this.webBrowser11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser11.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser11.Name = "webBrowser11";
            this.webBrowser11.Size = new System.Drawing.Size(579, 351);
            this.webBrowser11.TabIndex = 0;
            this.webBrowser11.WebBrowserShortcutsEnabled = false;
            // 
            // TextBoxMessage
            // 
            this.TextBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.TextBoxMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBoxMessage.Multiline = true;
            this.TextBoxMessage.Name = "TextBoxMessage";
            this.TextBoxMessage.Size = new System.Drawing.Size(579, 48);
            this.TextBoxMessage.TabIndex = 1;
            this.TextBoxMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxMessage1_KeyPress);
            this.TextBoxMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxMessage1_KeyUp);
            this.TextBoxMessage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBoxMessage1_MouseUp);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 25);
            this.panel1.TabIndex = 19;
            // 
            // labelWho
            // 
            this.labelWho.AutoSize = true;
            this.labelWho.Location = new System.Drawing.Point(16, 5);
            this.labelWho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWho.Name = "labelWho";
            this.labelWho.Size = new System.Drawing.Size(55, 17);
            this.labelWho.TabIndex = 18;
            this.labelWho.Text = "BzCOM";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ChatTest.Properties.Resources._11;
            this.pictureBox2.Location = new System.Drawing.Point(524, 2);
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
            this.pictureBox4.Location = new System.Drawing.Point(460, 2);
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
            this.pictureBox3.Location = new System.Drawing.Point(492, 2);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(21, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ButtonItalic);
            this.panel2.Controls.Add(this.ButtonBold);
            this.panel2.Controls.Add(this.ButtonSend1);
            this.panel2.Controls.Add(this.TextBoxMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 380);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(579, 82);
            this.panel2.TabIndex = 20;
            // 
            // ButtonItalic
            // 
            this.ButtonItalic.Location = new System.Drawing.Point(39, 54);
            this.ButtonItalic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonItalic.Name = "ButtonItalic";
            this.ButtonItalic.Size = new System.Drawing.Size(27, 25);
            this.ButtonItalic.TabIndex = 12;
            this.ButtonItalic.Text = "I";
            this.ButtonItalic.UseVisualStyleBackColor = true;
            this.ButtonItalic.Click += new System.EventHandler(this.ButtonItalic_Click);
            // 
            // ButtonBold
            // 
            this.ButtonBold.Location = new System.Drawing.Point(4, 54);
            this.ButtonBold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonBold.Name = "ButtonBold";
            this.ButtonBold.Size = new System.Drawing.Size(27, 25);
            this.ButtonBold.TabIndex = 11;
            this.ButtonBold.Text = "B";
            this.ButtonBold.UseVisualStyleBackColor = true;
            this.ButtonBold.Click += new System.EventHandler(this.ButtonBold_Click);
            // 
            // ButtonSend1
            // 
            this.ButtonSend1.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonSend1.BackgroundImage = global::ChatTest.Properties.Resources.send_button;
            this.ButtonSend1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonSend1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSend1.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonSend1.Location = new System.Drawing.Point(540, 49);
            this.ButtonSend1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonSend1.Name = "ButtonSend1";
            this.ButtonSend1.Size = new System.Drawing.Size(33, 31);
            this.ButtonSend1.TabIndex = 2;
            this.ButtonSend1.UseVisualStyleBackColor = false;
            this.ButtonSend1.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Location = new System.Drawing.Point(0, 375);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(579, 4);
            this.panel3.TabIndex = 21;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.ClearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 52);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.SaveToolStripMenuItem.Text = "Zapisz";
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.ClearToolStripMenuItem.Text = "Wyczyść";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "html";
            this.saveFileDialog1.Filter = "Pliki HTML (*.html)|*.html|Pliki tekstowe(*.txt)|*.txt|Wszystkie pliki (*.*)|*.*." +
    "";
            this.saveFileDialog1.Title = "Zapisz rozmowę";
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 462);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser11);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser webBrowser11;
        public System.Windows.Forms.TextBox TextBoxMessage;
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}