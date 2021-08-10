using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rdp
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "http://shell-X.com");
        }

        private void git_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/shellx9/ShellX");
        }

        private void link()
        {
            if (Config.ini_password == "")
            {
                Form1 formMain = new Form1();
                formMain.Show();
                this.Hide();
            }
            else
            {
                string password = Encoding.Default.GetString(Convert.FromBase64String(Config.ini_password));
                string link_password = text_password.Text;
                link_password = link_password.Replace("\n", "");
               
                if (link_password == password)
                {
                    Form1 formMain = new Form1();
                    formMain.Show();
                    this.Hide();
                }
                else
                {
                    DialogResult result = MessageBox.Show(text: LangResx.Common.msg_password_no, caption: LangResx.Common.msg_title, buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        text_password.Text = "";
                    }
                }
            }
        }
        private void Sign_in_Click(object sender, EventArgs e)
        {

            link();
        }
        private void textBox_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                link();
            }
        }
    }
}
