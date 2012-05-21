using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/// OpenPop copy paste
using OpenPop.Common.Logging;
using OpenPop.Mime;
using OpenPop.Mime.Decode;
using OpenPop.Mime.Header;
using OpenPop.Pop3;
/// End copy paste

namespace Mailclient1
{
    public partial class MailClient : Form
    {
        private string user = "";
        private string password = "";
        private string server_add = "";
        private int port = 0;
        private bool ssl = false;
        public MailClient(string user, string password, string server_add, int port, bool ssl)
        {
            InitializeComponent();
            this.user = user;
            this.password = password;
            this.server_add = server_add;
            this.port = port;
            this.ssl = ssl;
        }

        private void but_new_Click(object sender, EventArgs e)
        {
            Form new_mail = new New_msg(user,password,server_add,port,ssl);
            new_mail.ShowDialog();
        }

        private void MailClient_Load(object sender, EventArgs e)
        {
            using(Pop3Client client = new Pop3Client())
            {
                client.Connect("pop.gmail.com", 995, ssl);
                client.Authenticate(user, password);
                int MessageCount = client.GetMessageCount();
                MessageHeader h = client.GetMessageHeaders(MessageCount);
                List<int> deleteIndexes = new List<int>();
                
                for (int index = 1; index <= MessageCount; index++) 
                {
                    try 
                    {
                        
                        OpenPop.Mime.Message message = null;
                        try
                        {
                            message = client.GetMessage(index);
                        }
                        catch 
                        {

                        }
                        MessageHeader Headers = message.Headers;

                        RfcMailAddress FromMail = Headers.From;
                        string Subject = Headers.Subject;
                        string From = FromMail.Address;
                        string ReceivedDate = Headers.DateSent.ToLocalTime().ToString();
                    }
                    catch
                    {

                    }
                }


            }
        }
    }
}
