namespace PeriodicFacebookPosting
{
    partial class Form1
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
            this.AttachFileWithGroups = new System.Windows.Forms.Button();
            this.PasswordTxtBox = new System.Windows.Forms.TextBox();
            this.Lbl5 = new System.Windows.Forms.Label();
            this.EmailTxtBox = new System.Windows.Forms.TextBox();
            this.Lbl4 = new System.Windows.Forms.Label();
            this.Lbl3 = new System.Windows.Forms.Label();
            this.Lbl2 = new System.Windows.Forms.Label();
            this.DelayBetweenPosting = new System.Windows.Forms.TextBox();
            this.BeginPosting = new System.Windows.Forms.Button();
            this.Lbl1 = new System.Windows.Forms.Label();
            this.Message = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // AttachFileWithGroups
            // 
            this.AttachFileWithGroups.Location = new System.Drawing.Point(12, 253);
            this.AttachFileWithGroups.Name = "AttachFileWithGroups";
            this.AttachFileWithGroups.Size = new System.Drawing.Size(126, 23);
            this.AttachFileWithGroups.TabIndex = 21;
            this.AttachFileWithGroups.Text = "Attach file with groups";
            this.AttachFileWithGroups.UseVisualStyleBackColor = true;
            this.AttachFileWithGroups.Click += new System.EventHandler(this.AttachFileWithGroups_Click);
            // 
            // PasswordTxtBox
            // 
            this.PasswordTxtBox.Location = new System.Drawing.Point(254, 6);
            this.PasswordTxtBox.Name = "PasswordTxtBox";
            this.PasswordTxtBox.PasswordChar = '*';
            this.PasswordTxtBox.Size = new System.Drawing.Size(126, 20);
            this.PasswordTxtBox.TabIndex = 20;
            // 
            // Lbl5
            // 
            this.Lbl5.AutoSize = true;
            this.Lbl5.Location = new System.Drawing.Point(192, 9);
            this.Lbl5.Name = "Lbl5";
            this.Lbl5.Size = new System.Drawing.Size(56, 13);
            this.Lbl5.TabIndex = 19;
            this.Lbl5.Text = "Password:";
            // 
            // EmailTxtBox
            // 
            this.EmailTxtBox.Location = new System.Drawing.Point(53, 6);
            this.EmailTxtBox.Name = "EmailTxtBox";
            this.EmailTxtBox.Size = new System.Drawing.Size(126, 20);
            this.EmailTxtBox.TabIndex = 18;
            // 
            // Lbl4
            // 
            this.Lbl4.AutoSize = true;
            this.Lbl4.Location = new System.Drawing.Point(12, 9);
            this.Lbl4.Name = "Lbl4";
            this.Lbl4.Size = new System.Drawing.Size(35, 13);
            this.Lbl4.TabIndex = 17;
            this.Lbl4.Text = "Email:";
            // 
            // Lbl3
            // 
            this.Lbl3.AutoSize = true;
            this.Lbl3.Location = new System.Drawing.Point(143, 225);
            this.Lbl3.Name = "Lbl3";
            this.Lbl3.Size = new System.Drawing.Size(47, 13);
            this.Lbl3.TabIndex = 16;
            this.Lbl3.Text = "seconds";
            // 
            // Lbl2
            // 
            this.Lbl2.AutoSize = true;
            this.Lbl2.Location = new System.Drawing.Point(10, 225);
            this.Lbl2.Name = "Lbl2";
            this.Lbl2.Size = new System.Drawing.Size(71, 13);
            this.Lbl2.TabIndex = 15;
            this.Lbl2.Text = "Posting every";
            // 
            // DelayBetweenPosting
            // 
            this.DelayBetweenPosting.Location = new System.Drawing.Point(84, 222);
            this.DelayBetweenPosting.Name = "DelayBetweenPosting";
            this.DelayBetweenPosting.Size = new System.Drawing.Size(54, 20);
            this.DelayBetweenPosting.TabIndex = 14;
            this.DelayBetweenPosting.Text = "600";
            this.DelayBetweenPosting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BeginPosting
            // 
            this.BeginPosting.Location = new System.Drawing.Point(308, 219);
            this.BeginPosting.Name = "BeginPosting";
            this.BeginPosting.Size = new System.Drawing.Size(91, 23);
            this.BeginPosting.TabIndex = 13;
            this.BeginPosting.Text = "Begin Posting";
            this.BeginPosting.UseVisualStyleBackColor = true;
            this.BeginPosting.Click += new System.EventHandler(this.BeginPosting_Click);
            // 
            // Lbl1
            // 
            this.Lbl1.AutoSize = true;
            this.Lbl1.Location = new System.Drawing.Point(12, 34);
            this.Lbl1.Name = "Lbl1";
            this.Lbl1.Size = new System.Drawing.Size(53, 13);
            this.Lbl1.TabIndex = 12;
            this.Lbl1.Text = "Message:";
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(13, 50);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(386, 163);
            this.Message.TabIndex = 11;
            this.Message.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 288);
            this.Controls.Add(this.AttachFileWithGroups);
            this.Controls.Add(this.PasswordTxtBox);
            this.Controls.Add(this.Lbl5);
            this.Controls.Add(this.EmailTxtBox);
            this.Controls.Add(this.Lbl4);
            this.Controls.Add(this.Lbl3);
            this.Controls.Add(this.Lbl2);
            this.Controls.Add(this.DelayBetweenPosting);
            this.Controls.Add(this.BeginPosting);
            this.Controls.Add(this.Lbl1);
            this.Controls.Add(this.Message);
            this.Name = "Form1";
            this.Text = "Facebook Automated Posting Service";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FacebookAutomatedPostingService_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FacebookAutomatedPostingService_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AttachFileWithGroups;
        private System.Windows.Forms.TextBox PasswordTxtBox;
        private System.Windows.Forms.Label Lbl5;
        private System.Windows.Forms.TextBox EmailTxtBox;
        private System.Windows.Forms.Label Lbl4;
        private System.Windows.Forms.Label Lbl3;
        private System.Windows.Forms.Label Lbl2;
        private System.Windows.Forms.TextBox DelayBetweenPosting;
        private System.Windows.Forms.Button BeginPosting;
        private System.Windows.Forms.Label Lbl1;
        private System.Windows.Forms.RichTextBox Message;
    }
}

