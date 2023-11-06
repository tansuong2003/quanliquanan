using Guna.UI2.WinForms;
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
using System.Data.SqlClient;
using System.Collections;

namespace QuanLyQuanAn.View
{
    public partial class DanhSachCaView : SampleView
    {
        public DanhSachCaView()
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

        private void DanhSachCaView_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public override void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmDanhSachCaAdd frm = new frmDanhSachCaAdd();
            frm.ShowDialog();
            GetData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {

        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                string maCa = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMaCa"].Value);
                string ngayLam = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvNgayLam"].Value);
                string gioBatDau = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvGioBatDau"].Value);
                string gioKetThuc = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvGioKetThuc"].Value);

                // Sử dụng tham số để tránh các vấn đề bảo mật và lỗi SQL Injection.
                string qry = "DELETE FROM CALAMVIEC WHERE MaCa = @MaCa AND NgayLam = @NgayLam AND GioBatDau = @GioBatDau AND GioKetThuc = @GioKetThuc";

                Hashtable ht = new Hashtable();
                ht.Add("@MaCa", maCa);
                ht.Add("@NgayLam", ngayLam);
                ht.Add("@GioBatDau", gioBatDau);
                ht.Add("@GioKetThuc", gioKetThuc);

                // Thực hiện truy vấn SQL với tham số.
                int rowsAffected = My_DB.SQL(qry, ht);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Deleted successfully");
                }

                GetData();
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
