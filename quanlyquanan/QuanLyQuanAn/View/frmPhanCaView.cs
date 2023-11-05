using QuanLyQuanAn.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn.View
{
    public partial class frmPhanCaView : SampleView
    {
        public frmPhanCaView()
        {
            InitializeComponent();
        }


        public void GetData()
        {
            string qry = "Select * From v_CaLamViec";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvMaCa);
            lb.Items.Add(dgvNgayLam);
            lb.Items.Add(dgvGioBatDau);
            lb.Items.Add(dgvGioKetThuc);
            My_DB.LoadData(qry, guna2DataGridView1, lb);
        }

        private void frmPhanCaView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        public override void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            /*GetData();*/
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmPhanCaAdd frm = new frmPhanCaAdd();
            frm.ShowDialog();
            GetData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
