namespace Mailclient1
{
    partial class New_msg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(New_msg));
            this.text_msg = new System.Windows.Forms.RichTextBox();
            this.but_send = new System.Windows.Forms.Button();
            this.box_to = new System.Windows.Forms.TextBox();
            this.box_sub = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text_msg
            // 
            this.text_msg.Location = new System.Drawing.Point(12, 66);
            this.text_msg.Name = "text_msg";
            this.text_msg.Size = new System.Drawing.Size(379, 263);
            this.text_msg.TabIndex = 0;
            this.text_msg.Text = "";
            // 
            // but_send
            // 
            this.but_send.Location = new System.Drawing.Point(13, 13);
            this.but_send.Name = "but_send";
            this.but_send.Size = new System.Drawing.Size(75, 23);
            this.but_send.TabIndex = 1;
            this.but_send.Text = "Send";
            this.but_send.UseVisualStyleBackColor = true;
            this.but_send.Click += new System.EventHandler(this.but_send_Click);
            // 
            // box_to
            // 
            this.box_to.Location = new System.Drawing.Point(177, 13);
            this.box_to.Name = "box_to";
            this.box_to.Size = new System.Drawing.Size(213, 20);
            this.box_to.TabIndex = 2;
            // 
            // box_sub
            // 
            this.box_sub.Location = new System.Drawing.Point(177, 40);
            this.box_sub.Name = "box_sub";
            this.box_sub.Size = new System.Drawing.Size(212, 20);
            this.box_sub.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subject";
            // 
            // New_msg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 357);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.box_sub);
            this.Controls.Add(this.box_to);
            this.Controls.Add(this.but_send);
            this.Controls.Add(this.text_msg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "New_msg";
            this.Text = "New Message";
            this.Load += new System.EventHandler(this.New_msg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox text_msg;
        private System.Windows.Forms.Button but_send;
        private System.Windows.Forms.TextBox box_to;
        private System.Windows.Forms.TextBox box_sub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}