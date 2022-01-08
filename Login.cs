using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace doanv1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textuser.Text == "admin" && textpass.Text == "admin")
            {
                Form1 n = new Form1();
                n.Show();
               

            }
            else
            {
                MessageBox.Show("Tài khoản/mật khẩu mặc định là admin/admin");
            }                
        }

        private void Login_Load(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textuser.Clear();
            textpass.Clear();
        }

        private void textpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
