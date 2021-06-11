using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using System.Security.Authentication;
using MailKit.Security;

namespace Bai5_EmailClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string name;
        string pass;
        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new ImapClient())
            {
                client.CheckCertificateRevocation = false;
                client.Connect("127.0.0.1", 143, SecureSocketOptions.None);
                try
                {
                    client.Authenticate(txtEmail.Text, txtPass.Text);
                    MessageBox.Show("Thành công");
                }
                catch
                {
                    MessageBox.Show("Sai mật khẩu");
                    return;
                }

                name = txtEmail.Text;
                pass = txtPass.Text;
                label4.Visible = true;
                label5.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                txtEmail.Visible = false;
                txtPass.Visible = false;
                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                lbTotal.Visible = true;
                lbTotal.Text = inbox.Count.ToString();
                lbRecent.Visible = true;
                lbRecent.Text = inbox.Recent.ToString();


                listView1.Visible = true;
                listView1.Columns.Add("Email", 200);
                listView1.Columns.Add("From", 100);
                listView1.Columns.Add("Thời gian", 100);
                listView1.View = View.Details;
                for (int i = 0; i < inbox.Count; i++)
                {
                    var message = inbox.GetMessage(i);
                    ListViewItem name = new ListViewItem(message.Subject);
                    ListViewItem.ListViewSubItem from = new
                    ListViewItem.ListViewSubItem(name, message.From.ToString());
                    name.SubItems.Add(from);
                    ListViewItem.ListViewSubItem date = new
                    ListViewItem.ListViewSubItem(name, message.Date.Date.ToString());
                    name.SubItems.Add(date);
                    listView1.Items.Add(name);
                }

                client.Disconnect(true);
            }
        }
    }
}
