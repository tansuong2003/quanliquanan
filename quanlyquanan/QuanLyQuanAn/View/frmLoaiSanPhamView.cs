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
    public partial class frmLoaiSanPhamView : SampleView
    {
        public frmLoaiSanPhamView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * From LOAISP where TenLoaiSP like '%"+ txtSearch.Text +"%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvMaLoaiSP);
            lb.Items.Add(dgvTenLoaiSP);

            My_DB.LoadData(qry, guna2DataGridView1, lb);
        }
        public override void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmLoaiSanPhamAdd frm = new frmLoaiSanPhamAdd();
            frm.ShowDialog();
            GetData();
        }

        private void frmSanPhamView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frmLoaiSanPhamAdd frm = new frmLoaiSanPhamAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtMaLoaiSP.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMaLoaiSP"].Value);
                frm.txtTenLoaiSP.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvTenLoaiSP"].Value);
                frm.ShowDialog();
                GetData();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                string qry = "Delete from LoaiSP where ID = " + id + "";
                Hashtable ht = new Hashtable();
                My_DB.SQL(qry, ht);

                MessageBox.Show("Xóa thành công");
                GetData();
            }
        }
    }
}
