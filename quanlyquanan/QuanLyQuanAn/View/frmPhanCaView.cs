using QuanLyQuanAn.Model;
using System;
using System.Collections;
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
            string qry = "Select * From v_BangPhanCa";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvMaNV);
            lb.Items.Add(dgvHoNV);
            lb.Items.Add(dgvTenNV);
            lb.Items.Add(dgvMaCa);
            lb.Items.Add(dgvNgayLam);
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
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
                {
                    // Lấy thông tin từ dòng được chọn trong DataGridView
                    string maCa = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMaCa"].Value);
                    string maNV = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMaNV"].Value);
                    string ngayLam = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvNgayLam"].Value);

                    // Tạo form chỉnh sửa và truyền thông tin từ DataGridView cho form
                    frmPhanCaAdd frm = new frmPhanCaAdd();
                    // Gán giá trị MaCa từ chuỗi vào ComboBox trên form
                    frm.cbMaCa.SelectedItem = maCa;

                    // Gán giá trị MaNV từ chuỗi vào ComboBox trên form
                    frm.txtMaNV.Text = maNV;

                    // Gán giá trị NgayLam từ chuỗi vào DateTimePicker trên form
                    frm.dttNgayLam.Value = DateTime.Parse(ngayLam);


                    // Hiển thị form chỉnh sửa
                    frm.ShowDialog();

                    // Sau khi form chỉnh sửa đóng lại, cập nhật dữ liệu trên DataGridView
                    GetData();
                }
            }*/
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                string maCa = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMaCa"].Value);
                string maNV = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMaNV"].Value);
                string ngayLam = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvNgayLam"].Value);

                // Sử dụng tham số để tránh các vấn đề bảo mật và lỗi SQL Injection.
                string qry = "DELETE FROM BangPhanCa WHERE MaCa = @MaCa AND MaNV = @MaNV AND NgayLam = @NgayLam";

                Hashtable ht = new Hashtable();
                ht.Add("@MaCa", maCa);
                ht.Add("@MaNV", maNV);
                ht.Add("@NgayLam", ngayLam);

                // Thực hiện truy vấn SQL với tham số.
                int rowsAffected = My_DB.SQL(qry, ht);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Deleted successfully");
                }

                GetData();
            }
        }
            private void guna2Button2_Click(object sender, EventArgs e)
        {
            DanhSachCaView frm = new DanhSachCaView();
            frm.ShowDialog();
        }
    }
}
