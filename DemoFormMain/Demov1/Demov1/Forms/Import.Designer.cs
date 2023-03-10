
namespace Demov1.Forms
{
    partial class Import
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDSNCC = new System.Windows.Forms.Label();
            this.lblDSLoaiSP = new System.Windows.Forms.Label();
            this.labelNhaphang = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDanhSachNhaCungCap = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDanhSachLoaiSanPhamNhaCungCap = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuiMua = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNhaCungCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachLoaiSanPhamNhaCungCap)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.70534F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.29466F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1384, 543);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelNhaphang, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.54456F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.45544F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1378, 100);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 688F));
            this.tableLayoutPanel5.Controls.Add(this.lblDSNCC, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblDSLoaiSP, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1372, 49);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // lblDSNCC
            // 
            this.lblDSNCC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDSNCC.AutoSize = true;
            this.lblDSNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSNCC.Location = new System.Drawing.Point(231, 12);
            this.lblDSNCC.Name = "lblDSNCC";
            this.lblDSNCC.Size = new System.Drawing.Size(221, 24);
            this.lblDSNCC.TabIndex = 1;
            this.lblDSNCC.Text = "Danh sách nhà cung cấp";
            // 
            // lblDSLoaiSP
            // 
            this.lblDSLoaiSP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDSLoaiSP.AutoSize = true;
            this.lblDSLoaiSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSLoaiSP.Location = new System.Drawing.Point(917, 12);
            this.lblDSLoaiSP.Name = "lblDSLoaiSP";
            this.lblDSLoaiSP.Size = new System.Drawing.Size(222, 24);
            this.lblDSLoaiSP.TabIndex = 1;
            this.lblDSLoaiSP.Text = "Danh sách loại sản phẩm";
            // 
            // labelNhaphang
            // 
            this.labelNhaphang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNhaphang.AutoSize = true;
            this.labelNhaphang.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNhaphang.Location = new System.Drawing.Point(637, 10);
            this.labelNhaphang.Name = "labelNhaphang";
            this.labelNhaphang.Size = new System.Drawing.Size(104, 24);
            this.labelNhaphang.TabIndex = 1;
            this.labelNhaphang.Text = "Nhập hàng";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dgvDanhSachNhaCungCap, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvDanhSachLoaiSanPhamNhaCungCap, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 109);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.24078F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.75921F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1378, 431);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dgvDanhSachNhaCungCap
            // 
            this.dgvDanhSachNhaCungCap.AllowUserToAddRows = false;
            this.dgvDanhSachNhaCungCap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachNhaCungCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachNhaCungCap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvDanhSachNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSachNhaCungCap.Location = new System.Drawing.Point(3, 3);
            this.dgvDanhSachNhaCungCap.Name = "dgvDanhSachNhaCungCap";
            this.dgvDanhSachNhaCungCap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachNhaCungCap.Size = new System.Drawing.Size(683, 365);
            this.dgvDanhSachNhaCungCap.TabIndex = 0;
            this.dgvDanhSachNhaCungCap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachNhaCungCap_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaNCC";
            this.Column1.HeaderText = "Mã NCC";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenNCC";
            this.Column2.HeaderText = "TenNCC";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SDT";
            this.Column3.HeaderText = "SDT";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DiaChi";
            this.Column4.HeaderText = "DiaChi";
            this.Column4.Name = "Column4";
            // 
            // dgvDanhSachLoaiSanPhamNhaCungCap
            // 
            this.dgvDanhSachLoaiSanPhamNhaCungCap.AllowUserToAddRows = false;
            this.dgvDanhSachLoaiSanPhamNhaCungCap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachLoaiSanPhamNhaCungCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachLoaiSanPhamNhaCungCap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6});
            this.dgvDanhSachLoaiSanPhamNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSachLoaiSanPhamNhaCungCap.Location = new System.Drawing.Point(692, 3);
            this.dgvDanhSachLoaiSanPhamNhaCungCap.Name = "dgvDanhSachLoaiSanPhamNhaCungCap";
            this.dgvDanhSachLoaiSanPhamNhaCungCap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachLoaiSanPhamNhaCungCap.Size = new System.Drawing.Size(683, 365);
            this.dgvDanhSachLoaiSanPhamNhaCungCap.TabIndex = 0;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "MaLoai";
            this.Column5.HeaderText = "Mã loại";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "TenLoai";
            this.Column6.HeaderText = "Tên Loại";
            this.Column6.Name = "Column6";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.93485F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.06515F));
            this.tableLayoutPanel3.Controls.Add(this.btnGuiMua, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(692, 374);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(307, 51);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnGuiMua
            // 
            this.btnGuiMua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuiMua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiMua.Location = new System.Drawing.Point(35, 3);
            this.btnGuiMua.Name = "btnGuiMua";
            this.btnGuiMua.Size = new System.Drawing.Size(113, 45);
            this.btnGuiMua.TabIndex = 0;
            this.btnGuiMua.Text = "Gửi yêu cầu";
            this.btnGuiMua.UseVisualStyleBackColor = true;
            this.btnGuiMua.Click += new System.EventHandler(this.btnGuiMua_Click);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 543);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Import";
            this.Text = "Nhập hàng";
            this.Load += new System.EventHandler(this.Import_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNhaCungCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachLoaiSanPhamNhaCungCap)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvDanhSachNhaCungCap;
        private System.Windows.Forms.DataGridView dgvDanhSachLoaiSanPhamNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnGuiMua;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblDSNCC;
        private System.Windows.Forms.Label lblDSLoaiSP;
        private System.Windows.Forms.Label labelNhaphang;
    }
}