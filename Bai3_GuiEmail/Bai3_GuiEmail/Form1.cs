using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3_GuiEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            using (SmtpClient smtpClient = new SmtpClient("127.0.0.1"))
            {
                string mailfrom = txtFrom.Text.ToString().Trim();
                string mailto = txtTo.Text.ToString().Trim();
                string password = txtPass.Text.ToString().Trim();
                var basicCredential = new NetworkCredential(mailfrom, password);
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress(mailfrom);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;
                    message.From = fromAddress;
                    message.Subject = txtSub.Text.ToString().Trim();
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = txtBody.Text.ToString();
                    message.To.Add(mailto);
                    try
                    {
                        smtpClient.Send(message);
                        MessageBox.Show("Thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {

        }
    }
}
