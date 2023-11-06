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
    public partial class frmSanPhamView : SampleView
    {
        public frmSanPhamView()
        {
            InitializeComponent();
        }

        private void frmSanPhamView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            string qry = "Select * From v_DanhSachSP";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvMaSP);
            lb.Items.Add(dgvTenSP);
            lb.Items.Add(dgvDonGia);
            lb.Items.Add(dgvTinhTrang);
            lb.Items.Add(dgvMaLoaiSP);

            My_DB.LoadData(qry, guna2DataGridView1, lb);
        }

        public override void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmSanPhamAdd frm = new frmSanPhamAdd();
            frm.ShowDialog();
            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frmSanPhamAdd frm = new frmSanPhamAdd();
                //frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtMaSP.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMaSP"].Value);
                frm.txtTenSP.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvTenSP"].Value);
                frm.txtDonGia.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvDonGia"].Value);
                frm.cbTinhTrang.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvTinhTrang"].Value);
                frm.ShowDialog();
                GetData();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                String MaSP = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMaSP"].Value);
                string qry = "Delete from SANPHAM where MaSP = " + MaSP + "";
                Hashtable ht = new Hashtable();
                My_DB.SQL(qry, ht);

                MessageBox.Show("Xóa thành công");
                GetData();
            }
        }
    }
}
