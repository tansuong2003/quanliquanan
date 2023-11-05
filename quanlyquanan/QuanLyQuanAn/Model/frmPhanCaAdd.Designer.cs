namespace QuanLyQuanAn.Model
{
    partial class frmPhanCaAdd
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
            this.label6 = new System.Windows.Forms.Label();
            this.cbMaCa = new System.Windows.Forms.ComboBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.dttNgayLam = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.Text = "Phân Ca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "MaCa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "MaNV";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "NgayLam";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // cbMaCa
            // 
            this.cbMaCa.FormattingEnabled = true;
            this.cbMaCa.Items.AddRange(new object[] {
            "Ca1",
            "Ca2",
            "Ca3",
            "Ca4"});
            this.cbMaCa.Location = new System.Drawing.Point(101, 145);
            this.cbMaCa.Name = "cbMaCa";
            this.cbMaCa.Size = new System.Drawing.Size(121, 27);
            this.cbMaCa.TabIndex = 7;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(101, 182);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(121, 26);
            this.txtMaNV.TabIndex = 8;
            // 
            // dttNgayLam
            // 
            this.dttNgayLam.CustomFormat = "yyyy/MM/dd";
            this.dttNgayLam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttNgayLam.Location = new System.Drawing.Point(101, 228);
            this.dttNgayLam.Name = "dttNgayLam";
            this.dttNgayLam.Size = new System.Drawing.Size(121, 26);
            this.dttNgayLam.TabIndex = 11;
            this.dttNgayLam.Value = new System.DateTime(2023, 11, 2, 0, 0, 0, 0);
            // 
            // frmPhanCaAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 374);
            this.Controls.Add(this.dttNgayLam);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.cbMaCa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmPhanCaAdd";
            this.Text = "frmPhanCaAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbMaCa;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.DateTimePicker dttNgayLam;
    }
}