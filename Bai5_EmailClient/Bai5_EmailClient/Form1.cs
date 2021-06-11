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

                    name = txtEmail.Text;
                    pass = txtPass.Text;
                    ReceiveMail receiveMail = new ReceiveMail(name, pass);
                    this.Hide();
                    receiveMail.Show();
                }
                catch
                {
                    MessageBox.Show("Sai mật khẩu");
                    return;
                }

                
                client.Disconnect(true);
            }
        }
    }
}
