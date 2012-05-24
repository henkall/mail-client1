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
using System.Security.Cryptography;
using System.IO;

namespace Mailclient1
{
    public partial class New_msg : Form
    {
        private string from_mail = "NULL";
        private string passwd = "NULL";
        private string server_add = "NULL";
        private int server_port = 0;
        private bool ssl = false;
        private Rijndael myKey;

        public New_msg(string from_mail, string password, string server_add, int port, bool ssl, Rijndael myKey)
        {
            InitializeComponent();
            this.from_mail = from_mail;
            this.passwd = password;
            this.server_add = server_add;
            this.server_port = port;
            this.ssl = ssl;
            this.myKey = myKey;
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
            
            byte[] encrypted = EncryptStringToBytes(text_msg.Text, myKey.Key, myKey.IV);
            using (MailMessage msg = new MailMessage(from_add, to_add) { Subject = box_sub.Text, Body = System.Convert.ToBase64String(encrypted) })
            {
                smtp.Send(msg);
                MessageBox.Show("Mail send");
                this.Close();
            }
        }
        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

    }
}
