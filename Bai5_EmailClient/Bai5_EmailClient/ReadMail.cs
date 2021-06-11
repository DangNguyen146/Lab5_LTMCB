using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5_EmailClient
{
    public partial class ReadMail : Form
    {
        string name, pass, from, body;

        private void button1_Click(object sender, EventArgs e)
        {
            SendMail sendMail = new SendMail(this.name, this.pass);
            sendMail.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendMail sendMail = new SendMail(this.name, this.pass, this.from);
            sendMail.Show();
            this.Close();

        }

        public ReadMail(string name, string pass, string from,string body)
        {
            InitializeComponent();
            this.name = name;
            this.pass = pass;
            this.from = from;
            this.body = body;
            txtFrom.Text = name;
            txtTo.Text = from;
            txtBody.Text = body;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
