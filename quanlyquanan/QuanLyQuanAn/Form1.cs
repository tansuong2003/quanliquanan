using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(My_DB.IsValidUser(txtUser.Text,txtPass.Text)==false) 
            {
                guna2MessageDialog1.Show("invalid username or password");
                return;
            }
            else
            {
                this.Hide();
                frmMain frm = new frmMain();
                frm.Show();
            }
        }
    }
}
