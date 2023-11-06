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

namespace QuanLyQuanAn.Model
{
    public partial class frmSanPhamAdd : SampleAdd
    {
        public frmSanPhamAdd()
        {
            InitializeComponent();
        }

        int id = 0;
        private void frmSanPhamAdd_Load(object sender, EventArgs e)
        {

        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)
            {
                qry = "Insert into SANPHAM Values(@MaSP,@TenSP,@DonGia,@TinhTrang,@MaLoaiSP)";
            }
            else
            {
                qry = "Update SANPHAM Set MaSP = @MaSP, TenSP = @TenSP, DonGia = @DonGia, TinhTrang = @TinhTrang, MaLoaiSP = @MaLoaiSP " +
                    "where MaSP = @MaSP and TenSP = @TenSP and DonGia = @DonGia and TinhTrang = @TinhTrang and MaLoaiSP = @MaLoaiSP ";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@MaSP", txtMaSP.Text);
            ht.Add("@TenSP", txtTenSP.Text);
            ht.Add("@DonGia", txtDonGia.Text);
            ht.Add("@TinhTrang", cbTinhTrang.Text);
            ht.Add("@MaLoaiSP", txtMaLoaiSP.Text);

            if (My_DB.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Lưu thành công.");
                txtMaSP.Text = "";
                txtTenSP.Text = "";
                txtDonGia.Text = "";
                cbTinhTrang.SelectedIndex = -1;
                txtMaLoaiSP.Text = "";
                txtMaSP.Focus();
                txtTenSP.Focus();
                txtDonGia.Focus();
                cbTinhTrang.Focus();
                txtMaLoaiSP.Focus();
            }
        }
    }
}
