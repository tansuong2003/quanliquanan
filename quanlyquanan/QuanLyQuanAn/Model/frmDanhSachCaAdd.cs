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
    public partial class frmDanhSachCaAdd : SampleAdd
    {
        public frmDanhSachCaAdd()
        {
            InitializeComponent();
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "Insert into CALAMVIEC Values (@MaCa,@NgayLam,@GioBatDau,@GioKetThuc)";

            Hashtable ht = new Hashtable();
            ht.Add("@MaCa", cbMaCa.Text);
            ht.Add("@NgayLam", dttNgayLam.Text);
            ht.Add("@GioBatDau", txtGioBD.Text);
            ht.Add("@GioKetThuc", txtGioKT.Text);

            if (My_DB.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfull");
                txtGioBD.Focus();
                dttNgayLam.Focus();
                cbMaCa.Focus();
            }
        }

    }
}
