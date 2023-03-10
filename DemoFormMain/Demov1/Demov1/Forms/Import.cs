using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demov1.Model;

namespace Demov1.Forms
{
    public partial class Import : Form
    {

        NhanVien nhanVien;
        DBQuanLyCuaHang dbcontext;
        NhaCungCap nhaCungCap;
       

        public Import(NhanVien nv, DBQuanLyCuaHang db)
        {
            InitializeComponent();
            this.nhanVien = nv;
            this.dbcontext = db;
            LoadDgv();
            LoadTheme();
        }

        public Import()
        {
            InitializeComponent();
            nhaCungCap = new NhaCungCap();
           
            LoadDgv();
            LoadTheme();
        }

        private void LoadTheme()
        {
            btnGuiMua.BackColor = ThemeColor.PrimaryColor;
            btnGuiMua.ForeColor = Color.White;
            btnGuiMua.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
           
            labelNhaphang.ForeColor = ThemeColor.SecondaryColor;
            lblDSLoaiSP.ForeColor = ThemeColor.SecondaryColor;
            lblDSNCC.ForeColor = ThemeColor.SecondaryColor;




        }

        //load dgv danh sach nha cung cap
        private void LoadDgv()
        {
            dbcontext = new DBQuanLyCuaHang();
            
            List<NhaCungCap> listSNhaCungCap = dbcontext.NhaCungCap.ToList();

            FillDataSanPham(listSNhaCungCap);
        }

        //dua du lieu vao dtagridview
        private void FillDataSanPham(List<NhaCungCap> listSNhaCungCap)
        {
            //lọc dữ liệu
            var result = from s in listSNhaCungCap
                         select new { MaNCC = s.MaNCC, TenNCC = s.TenNCC, SDT = s.SDT, DiaChi = s.DiaChi };

            dgvDanhSachNhaCungCap.DataSource = result.ToList();
        }

        private void dgvDanhSachNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSachNhaCungCap.Rows[e.RowIndex].Cells[0].Value != null)//kiểm tra data có tồn tại chưa 
                {
                    var id = dgvDanhSachNhaCungCap.Rows[e.RowIndex].Cells[0].Value.ToString();
                    

                    nhaCungCap = TimDanhSachCungCapTheoId(int.Parse(id));

                    TaiDanhSachChiTietCungCap(nhaCungCap.LoaiSanPham.ToList());
                }
            }
            catch
            {
                return;
            }
        }

        private NhaCungCap TimDanhSachCungCapTheoId(int iD)
        {
            return dbcontext.NhaCungCap.Where(s => s.MaNCC == iD).FirstOrDefault();
        }

        private void TaiDanhSachChiTietCungCap(List<LoaiSanPham> loaiSanPhams)
        {
            var result = from s in loaiSanPhams
                         select new { MaLoai  = s.MaLoai, TenLoai = s.TenLoai };

            dgvDanhSachLoaiSanPhamNhaCungCap.DataSource = result.ToList();
        }

       

        private void btnGuiMua_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Bạn muốn gửi yêu cầu đến nhà cung cấp ", "Thông Báo", MessageBoxButtons.OKCancel);
            if(dr == DialogResult.OK)
            {
                MessageBox.Show("Gửi yêu cầu thành công");
            }
        }

        private void Import_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
