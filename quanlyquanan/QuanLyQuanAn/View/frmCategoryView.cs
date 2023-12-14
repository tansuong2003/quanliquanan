using QuanLyQuanAn.Model;
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
    public partial class frmCategoryView : SampleView
    {
        public frmCategoryView()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            string qry = "Select * FROM view_NguyenLieu";

            ListBox lb = new ListBox();
            lb.Items.Add(dgvMaNL);
            lb.Items.Add(dgvTenNL);
            lb.Items.Add(dgvMaNCC);
            lb.Items.Add(dgvSL);
            lb.Items.Add(dgvDonVi);
            lb.Items.Add(dgvTinhTrang);
            
            My_DB.LoadData(qry, guna2DataGridView2, lb);
        }
        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            GetData();       
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {

        }

        public override void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            frmCategoryAdd frmCategoryAdd = new frmCategoryAdd();
            frmCategoryAdd.ShowDialog();
            GetData();

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
