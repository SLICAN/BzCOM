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
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.labelWho = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.ResizeButton = new System.Windows.Forms.PictureBox();
            this.HideButton = new System.Windows.Forms.PictureBox();
            this.Div = new System.Windows.Forms.Panel();
            this.ButtonItalic = new System.Windows.Forms.Button();
            this.ButtonBold = new System.Windows.Forms.Button();
            this.ButtonSend1 = new System.Windows.Forms.Button();
            this.Div2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HideButton)).BeginInit();
            this.Div.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            // TextBoxMessage
            // 
            this.TextBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.TextBoxMessage.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxMessage.Multiline = true;
            this.TextBoxMessage.Name = "TextBoxMessage";
            this.TextBoxMessage.Size = new System.Drawing.Size(434, 39);
            this.TextBoxMessage.TabIndex = 1;
            this.TextBoxMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxMessage1_KeyPress);
            this.TextBoxMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxMessage1_KeyUp);
            this.TextBoxMessage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBoxMessage1_MouseUp);
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TitlePanel.Controls.Add(this.labelWho);
            this.TitlePanel.Controls.Add(this.CloseButton);
            this.TitlePanel.Controls.Add(this.ResizeButton);
            this.TitlePanel.Controls.Add(this.HideButton);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(434, 20);
            this.TitlePanel.TabIndex = 19;
            this.TitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
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
            // Div
            // 
            this.Div.Controls.Add(this.ButtonItalic);
            this.Div.Controls.Add(this.ButtonBold);
            this.Div.Controls.Add(this.ButtonSend1);
            this.Div.Controls.Add(this.TextBoxMessage);
            this.Div.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Div.Location = new System.Drawing.Point(0, 308);
            this.Div.Name = "Div";
            this.Div.Size = new System.Drawing.Size(434, 67);
            this.Div.TabIndex = 20;
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
            this.ButtonSend1.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // Div2
            // 
            this.Div2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Div2.Location = new System.Drawing.Point(0, 305);
            this.Div2.Name = "Div2";
            this.Div2.Size = new System.Drawing.Size(434, 3);
            this.Div2.TabIndex = 21;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.ClearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 48);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.SaveToolStripMenuItem.Text = "Zapisz";
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 375);
            this.Controls.Add(this.Div2);
            this.Controls.Add(this.Div);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.webBrowser11);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HideButton)).EndInit();
            this.Div.ResumeLayout(false);
            this.Div.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser webBrowser11;
        public System.Windows.Forms.TextBox TextBoxMessage;
        public System.Windows.Forms.Button ButtonSend1;
        private System.Windows.Forms.Panel TitlePanel;
        public System.Windows.Forms.Label labelWho;
        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.PictureBox ResizeButton;
        private System.Windows.Forms.PictureBox HideButton;
        private System.Windows.Forms.Panel Div;
        private System.Windows.Forms.Panel Div2;
        private System.Windows.Forms.Button ButtonBold;
        private System.Windows.Forms.Button ButtonItalic;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}