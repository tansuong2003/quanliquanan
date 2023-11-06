namespace QuanLyQuanAn.Model
{
    partial class frmDanhSachCaAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dttNgayLam = new System.Windows.Forms.DateTimePicker();
            this.txtGioBD = new System.Windows.Forms.TextBox();
            this.cbMaCa = new System.Windows.Forms.ComboBox();
            this.txtGioKT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.Text = "Danh Sách Ca Làm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Ca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày Làm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giờ Bắt Đầu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Giờ Kết Thúc";
            // 
            // dttNgayLam
            // 
            this.dttNgayLam.CustomFormat = "yyyy/MM/dd";
            this.dttNgayLam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttNgayLam.Location = new System.Drawing.Point(145, 207);
            this.dttNgayLam.Name = "dttNgayLam";
            this.dttNgayLam.Size = new System.Drawing.Size(121, 26);
            this.dttNgayLam.TabIndex = 14;
            this.dttNgayLam.Value = new System.DateTime(2023, 11, 2, 0, 0, 0, 0);
            // 
            // txtGioBD
            // 
            this.txtGioBD.Location = new System.Drawing.Point(145, 254);
            this.txtGioBD.Name = "txtGioBD";
            this.txtGioBD.Size = new System.Drawing.Size(121, 26);
            this.txtGioBD.TabIndex = 13;
            // 
            // cbMaCa
            // 
            this.cbMaCa.FormattingEnabled = true;
            this.cbMaCa.Items.AddRange(new object[] {
            "Ca1",
            "Ca2",
            "Ca3",
            "Ca4"});
            this.cbMaCa.Location = new System.Drawing.Point(145, 161);
            this.cbMaCa.Name = "cbMaCa";
            this.cbMaCa.Size = new System.Drawing.Size(121, 27);
            this.cbMaCa.TabIndex = 12;
            // 
            // txtGioKT
            // 
            this.txtGioKT.Location = new System.Drawing.Point(145, 300);
            this.txtGioKT.Name = "txtGioKT";
            this.txtGioKT.Size = new System.Drawing.Size(121, 26);
            this.txtGioKT.TabIndex = 15;
            // 
            // frmDanhSachCaAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 450);
            this.Controls.Add(this.txtGioKT);
            this.Controls.Add(this.dttNgayLam);
            this.Controls.Add(this.txtGioBD);
            this.Controls.Add(this.cbMaCa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmDanhSachCaAdd";
            this.Text = "frmDanhSachCaAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker dttNgayLam;
        public System.Windows.Forms.TextBox txtGioBD;
        public System.Windows.Forms.ComboBox cbMaCa;
        public System.Windows.Forms.TextBox txtGioKT;
    }
}