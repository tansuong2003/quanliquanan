using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn.Model
{
    public partial class frmCategoryAdd : Form
    {
        public frmCategoryAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public void btnSave_Click(object sender, EventArgs e)
        {
            // Them nhan vien
            string qry = "";

            if(id == 0)//Insert
            {
                qry = "Insert into NHANVIEN Values(@MaNV,@HoNV,@TenNV,@NgaySinh,@GioiTinh,@DiaChi,@SDT,@MaCV,@SoCa,@Thuong,@NgayTD)";
            }
            else
            {
                qry = "Update NHANVIEN Set HoNV = @HoNV, TenNV = @TenNV, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SDT = @SDT, MaCV = @MaCV, Soca = @SoCa, Thuong = @Thuong, NgayTD = @NgayTD where MaNV = @MaNV";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@MaNV", txtMaNV.Text);
            ht.Add("@HoNV", txtHoNV.Text);
            ht.Add("@TenNV", txtTenNV.Text);
            ht.Add("@NgaySinh", txtNgaySinh.Text);
            ht.Add("@GioiTinh", txtGioiTinh.Text);
            ht.Add("@DiaChi", txtDiaChi.Text);
            ht.Add("@SDT", txtSDT.Text);
            ht.Add("@MaCV", txtMaCV.Text);
            ht.Add("@SoCa", txtSoCa.Text);
            ht.Add("@Thuong", txtThuong.Text);
            ht.Add("@NgayTD", txtNgayTD.Text);
           
            if (My_DB.SQl(qry, ht) > 0) 
            {
                MessageBox.Show("Save successfully..");
                id = 0;
                txtMaNV.Text = "";
                txtHoNV.Text = "";
                txtTenNV.Text = "";
                txtNgaySinh.Text = "";
                txtGioiTinh.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtMaCV.Text = "";
                txtSoCa.Text = "";
                txtThuong.Text = "";
                txtNgayTD.Text = "";
               
                txtTenNV.Focus();
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
 }




            }
