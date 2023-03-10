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
using Demov1.Reports;

namespace Demov1.Forms

{
    public partial class QLDonDatHang : Form
    {
        DBQuanLyCuaHang db;
        NhanVien nhanVien;
        LapDonHang lapDonHang;
        KhachHang khachHang;


        private void LoadTheme()
        {
            btnInHD.BackColor = ThemeColor.PrimaryColor;
            btnInHD.ForeColor = Color.White;
            btnInHD.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnInXem.BackColor = ThemeColor.PrimaryColor;
            btnInXem.ForeColor = Color.White;
            btnInXem.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
        }

        //form load
        private void QLDonDatHang_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        public QLDonDatHang()
        {
            InitializeComponent();
        }

        public QLDonDatHang( DBQuanLyCuaHang db, KhachHang khachHang)
        {
            InitializeComponent();
            this.khachHang = khachHang;
            this.db = db;
            lapDonHang = new LapDonHang();
            rdoViewAll.Checked = true;
            CheckEnableDTP();
            TaiDanhSachDonDatHang();

            ResetTempOrder();
        }

        public QLDonDatHang(NhanVien nhanVien, DBQuanLyCuaHang db)
        {
            InitializeComponent();
            this.nhanVien = nhanVien;
            this.db = db;
           
            rdoViewAll.Checked = true;
            CheckEnableDTP();
            TaiDanhSachDonDatHang();

            ResetTempOrder();
        }

        private void TaiDanhSachDonDatHang()
        {
            ICollection<LapDonHang> ls;


            if (khachHang != null)
            {
                ls = khachHang.LapDonHang.ToList();
            }
            else
            {
                ls = db.LapDonHang.ToList();
            }

            var result = from s in ls
                         where CheckCreatedDate(s.NgayLap)
                         select new { MaLDH = s.MaLDH, NgayLap = s.NgayLap, MaKH = s.MaKH, TenKH = s.KhachHang.TenKH, TenNV = s.NhanVien.TenNV, NgayTao = s.NgayLap };

            dgvDSDH.DataSource = result.ToList();
            txtTongDonHang.Text = result.Count().ToString();
        }

        private bool CheckCreatedDate(DateTime createdDate)
        {
            if (rdoTheoNgay.Checked)
            {
                DateTime date = dtpXemTheoNgay.Value;

                return createdDate.Date == date.Date;
            }
            else if (rdoTheoThang.Checked)
            {
                DateTime date = dtpXemTheoThang.Value;

                return createdDate.Month == date.Month && createdDate.Year == date.Year;
            }
            else if (rdoViewTuNgay.Checked)
            {
                DateTime minDate = dtpMin.Value;
                DateTime maxDate = dtpMax.Value;

                return createdDate.Date >= minDate.Date && createdDate.Date <= maxDate.Date;
            }

            return true;
        }

        private void CheckEnableDTP()
        {
            dtpXemTheoNgay.Enabled = rdoTheoNgay.Checked;
            dtpXemTheoThang.Enabled = rdoTheoThang.Checked;
            dtpMin.Enabled = dtpMax.Enabled = rdoViewTuNgay.Checked;
        }

        private void dgvDSDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDSDH.Rows[e.RowIndex].Cells[0].Value != null)//kiểm tra data có tồn tại chưa nhá
                {
                    var id = dgvDSDH.Rows[e.RowIndex].Cells[0].Value.ToString();

                    lapDonHang = FindOrderById(int.Parse(id));
                    FillSelectedItemDataToTextBox();
                    TaiDanhSachChiTietHoaDon(lapDonHang.ChiTietLapDonHang.ToList());
                }
            }
            catch
            {
                return;
            }
        }

        private void TaiDanhSachChiTietHoaDon(List<ChiTietLapDonHang> chiTietLapDonHangs)
        {
            var result = from s in chiTietLapDonHangs
                         select new { MaSP = s.MaSP, TenSP = s.SanPham.TenSP, LoaiSP = s.SanPham.LoaiSanPham.TenLoai, Giaban = s.DonGia.ToString("#,###,###"), SoLuong = s.SoLuong, TongCong = (s.DonGia * s.SoLuong).ToString("#,###,###") };

            dgvChiTietDonDathang.DataSource = result.ToList();
            txtTongSanPham.Text = result.Count().ToString("#,###,###");
            txtTongTien.Text = chiTietLapDonHangs.Sum(s => s.DonGia * s.SoLuong).ToString("#,###,###");
        }

        private void FillSelectedItemDataToTextBox()
        {
            txtMaKH.Text = lapDonHang.MaKH.ToString();
            txtTenKh.Text = lapDonHang.KhachHang.TenKH;
            txtSDT.Text = lapDonHang.KhachHang.SDT;
            txtDiaChi.Text = lapDonHang.KhachHang.DiaChi;
            txtMaDonHang.Text = lapDonHang.MaLDH.ToString();
           
        }

        private LapDonHang FindOrderById(int iD)
        {
            return db.LapDonHang.Where(s => s.MaLDH == iD).FirstOrDefault();
        }

       

        private void dtpMax_ValueChanged(object sender, EventArgs e)
        {
            DateTime minDate = dtpMin.Value;
            DateTime maxDate = dtpMax.Value;
            DateTime day = dtpXemTheoNgay.Value;
            DateTime month = dtpXemTheoNgay.Value;

            if (day.Date > DateTime.Now.Date)
            {
                dtpXemTheoNgay.Value = DateTime.Now.Date;
            }

            if (month.Date > DateTime.Now.Date)
            {
                dtpXemTheoThang.Value = DateTime.Now.Date;
            }

            if (maxDate.Date > DateTime.Now.Date)
            {
                dtpMax.Value = DateTime.Now.Date;
            }
            if (minDate.Date > maxDate.Date)
            {
                dtpMin.Value = dtpMax.Value;
            }
        }

        private void btnInXem_Click(object sender, EventArgs e)
        {
            TaiDanhSachDonDatHang();
        }

       

        private void rdoTheoNgay_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckEnableDTP();
        }

        void ResetTempOrder()
        {
            lapDonHang = new LapDonHang()
            {
                KhachHang = new KhachHang()
                {
                    MaKH = 0,
                    TenKH = "",
                    SDT = "",
                    DiaChi = "",
                    
                },
                ChiTietLapDonHang = new List<ChiTietLapDonHang>()
            };
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if (lapDonHang.ChiTietLapDonHang.Count == 0)
            {
                MessageBox.Show("Hãy chọn hoá đơn cần in");
                return;
            }

            // in đơn hàng;

            OrderReport f = new OrderReport(lapDonHang);
            f.ShowDialog();
        }
    }
}
