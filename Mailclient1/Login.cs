using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/// Openpop
using OpenPop.Mime;
using OpenPop.Mime.Header;
using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using OpenPop.Common.Logging;
using Message = OpenPop.Mime.Message;
using System.IO;
///Openpop end


namespace Mailclient1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            pop3Client = new Pop3Client();
            /// Makes the onclick work
            view_mails.AfterSelect += new TreeViewEventHandler(ListMessagesMessageSelected);
            atached_file.AfterSelect += new TreeViewEventHandler(ListAttachmentsAttachmentSelected);
        }

        private void but_login_Click(object sender, EventArgs e)
        {
         
            Form MailClient = new New_msg(text_user.Text, text_psswd.Text, text_host.Text, Convert.ToInt32(text_port.Text),check_ssl.Checked);
            MailClient.ShowDialog();
        } /// Opens new form for new msg

        private void button1_Click(object sender, EventArgs e)
        {
            ReceiveMails();
            SavingSettings();
        } /// Executing the functions

        private readonly Dictionary<int, Message> messages = new Dictionary<int, Message>();
        private readonly Pop3Client pop3Client;
        
        private void ReceiveMails()
        {
            try
            {
                if (pop3Client.Connected)
                    pop3Client.Disconnect();
                    pop3Client.Connect(server_pop.Text, int.Parse(port_pop.Text), check_ssl.Checked);
                    pop3Client.Authenticate(text_user.Text, text_psswd.Text);
                    int count = pop3Client.GetMessageCount();
                    total_msg.Text = count.ToString();
                    the_mail.Text = "";
                    messages.Clear();
                    view_mails.Nodes.Clear();
                    atached_file.Nodes.Clear();

                int success = 0;
                int fail = 0;
                for (int i = count; i >= 1; i -= 1)
                {
                    // Check if the form is closed while we are working. If so, abort
                    if (IsDisposed)
                        return;

                    // Refresh the form while fetching emails
                    // This will fix the "Application is not responding" problem
                    Application.DoEvents();

                    try
                    {
                        Message message = pop3Client.GetMessage(i);

                        // Add the message to the dictionary from the messageNumber to the Message
                        messages.Add(i, message);

                        // Create a TreeNode tree that mimics the Message hierarchy
                        TreeNode node = new TreeNodeBuilder().VisitMessage(message);

                        // Set the Tag property to the messageNumber
                        // We can use this to find the Message again later
                        node.Tag = i;

                        // Show the built node in our list of messages
                        view_mails.Nodes.Add(node);

                        success++;
                    }
                    catch (Exception e)
                    {
                        DefaultLogger.Log.LogError(
                            "TestForm: Message fetching failed: " + e.Message + "\r\n" +
                            "Stack trace:\r\n" +
                            e.StackTrace);
                        fail++;
                    }

                    progress_Bar.Value = (int)(((double)(count - i) / count) * 100);
                }

                MessageBox.Show(this, "Mail received!\nSuccesses: " + success + "\nFailed: " + fail, "Message fetching done");

                if (fail > 0)
                {
                    MessageBox.Show(this,
                                    "Since some of the emails were not parsed correctly (exceptions were thrown)\r\n" +
                                    "please consider sending your log file to the developer for fixing.\r\n" +
                                    "If you are able to include any extra information, please do so.",
                                    "Help improve OpenPop!");
                }
            }
            catch (InvalidLoginException)
            {
                MessageBox.Show(this, "The server did not accept the user credentials!", "POP3 Server Authentication");
            }
            catch (PopServerNotFoundException)
            {
                MessageBox.Show(this, "The server could not be found", "POP3 Retrieval");
            }
            catch (PopServerLockedException)
            {
                MessageBox.Show(this, "The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
            }
            catch (LoginDelayException)
            {
                MessageBox.Show(this, "Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Error occurred retrieving mail. " + e.Message, "POP3 Retrieval");
            }
            finally
            {
                /// Enable the buttons again
                ///connectAndRetrieveButton.Enabled = true;
                ///uidlButton.Enabled = true;
                progress_Bar.Value = 100;
            }
        } /// Makes pop connection and gets mail

        private void SavingSettings() 
        {
            Properties.Settings.Default.usingSpop = server_pop.Text;
            Properties.Settings.Default.usingSsmtp = text_host.Text;
            Properties.Settings.Default.usingPOPport = port_pop.Text;
            Properties.Settings.Default.usingSMTPport = text_port.Text;
            Properties.Settings.Default.usingCheckssl = check_ssl.Checked;
            Properties.Settings.Default.Save();

        } /// Saves setting typed in
        
        private void ListMessagesMessageSelected(object sender, TreeViewEventArgs e)
        {
            // Fetch out the selected message
            Message message = messages[GetMessageNumberFromSelectedNode(view_mails.SelectedNode)];

            // If the selected node contains a MessagePart and we can display the contents - display them
            if (view_mails.SelectedNode.Tag is MessagePart)
            {
                MessagePart selectedMessagePart = (MessagePart)view_mails.SelectedNode.Tag;
                if (selectedMessagePart.IsText)
                {
                    // We can show text MessageParts
                    the_mail.Text = selectedMessagePart.GetBodyAsText();
                }
                else
                {
                    // We are not able to show non-text MessageParts (MultiPart messages, images, pdf's ...)
                    the_mail.Text = "<<OpenPop>> Cannot show this part of the email. It is not text <<OpenPop>>";
                }
            }
            else
            {
                // If the selected node is not a subnode and therefore does not
                // have a MessagePart in it's Tag property, we genericly find some content to show

                // Find the first text/plain version
                MessagePart plainTextPart = message.FindFirstPlainTextVersion();
                if (plainTextPart != null)
                {
                    // The message had a text/plain version - show that one
                    the_mail.Text = plainTextPart.GetBodyAsText();
                }
                else
                {
                    // Try to find a body to show in some of the other text versions
                    List<MessagePart> textVersions = message.FindAllTextVersions();
                    if (textVersions.Count >= 1)
                        the_mail.Text = textVersions[0].GetBodyAsText();
                    else
                        the_mail.Text = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
                }
            }

            // Clear the attachment list from any previus shown attachments
            atached_file.Nodes.Clear();

            // Build up the attachment list
            List<MessagePart> attachments = message.FindAllAttachments();
            foreach (MessagePart attachment in attachments)
            {
                // Add the attachment to the list of attachments
                TreeNode addedNode = atached_file.Nodes.Add((attachment.FileName));

                // Keep a reference to the attachment in the Tag property
                addedNode.Tag = attachment;
            }

            // Only show that attachmentPanel if there is attachments in the message
            bool hadAttachments = attachments.Count > 0;
            ///attachmentPanel.Visible = hadAttachments;

            // Generate header table
            DataSet dataSet = new DataSet();
            DataTable table = dataSet.Tables.Add("Headers");
            table.Columns.Add("Header");
            table.Columns.Add("Value");

            DataRowCollection rows = table.Rows;

            // Add all known headers
            rows.Add(new object[] { "Content-Description", message.Headers.ContentDescription });
            rows.Add(new object[] { "Content-Id", message.Headers.ContentId });
            foreach (string keyword in message.Headers.Keywords) rows.Add(new object[] { "Keyword", keyword });
            foreach (RfcMailAddress dispositionNotificationTo in message.Headers.DispositionNotificationTo) rows.Add(new object[] { "Disposition-Notification-To", dispositionNotificationTo });
            foreach (Received received in message.Headers.Received) rows.Add(new object[] { "Received", received.Raw });
            rows.Add(new object[] { "Importance", message.Headers.Importance });
            rows.Add(new object[] { "Content-Transfer-Encoding", message.Headers.ContentTransferEncoding });
            foreach (RfcMailAddress cc in message.Headers.Cc) rows.Add(new object[] { "Cc", cc });
            foreach (RfcMailAddress bcc in message.Headers.Bcc) rows.Add(new object[] { "Bcc", bcc });
            foreach (RfcMailAddress to in message.Headers.To) rows.Add(new object[] { "To", to });
            rows.Add(new object[] { "From", message.Headers.From });
            rows.Add(new object[] { "Reply-To", message.Headers.ReplyTo });
            foreach (string inReplyTo in message.Headers.InReplyTo) rows.Add(new object[] { "In-Reply-To", inReplyTo });
            foreach (string reference in message.Headers.References) rows.Add(new object[] { "References", reference });
            rows.Add(new object[] { "Sender", message.Headers.Sender });
            rows.Add(new object[] { "Content-Type", message.Headers.ContentType });
            rows.Add(new object[] { "Content-Disposition", message.Headers.ContentDisposition });
            rows.Add(new object[] { "Date", message.Headers.Date });
            rows.Add(new object[] { "Date", message.Headers.DateSent });
            rows.Add(new object[] { "Message-Id", message.Headers.MessageId });
            rows.Add(new object[] { "Mime-Version", message.Headers.MimeVersion });
            rows.Add(new object[] { "Return-Path", message.Headers.ReturnPath });
            rows.Add(new object[] { "Subject", message.Headers.Subject });

            // Add all unknown headers
            foreach (string key in message.Headers.UnknownHeaders)
            {
                string[] values = message.Headers.UnknownHeaders.GetValues(key);
                if (values != null)
                    foreach (string value in values)
                    {
                        rows.Add(new object[] { key, value });
                    }
            }

        }

        /// <summary>
        /// Finds the MessageNumber of a Message given a <see cref="TreeNode"/> to search in.
        /// The root of this <see cref="TreeNode"/> should have the Tag property set to a int, which
        /// points into the <see cref="messages"/> dictionary.
        /// </summary>
        /// <param name="node">The <see cref="TreeNode"/> to look in. Cannot be <see langword="null"/>.</param>
        /// <returns>The found int</returns>
        private static int GetMessageNumberFromSelectedNode(TreeNode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            // Check if we are at the root, by seeing if it has the Tag property set to an int
            if (node.Tag is int)
            {
                return (int)node.Tag;
            }

            // Otherwise we are not at the root, move up the tree
            return GetMessageNumberFromSelectedNode(node.Parent);
        }
        
        private void ListAttachmentsAttachmentSelected(object sender, TreeViewEventArgs args)
        {
            // Fetch the attachment part which is currently selected
            MessagePart attachment = (MessagePart)atached_file.SelectedNode.Tag;

            if (attachment != null)
            {
                saveFile.FileName = attachment.FileName;
                DialogResult result = saveFile.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                // Now we want to save the attachment
                FileInfo file = new FileInfo(saveFile.FileName);

                // Check if the file already exists
                if (file.Exists)
                {
                    // User was asked when he chose the file, if he wanted to overwrite it
                    // Therefore, when we get to here, it is okay to delete the file
                    file.Delete();
                }

                // Lets try to save to the file
                try
                {
                    attachment.Save(file);

                    MessageBox.Show(this, "Attachment saved successfully");
                }
                catch (Exception e)
                {
                    MessageBox.Show(this, "Attachment saving failed. Exception message: " + e.Message);
                }
            }
            else
            {
                MessageBox.Show(this, "Attachment object was null!");
            }
        }
        
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.myFavoriteColor;
            Properties.Settings.Default.usingDefaultBGC = this.BackColor;
            Properties.Settings.Default.Save();
        } /// Changing Backgroud color

        private void greyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.myDefaultColor;
            Properties.Settings.Default.usingDefaultBGC = this.BackColor;
            Properties.Settings.Default.Save();
        } /// Changing Backgroud color

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = Properties.Settings.Default.mySetting;
        } /// Changing Text in Form

        private void Login_Load(object sender, EventArgs e)
        {

            server_pop.Text = Properties.Settings.Default.usingSpop;
            text_host.Text = Properties.Settings.Default.usingSsmtp;
            port_pop.Text = Properties.Settings.Default.usingPOPport;
            text_port.Text = Properties.Settings.Default.usingSMTPport;
            check_ssl.Checked = Properties.Settings.Default.usingCheckssl;
            this.BackColor = Properties.Settings.Default.usingDefaultBGC;
            this.Text = Properties.Settings.Default.usingDSetting;
        } /// Loading Saved settings on Form load
        
        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        } /// Closes program
    }
}
