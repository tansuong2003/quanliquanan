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
    public partial class frmCategoryAdd : SampleAdd
    {
        public frmCategoryAdd()
        {
            InitializeComponent();
        }

        private void frmCategoryAdd_Load(object sender, EventArgs e)
        {

        }
        private int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            string qry = "";
            if (id == 0)
            {
                qry = "Insert into proc_themNguyenLieu Values (@MaNL, @TenNL, @MaNCC, @SL, @DonVi, @TinhTrang)";
            }
            else
            {
                qry = "Update NGUYENLIEU SET MaNL = @MaNL, TenNL = @TenNL, MaNCC = @MaNCC, SL = @SL, DonVi = @DonVi, TinhTrang = @TinhTrang WHERE MaNL = @MaNL, TenNL = @TenNL, MaNCC = @MaNCC, SL = @SL, DonVi = @DonVi, TinhTrang = @TinhTrang";
            }
            ht.Add("@MaNL", txtMaNL.Text);
            ht.Add("@TenNL", txtTenNL.Text);
            ht.Add("@MaNCC", txtMaNCC.Text);
            ht.Add("@SL", txtSL.Text);
            ht.Add("@DonVi", txtDonVi.Text);
            ht.Add("@TinhTrang", txtTinhTrang.Text);
            if (My_DB.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfull");
                id = 0;
                txtMaNL.Focus();
                txtTenNL.Focus();
                txtMaNCC.Focus();
                txtSL.Focus();
                txtDonVi.Focus();
                txtTinhTrang.Focus();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
