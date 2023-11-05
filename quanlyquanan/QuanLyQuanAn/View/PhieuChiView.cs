using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn.View
{
    public partial class PhieuChiView : SampleView
    {
        public PhieuChiView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * From v_DonNhapHangView";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvMaDonNH);
            lb.Items.Add(dgvNgayNH);
            lb.Items.Add(dgvMaNCC);
            lb.Items.Add(dgvTinhTrang);
            lb.Items.Add(dgvMaPC);
            lb.Items.Add(dgvNgayXuatPhieu);
            lb.Items.Add(dgvMaNL);
            lb.Items.Add(dgvDonGia);
            lb.Items.Add(dgvSL);
            lb.Items.Add(dgvDonVi);
            lb.Items.Add(dgvSoTienChi);
            My_DB.LoadData(qry, guna2DataGridView1, lb);
        }

        private void PhieuChiView_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public override void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            /*frmPhanCaAdd frm = new frmPhanCaAdd();
            frm.ShowDialog();
            GetData();*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
