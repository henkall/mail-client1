using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Mailclient1
{
    public partial class New_msg : Form
    {
        private string from_mail = "NULL";
        private string passwd = "NULL";
        private string server_add = "NULL";
        private int server_port = 0;
        private bool ssl = false;
        public New_msg(string from_mail, string password, string server_add, int port, bool ssl)
        {
            InitializeComponent();
            this.from_mail = from_mail;
            this.passwd = password;
            this.server_add = server_add;
            this.server_port = port;
            this.ssl = ssl;
        }

        private void but_send_Click(object sender, EventArgs e)
        {
            MailAddress to_add = new MailAddress(box_to.Text);
            MailAddress from_add = new MailAddress(from_mail);
            SmtpClient smtp = new SmtpClient
                {
                    Host = server_add,
                    Port = server_port,
                    EnableSsl = ssl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(from_add.Address, passwd)
                };
            using (MailMessage msg = new MailMessage(from_add, to_add) { Subject = box_sub.Text, Body = text_msg.Text })
            {
                smtp.Send(msg);
                MessageBox.Show("Mail send");
                this.Close();
            }
        }
    }
}
