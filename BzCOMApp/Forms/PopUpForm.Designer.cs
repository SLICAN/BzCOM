namespace ChatTest.Forms
{
    partial class PopUpForm
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
            this.labelWhat = new System.Windows.Forms.Label();
            this.labelWho = new System.Windows.Forms.Label();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.WhoPanel = new System.Windows.Forms.Panel();
            this.WhatPanel = new System.Windows.Forms.Panel();
            this.Div = new System.Windows.Forms.Panel();
            this.TitlePanel.SuspendLayout();
            this.WhoPanel.SuspendLayout();
            this.WhatPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWhat
            // 
            this.labelWhat.AutoSize = true;
            this.labelWhat.Location = new System.Drawing.Point(12, 14);
            this.labelWhat.Name = "labelWhat";
            this.labelWhat.Size = new System.Drawing.Size(55, 13);
            this.labelWhat.TabIndex = 0;
            this.labelWhat.Text = "labelWhat";
            // 
            // labelWho
            // 
            this.labelWho.AutoSize = true;
            this.labelWho.Location = new System.Drawing.Point(12, 15);
            this.labelWho.Name = "labelWho";
            this.labelWho.Size = new System.Drawing.Size(52, 13);
            this.labelWho.TabIndex = 1;
            this.labelWho.Text = "labelWho";
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TitlePanel.Controls.Add(this.Title);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(434, 20);
            this.TitlePanel.TabIndex = 20;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(190, 3);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(105, 13);
            this.Title.TabIndex = 18;
            this.Title.Text = "BzCOM - Notification";
            // 
            // WhoPanel
            // 
            this.WhoPanel.Controls.Add(this.labelWho);
            this.WhoPanel.Location = new System.Drawing.Point(0, 19);
            this.WhoPanel.Name = "WhoPanel";
            this.WhoPanel.Size = new System.Drawing.Size(434, 41);
            this.WhoPanel.TabIndex = 21;
            // 
            // WhatPanel
            // 
            this.WhatPanel.Controls.Add(this.labelWhat);
            this.WhatPanel.Location = new System.Drawing.Point(0, 66);
            this.WhatPanel.Name = "WhatPanel";
            this.WhatPanel.Size = new System.Drawing.Size(434, 46);
            this.WhatPanel.TabIndex = 22;
            // 
            // Div
            // 
            this.Div.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Div.Location = new System.Drawing.Point(0, 59);
            this.Div.Name = "Div";
            this.Div.Size = new System.Drawing.Size(437, 7);
            this.Div.TabIndex = 2;
            // 
            // PopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 111);
            this.Controls.Add(this.Div);
            this.Controls.Add(this.WhatPanel);
            this.Controls.Add(this.WhoPanel);
            this.Controls.Add(this.TitlePanel);
            this.Name = "PopUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PopUpForm";
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.WhoPanel.ResumeLayout(false);
            this.WhoPanel.PerformLayout();
            this.WhatPanel.ResumeLayout(false);
            this.WhatPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label labelWhat;
        public System.Windows.Forms.Label labelWho;
        private System.Windows.Forms.Panel TitlePanel;
        public System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel WhoPanel;
        private System.Windows.Forms.Panel WhatPanel;
        private System.Windows.Forms.Panel Div;
    }
}