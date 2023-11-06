using QuanLyQuanAn.Model;
using System;
using System.Collections;
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
    public partial class frmStaffView : SampleView
    {
        public string MaNV { get; private set; }

        public frmStaffView()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            string qry = "Select * From NHANVIEN where TenNV like '%"+ txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvMaNV);
            lb.Items.Add(dgvHoNV);
            lb.Items.Add(dgvTenNV);
            lb.Items.Add(dgvNgaySinh);
            lb.Items.Add(dgvGioiTinh);
            lb.Items.Add(dgvDiaChi);
            lb.Items.Add(dgvSDT);
            lb.Items.Add(dgvMaCV);
            lb.Items.Add(dgvSoCa);
            lb.Items.Add(dgvThuong);
            lb.Items.Add(dgvNgayTD);

            My_DB.LoadData(qry, guna2DataGridView1, lb);

        }
        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm = new frmCategoryAdd();
            frm.ShowDialog();
            GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //let create table first

            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                // gọi hàm chỉnh sửa
                frmCategoryAdd frm = new frmCategoryAdd();
                //frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvMaNV"].Value);
                frm.txtTenNV.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvTenNV"].Value);
                frm.txtHoNV.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvHoNV"].Value);
                frm.txtMaNV.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMaNV"].Value);
                frm.ShowDialog();
                GetData();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                //gọi hàm xóa
                //int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvMaNV"].Value);
                string MaNV = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMaNV"].Value);
                string qry = "Delete from NHANVIEN where MaNV = @MaNV";
                Hashtable ht = new Hashtable();
                ht.Add("@MaNV", MaNV);
                My_DB.SQl(qry, ht);

                MessageBox.Show("Deleted successfully");
                GetData();
            }
        }
    }
}
