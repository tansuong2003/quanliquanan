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
using System.Data.SqlClient;

namespace QuanLyQuanAn.Model
{
    public partial class frmLoaiSanPhamAdd : SampleAdd
    {
        public frmLoaiSanPhamAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        private void frmSanPhamAdd_Load(object sender, EventArgs e)
        {

        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)
            {
                qry = "Insert into LOAISP Values(@MaLoaiSP,@TenLoaiSP)";
            }
            else
            {
                qry = "Update LOAISP Set MaLoaiSP = @MaLoaiSP, TenLoaiSP = @TenLoaiSP where MaLoaiSP = @MaLoaiSP and TenLoaiSP = @TenLoaiSP ";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@MaLoaiSP", txtMaLoaiSP.Text);
            ht.Add("@TenLoaiSP", txtTenLoaiSP.Text);

            if (My_DB.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Lưu thành công.");
                txtMaLoaiSP.Text = "";
                txtTenLoaiSP.Text = "";
                txtMaLoaiSP.Focus();
                txtTenLoaiSP.Focus();
            }
        }
    }
}
