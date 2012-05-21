namespace Mailclient1
{
    partial class MailClient
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
            this.but_new = new System.Windows.Forms.Button();
            this.mail_list = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // but_new
            // 
            this.but_new.Location = new System.Drawing.Point(13, 13);
            this.but_new.Name = "but_new";
            this.but_new.Size = new System.Drawing.Size(75, 23);
            this.but_new.TabIndex = 0;
            this.but_new.Text = "New msg";
            this.but_new.UseVisualStyleBackColor = true;
            this.but_new.Click += new System.EventHandler(this.but_new_Click);
            // 
            // mail_list
            // 
            this.mail_list.Location = new System.Drawing.Point(12, 66);
            this.mail_list.Name = "mail_list";
            this.mail_list.Size = new System.Drawing.Size(306, 241);
            this.mail_list.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mails";
            // 
            // MailClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 325);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mail_list);
            this.Controls.Add(this.but_new);
            this.Name = "MailClient";
            this.Text = "MailClient";
            this.Load += new System.EventHandler(this.MailClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_new;
        private System.Windows.Forms.TreeView mail_list;
        private System.Windows.Forms.Label label1;
    }
}

