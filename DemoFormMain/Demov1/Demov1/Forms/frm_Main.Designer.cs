
namespace Demov1
{
    partial class frm_Main
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
            this.components = new System.ComponentModel.Container();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblClock = new System.Windows.Forms.Label();
            this.btnQuanLyDonDatHang = new System.Windows.Forms.Button();
            this.btnQlNCC = new System.Windows.Forms.Button();
            this.btnQlNhanvien = new System.Windows.Forms.Button();
            this.btnQLKhachhang = new System.Windows.Forms.Button();
            this.btnDonDatHang = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.btnCloseForms = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlTitleBar.SuspendLayout();
            this.pnlChildForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnLogOut);
            this.panelMenu.Controls.Add(this.btnImport);
            this.panelMenu.Controls.Add(this.lblClock);
            this.panelMenu.Controls.Add(this.btnQuanLyDonDatHang);
            this.panelMenu.Controls.Add(this.btnQlNCC);
            this.panelMenu.Controls.Add(this.btnQlNhanvien);
            this.panelMenu.Controls.Add(this.btnQLKhachhang);
            this.panelMenu.Controls.Add(this.btnDonDatHang);
            this.panelMenu.Controls.Add(this.btnProducts);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 586);
            this.panelMenu.TabIndex = 0;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLogOut.Image = global::Demov1.Properties.Resources.Log_Out_16x161;
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogOut.Location = new System.Drawing.Point(0, 430);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLogOut.Size = new System.Drawing.Size(220, 50);
            this.btnLogOut.TabIndex = 8;
            this.btnLogOut.Text = "LogOut";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnImport.Image = global::Demov1.Properties.Resources.New_16x16;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.Location = new System.Drawing.Point(0, 380);
            this.btnImport.Name = "btnImport";
            this.btnImport.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnImport.Size = new System.Drawing.Size(220, 50);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lblClock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblClock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblClock.Location = new System.Drawing.Point(0, 553);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(47, 33);
            this.lblClock.TabIndex = 0;
            this.lblClock.Text = "00";
            // 
            // btnQuanLyDonDatHang
            // 
            this.btnQuanLyDonDatHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyDonDatHang.FlatAppearance.BorderSize = 0;
            this.btnQuanLyDonDatHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyDonDatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyDonDatHang.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQuanLyDonDatHang.Image = global::Demov1.Properties.Resources.folder_invoices_512;
            this.btnQuanLyDonDatHang.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuanLyDonDatHang.Location = new System.Drawing.Point(0, 330);
            this.btnQuanLyDonDatHang.Name = "btnQuanLyDonDatHang";
            this.btnQuanLyDonDatHang.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnQuanLyDonDatHang.Size = new System.Drawing.Size(220, 50);
            this.btnQuanLyDonDatHang.TabIndex = 6;
            this.btnQuanLyDonDatHang.Text = "Order Management ";
            this.btnQuanLyDonDatHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyDonDatHang.UseVisualStyleBackColor = true;
            this.btnQuanLyDonDatHang.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnQlNCC
            // 
            this.btnQlNCC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQlNCC.FlatAppearance.BorderSize = 0;
            this.btnQlNCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQlNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlNCC.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQlNCC.Image = global::Demov1.Properties.Resources.Industry_mail_Icon_16;
            this.btnQlNCC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQlNCC.Location = new System.Drawing.Point(0, 280);
            this.btnQlNCC.Name = "btnQlNCC";
            this.btnQlNCC.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnQlNCC.Size = new System.Drawing.Size(220, 50);
            this.btnQlNCC.TabIndex = 5;
            this.btnQlNCC.Text = "Suppliers";
            this.btnQlNCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQlNCC.UseVisualStyleBackColor = true;
            this.btnQlNCC.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnQlNhanvien
            // 
            this.btnQlNhanvien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQlNhanvien.FlatAppearance.BorderSize = 0;
            this.btnQlNhanvien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQlNhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlNhanvien.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQlNhanvien.Image = global::Demov1.Properties.Resources.users1;
            this.btnQlNhanvien.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQlNhanvien.Location = new System.Drawing.Point(0, 230);
            this.btnQlNhanvien.Name = "btnQlNhanvien";
            this.btnQlNhanvien.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnQlNhanvien.Size = new System.Drawing.Size(220, 50);
            this.btnQlNhanvien.TabIndex = 4;
            this.btnQlNhanvien.Text = "Employees";
            this.btnQlNhanvien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQlNhanvien.UseVisualStyleBackColor = true;
            this.btnQlNhanvien.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnQLKhachhang
            // 
            this.btnQLKhachhang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLKhachhang.FlatAppearance.BorderSize = 0;
            this.btnQLKhachhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLKhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLKhachhang.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQLKhachhang.Image = global::Demov1.Properties.Resources.folder_customer_512;
            this.btnQLKhachhang.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQLKhachhang.Location = new System.Drawing.Point(0, 180);
            this.btnQLKhachhang.Name = "btnQLKhachhang";
            this.btnQLKhachhang.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnQLKhachhang.Size = new System.Drawing.Size(220, 50);
            this.btnQLKhachhang.TabIndex = 3;
            this.btnQLKhachhang.Text = "Customers";
            this.btnQLKhachhang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLKhachhang.UseVisualStyleBackColor = true;
            this.btnQLKhachhang.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDonDatHang
            // 
            this.btnDonDatHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDonDatHang.FlatAppearance.BorderSize = 0;
            this.btnDonDatHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonDatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonDatHang.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDonDatHang.Image = global::Demov1.Properties.Resources.copy;
            this.btnDonDatHang.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDonDatHang.Location = new System.Drawing.Point(0, 130);
            this.btnDonDatHang.Name = "btnDonDatHang";
            this.btnDonDatHang.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDonDatHang.Size = new System.Drawing.Size(220, 50);
            this.btnDonDatHang.TabIndex = 2;
            this.btnDonDatHang.Text = "Orders";
            this.btnDonDatHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonDatHang.UseVisualStyleBackColor = true;
            this.btnDonDatHang.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProducts.Image = global::Demov1.Properties.Resources.cart;
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProducts.Location = new System.Drawing.Point(0, 80);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnProducts.Size = new System.Drawing.Size(220, 50);
            this.btnProducts.TabIndex = 1;
            this.btnProducts.Text = "Products";
            this.btnProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 80);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Demov1.Properties.Resources.KH_NG_L_M_M__V_N_C___N_free_file;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.pnlTitleBar.Controls.Add(this.btnCloseForms);
            this.pnlTitleBar.Controls.Add(this.lblTitle);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(220, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(1063, 80);
            this.pnlTitleBar.TabIndex = 1;
            // 
            // btnCloseForms
            // 
            this.btnCloseForms.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCloseForms.FlatAppearance.BorderSize = 0;
            this.btnCloseForms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForms.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForms.Image = global::Demov1.Properties.Resources.back;
            this.btnCloseForms.Location = new System.Drawing.Point(988, 0);
            this.btnCloseForms.Name = "btnCloseForms";
            this.btnCloseForms.Size = new System.Drawing.Size(75, 80);
            this.btnCloseForms.TabIndex = 1;
            this.btnCloseForms.UseVisualStyleBackColor = true;
            this.btnCloseForms.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(497, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(72, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HOME";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlChildForm
            // 
            this.pnlChildForm.BackgroundImage = global::Demov1.Properties.Resources.PNG;
            this.pnlChildForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlChildForm.Controls.Add(this.label1);
            this.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForm.Location = new System.Drawing.Point(220, 80);
            this.pnlChildForm.Name = "pnlChildForm";
            this.pnlChildForm.Size = new System.Drawing.Size(1063, 506);
            this.pnlChildForm.TabIndex = 2;
            this.pnlChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChildForm_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(320, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bao lâu thì bán được 1 tỷ chậu cây ???";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 586);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.pnlTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "frm_Main";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlChildForm.ResumeLayout(false);
            this.pnlChildForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnQuanLyDonDatHang;
        private System.Windows.Forms.Button btnQlNCC;
        private System.Windows.Forms.Button btnQlNhanvien;
        private System.Windows.Forms.Button btnQLKhachhang;
        private System.Windows.Forms.Button btnDonDatHang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlChildForm;
        private System.Windows.Forms.Button btnCloseForms;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnLogOut;
    }
}

