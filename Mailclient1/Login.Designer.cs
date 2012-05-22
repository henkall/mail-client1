namespace Mailclient1
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.but_login = new System.Windows.Forms.Button();
            this.text_user = new System.Windows.Forms.TextBox();
            this.text_psswd = new System.Windows.Forms.TextBox();
            this.text_port = new System.Windows.Forms.TextBox();
            this.check_ssl = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_host = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.view_mails = new System.Windows.Forms.TreeView();
            this.the_mail = new System.Windows.Forms.TextBox();
            this.atached_file = new System.Windows.Forms.TreeView();
            this.server_pop = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.port_pop = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.progress_Bar = new System.Windows.Forms.ProgressBar();
            this.total_msg = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baggroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_login
            // 
            this.but_login.Location = new System.Drawing.Point(21, 37);
            this.but_login.Name = "but_login";
            this.but_login.Size = new System.Drawing.Size(103, 26);
            this.but_login.TabIndex = 0;
            this.but_login.Text = "New message";
            this.but_login.UseVisualStyleBackColor = true;
            this.but_login.Click += new System.EventHandler(this.but_login_Click);
            // 
            // text_user
            // 
            this.text_user.Location = new System.Drawing.Point(207, 36);
            this.text_user.Name = "text_user";
            this.text_user.Size = new System.Drawing.Size(102, 20);
            this.text_user.TabIndex = 1;
            // 
            // text_psswd
            // 
            this.text_psswd.Location = new System.Drawing.Point(207, 63);
            this.text_psswd.Name = "text_psswd";
            this.text_psswd.PasswordChar = '*';
            this.text_psswd.Size = new System.Drawing.Size(102, 20);
            this.text_psswd.TabIndex = 2;
            // 
            // text_port
            // 
            this.text_port.Location = new System.Drawing.Point(631, 63);
            this.text_port.Name = "text_port";
            this.text_port.Size = new System.Drawing.Size(102, 20);
            this.text_port.TabIndex = 3;
            this.text_port.Text = "587";
            // 
            // check_ssl
            // 
            this.check_ssl.AutoSize = true;
            this.check_ssl.Location = new System.Drawing.Point(207, 89);
            this.check_ssl.Name = "check_ssl";
            this.check_ssl.Size = new System.Drawing.Size(60, 17);
            this.check_ssl.TabIndex = 4;
            this.check_ssl.Text = "Secure";
            this.check_ssl.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(569, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port smtp";
            // 
            // text_host
            // 
            this.text_host.Location = new System.Drawing.Point(440, 62);
            this.text_host.Name = "text_host";
            this.text_host.Size = new System.Drawing.Size(102, 20);
            this.text_host.TabIndex = 8;
            this.text_host.Text = "smtp.gmail.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Server smtp";
            // 
            // view_mails
            // 
            this.view_mails.Location = new System.Drawing.Point(12, 124);
            this.view_mails.Name = "view_mails";
            this.view_mails.Size = new System.Drawing.Size(282, 236);
            this.view_mails.TabIndex = 10;
            // 
            // the_mail
            // 
            this.the_mail.Location = new System.Drawing.Point(300, 124);
            this.the_mail.Multiline = true;
            this.the_mail.Name = "the_mail";
            this.the_mail.Size = new System.Drawing.Size(266, 236);
            this.the_mail.TabIndex = 11;
            // 
            // atached_file
            // 
            this.atached_file.Location = new System.Drawing.Point(572, 124);
            this.atached_file.Name = "atached_file";
            this.atached_file.Size = new System.Drawing.Size(183, 124);
            this.atached_file.TabIndex = 12;
            // 
            // server_pop
            // 
            this.server_pop.Location = new System.Drawing.Point(440, 36);
            this.server_pop.Name = "server_pop";
            this.server_pop.Size = new System.Drawing.Size(102, 20);
            this.server_pop.TabIndex = 13;
            this.server_pop.Text = "pop.gmail.com";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Server pop";
            // 
            // port_pop
            // 
            this.port_pop.Location = new System.Drawing.Point(631, 37);
            this.port_pop.Name = "port_pop";
            this.port_pop.Size = new System.Drawing.Size(102, 20);
            this.port_pop.TabIndex = 15;
            this.port_pop.Text = "995";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(569, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Port pop";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFile
            // 
            this.saveFile.Title = "Save Attachment";
            // 
            // progress_Bar
            // 
            this.progress_Bar.Location = new System.Drawing.Point(12, 366);
            this.progress_Bar.Name = "progress_Bar";
            this.progress_Bar.Size = new System.Drawing.Size(743, 23);
            this.progress_Bar.TabIndex = 18;
            // 
            // total_msg
            // 
            this.total_msg.Location = new System.Drawing.Point(21, 98);
            this.total_msg.Name = "total_msg";
            this.total_msg.Size = new System.Drawing.Size(56, 20);
            this.total_msg.TabIndex = 19;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(767, 24);
            this.menuStrip.TabIndex = 21;
            this.menuStrip.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baggroundColorToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // baggroundColorToolStripMenuItem
            // 
            this.baggroundColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blueToolStripMenuItem,
            this.greyToolStripMenuItem,
            this.testToolStripMenuItem});
            this.baggroundColorToolStripMenuItem.Name = "baggroundColorToolStripMenuItem";
            this.baggroundColorToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.baggroundColorToolStripMenuItem.Text = "Bagground color";
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
            // 
            // greyToolStripMenuItem
            // 
            this.greyToolStripMenuItem.Name = "greyToolStripMenuItem";
            this.greyToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.greyToolStripMenuItem.Text = "Grey";
            this.greyToolStripMenuItem.Click += new System.EventHandler(this.greyToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 401);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.total_msg);
            this.Controls.Add(this.progress_Bar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.port_pop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.server_pop);
            this.Controls.Add(this.atached_file);
            this.Controls.Add(this.the_mail);
            this.Controls.Add(this.view_mails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_host);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.check_ssl);
            this.Controls.Add(this.text_port);
            this.Controls.Add(this.text_psswd);
            this.Controls.Add(this.text_user);
            this.Controls.Add(this.but_login);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_login;
        private System.Windows.Forms.TextBox text_user;
        private System.Windows.Forms.TextBox text_psswd;
        private System.Windows.Forms.TextBox text_port;
        private System.Windows.Forms.CheckBox check_ssl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_host;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView view_mails;
        private System.Windows.Forms.TextBox the_mail;
        private System.Windows.Forms.TreeView atached_file;
        private System.Windows.Forms.TextBox server_pop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox port_pop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.ProgressBar progress_Bar;
        private System.Windows.Forms.TextBox total_msg;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baggroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    }
}