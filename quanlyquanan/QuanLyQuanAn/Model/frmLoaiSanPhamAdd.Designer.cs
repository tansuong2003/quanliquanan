namespace QuanLyQuanAn.Model
{
    partial class frmLoaiSanPhamAdd
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenLoaiSP = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaLoaiSP = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(215, 38);
            this.label1.Text = "Thêm sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên loại sản phẩm";
            // 
            // txtTenLoaiSP
            // 
            this.txtTenLoaiSP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenLoaiSP.DefaultText = "";
            this.txtTenLoaiSP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenLoaiSP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenLoaiSP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenLoaiSP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenLoaiSP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenLoaiSP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenLoaiSP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenLoaiSP.Location = new System.Drawing.Point(69, 307);
            this.txtTenLoaiSP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenLoaiSP.Modified = true;
            this.txtTenLoaiSP.Name = "txtTenLoaiSP";
            this.txtTenLoaiSP.PasswordChar = '\0';
            this.txtTenLoaiSP.PlaceholderText = "";
            this.txtTenLoaiSP.SelectedText = "";
            this.txtTenLoaiSP.Size = new System.Drawing.Size(312, 60);
            this.txtTenLoaiSP.TabIndex = 4;
            // 
            // txtMaLoaiSP
            // 
            this.txtMaLoaiSP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaLoaiSP.DefaultText = "";
            this.txtMaLoaiSP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaLoaiSP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaLoaiSP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaLoaiSP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaLoaiSP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaLoaiSP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaLoaiSP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaLoaiSP.Location = new System.Drawing.Point(69, 192);
            this.txtMaLoaiSP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaLoaiSP.Modified = true;
            this.txtMaLoaiSP.Name = "txtMaLoaiSP";
            this.txtMaLoaiSP.PasswordChar = '\0';
            this.txtMaLoaiSP.PlaceholderText = "";
            this.txtMaLoaiSP.SelectedText = "";
            this.txtMaLoaiSP.Size = new System.Drawing.Size(312, 60);
            this.txtMaLoaiSP.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mã loại sản phẩm";
            // 
            // frmLoaiSanPhamAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 469);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaLoaiSP);
            this.Controls.Add(this.txtTenLoaiSP);
            this.Controls.Add(this.label3);
            this.Name = "frmLoaiSanPhamAdd";
            this.Load += new System.EventHandler(this.frmSanPhamAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2TextBox txtTenLoaiSP;
        public Guna.UI2.WinForms.Guna2TextBox txtMaLoaiSP;
    }
}
