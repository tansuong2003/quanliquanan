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
    public partial class frmPhanCaAdd : SampleAdd
    {
        public frmPhanCaAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
           /* qry = "Insert into BangPhanCa (MaCa,MaNV,NgayLam) Values (@MaCa,@MaNV,@NgayLam)";*/
            if (id == 0)  //Insert
            {
                qry = "Insert into BangPhanCa Values (@MaCa,@MaNV,@NgayLam)";
            }
            else  //Update
            {
                qry = "Update BangPhanCa SET MaCa = @MaCa, MaNV = @MaNV, NgayLam = @NgayLam Where MaCa = @MaCa AND MaNV = @MaNV AND NgayLam = @NgayLam ";
            }
            Hashtable ht = new Hashtable();
            ht.Add("@MaCa", cbMaCa.Text);
            ht.Add("@MaNV", txtMaNV.Text);
            ht.Add("@NgayLam", dttNgayLam.Text);

            if(My_DB.SQL(qry,ht)>0)
            {
                MessageBox.Show("Saved successfull");
                txtMaNV.Focus();
                dttNgayLam.Focus();
                cbMaCa.Focus();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
