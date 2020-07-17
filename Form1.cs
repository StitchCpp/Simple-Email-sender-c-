using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Email_sender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox3.UseSystemPasswordChar = false;

            }
            else if(checkBox1.Checked == false)
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            Properties.Settings.Default.Email = textBox4.Text;
            Properties.Settings.Default.Save();

            Properties.Settings.Default.Password = textBox3.Text; 
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage Mail = new MailMessage();
            try
            {
                Mail.From = new MailAddress(textBox4.Text);
                Mail.Subject = textBox5.Text;
                Mail.Body = textBox2.Text;
                foreach (string s in textBox1.Text.Split(';'))

                    Mail.To.Add(s);
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(textBox4.Text, textBox3.Text);
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(Mail);
                
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                Properties.Settings.Default.Email = null;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Password = null;
                Properties.Settings.Default.Save();
                Application.Restart();
                 
            }
        }
    }
}
