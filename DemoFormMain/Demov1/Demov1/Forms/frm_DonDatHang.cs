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
    
    public partial class frm_DonDatHang : Form
    {
        public TaiKhoan taiKhoan;
        public NhanVien nhanVien;
         DBQuanLyCuaHang dbcontext ;
        List<ChiTietLapDonHang> shoppingCart;
       

        ChiTietLapDonHang selectedItem;
        public frm_DonDatHang(NhanVien nv, DBQuanLyCuaHang db)
        {
            InitializeComponent();
            this.nhanVien = nv;
            this.dbcontext = db;
            shoppingCart = new List<ChiTietLapDonHang>();
            ResetShoppingCart();
            Loaddatagv();
        }

        // load data dgv san pham
        private void Loaddatagv()
        {
            dbcontext = new DBQuanLyCuaHang();
            taiKhoan = new TaiKhoan();
            List<SanPham> listSanPham = dbcontext.SanPham.ToList();

            FillDataSanPham(listSanPham);
        }
        //đua dữ liệu vào dgvDSSP
        private void FillDataSanPham(List<SanPham> listSanPham)
        {
            //lọc dữ liệu
            var result = from s in listSanPham
                         select new { MaSP = s.MaSP, TenSP = s.TenSP, GiaNhap = s.GiaNhap.ToString("#,###,###"), GiaBan = s.GiaBan.ToString("#,###,###"), SoLuong = s.SoLuong, TenLoai = s.LoaiSanPham.TenLoai };

            dgvDanhSachSanPham.DataSource = result.ToList();
        }


        private void ResetShoppingCart()
        {
            shoppingCart.RemoveAll(s => true);
            selectedItem = new ChiTietLapDonHang()
            {
                SanPham = new SanPham()
                {
                    MaSP = 0,
                    LoaiSanPham = new LoaiSanPham()
                    {
                        TenLoai = ""
                    },
                    SoLuong = 0
                },
                SoLuong = 1
            };

            //FillSelectedItemDataToTextBox();
            LoadDataDGVCart(shoppingCart);
        }

        private void LoadDataDGVCart(List<ChiTietLapDonHang> listChiTietLapDonHang)
        {
            var result = from s in listChiTietLapDonHang
                         select new {  MaSP = s.MaSP, TenSP = s.SanPham.TenSP, TenLoai = s.SanPham.LoaiSanPham.TenLoai, Gia = s.DonGia, SoLuong = s.SoLuong, TongTien = (s.DonGia * s.SoLuong).ToString("#,###,###") };

            dgvDanhSachDonHang.DataSource = result.ToList();
            txtTong.Text = result.Sum(s => s.Gia * s.SoLuong).ToString("#,###,###");
        }


        private void dgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSachSanPham.Rows[e.RowIndex].Cells[0].Value != null)//kiểm tra data có tồn tại chưa 
                {
                    
                    var id = dgvDanhSachSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();

                    SetTempOrderDetail(int.Parse(id));
                    FillSelectedItemDataToTextBox();
                }
            }
            catch
            {
                return;
            }
        }
        private void FillSelectedItemDataToTextBox() // 
        {
            txtMaSp.Text = selectedItem.SanPham.MaSP.ToString();
            txtTenSp.Text = selectedItem.SanPham.TenSP.ToString();
            txtGiaNhap.Text = selectedItem.SanPham.GiaNhap.ToString("#,###,###");
            txtGiaBan.Text = selectedItem.SanPham.GiaBan.ToString("#,###,###");
            txtSoluong.Text = selectedItem.SanPham.SoLuong.ToString();
            txtTenLoai.Text = selectedItem.SanPham.LoaiSanPham.TenLoai.ToString();
            nupSoLuongDat.Value = selectedItem.SoLuong;
        }

        private void LoadTheme()
        {
            btnTim.BackColor = ThemeColor.PrimaryColor;
            btnTim.ForeColor = Color.White;
            btnTim.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnXoa.BackColor = ThemeColor.PrimaryColor;
            btnXoa.ForeColor = Color.White;
            btnXoa.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnXoaKhoiGio.BackColor = ThemeColor.PrimaryColor;
            btnXoaKhoiGio.ForeColor = Color.White;
            btnXoaKhoiGio.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnDatHang.BackColor = ThemeColor.PrimaryColor;
            btnDatHang.ForeColor = Color.White;
            btnDatHang.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnHienThi.BackColor = ThemeColor.PrimaryColor;
            btnHienThi.ForeColor = Color.White;
            btnHienThi.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            lblDSCX.ForeColor = ThemeColor.SecondaryColor;
            
        }


      

        private void frm_DonDatHang_Load(object sender, EventArgs e)
        {
            LoadTheme();
           
            
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            if (shoppingCart.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào giỏ hàng!");
                return;
            }
            frm_Quanlykhachhang formCustomer = new frm_Quanlykhachhang(nhanVien,dbcontext, "Vui lòng chọn khách hàng muốn đặt!");
            formCustomer.selectedCustomer += SelectedCustomer;
            formCustomer.ShowDialog();
        }

        void SelectedCustomer(KhachHang khachHang, NhanVien nhanVien)
        {
           
            try
            {

                LapDonHang order = new LapDonHang()
                {

                    MaKH = khachHang.MaKH,
                    MaNV = nhanVien.MaNV,
                    NgayLap = DateTime.Now
                };

                var result = dbcontext.LapDonHang.Add(order);

                shoppingCart.ForEach(s => {
                    s.MaLDH = result.MaLDH;
                    SanPham sanPham = dbcontext.SanPham.Where(a => a.MaSP == s.MaSP).FirstOrDefault();
                    sanPham.SoLuong -= s.SoLuong;
                    dbcontext.ChiTietLapDonHang.Add(s);
                });


                double total = shoppingCart.Sum(s => s.SoLuong * s.SanPham.GiaBan);
              
                dbcontext.SaveChanges();
                Loaddatagv();
                ResetShoppingCart();

                MessageBox.Show("Thêm Order cho khách hàng " + khachHang.TenKH + " thành công\n Tổng thiệt hại là :" + total);

                if (MessageBox.Show("Bạn có muốn in hoá đơn?", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                LapDonHang lapDonHang = dbcontext.LapDonHang.Where(s => s.MaLDH == result.MaLDH).FirstOrDefault();
                OrderReport report = new OrderReport(lapDonHang);
                report.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi hệ thống " + e.Message);
                
            }
        }

       


        private void SetTempOrderDetail(int id)
        {
            selectedItem = TimTrongGioHangTheomaSanPham(id);
            if (selectedItem != null) // có sản phẩm trong giỏ hàng
            {
                this.selectedItem.SoLuong = selectedItem.SoLuong;
            }
            else // không có sp trong giỏ
            {
                this.selectedItem = new ChiTietLapDonHang();
                this.selectedItem.SanPham = TimSanPhamTheoMa(id);
                this.selectedItem.SoLuong = 1;
            }
        }

        private ChiTietLapDonHang TimTrongGioHangTheomaSanPham(int maSanPham)
        {
            return shoppingCart.Where(s => s.MaSP == maSanPham).FirstOrDefault();
        }

        private SanPham TimSanPhamTheoMa(int id)
        {
            try
            {
                SanPham sanPham = dbcontext.SanPham.Find(id);
                return sanPham;
            }
            catch
            {
                MessageBox.Show("Không tìm thấy sản phẩm có id " + id);
                throw new Exception();
            }
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            int soLuongDat = Convert.ToInt32(nupSoLuongDat.Value);

            if (!TempOrderIsSelected())
            {
                return;
            }

            if (IsAvalableItemAddToShoppingCart(selectedItem.SanPham.MaSP, soLuongDat))
            {
                DeleteOrderDetailInCartByFlowerId(selectedItem.MaSP);

                // set data cho order detail rồi add vào giỏ hàng
                selectedItem.MaSP = selectedItem.SanPham.MaSP;
                selectedItem.DonGia = selectedItem.SanPham.GiaBan;
                selectedItem.SoLuong = soLuongDat;

                TimTrongGioHangTheomaSanPham(selectedItem.MaSP);

                shoppingCart.Add(selectedItem);

                LoadDataDGVCart(shoppingCart);
            }
            else
            {
                MessageBox.Show("Số lượng hàng tồn kho không đủ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private int DeleteOrderDetailInCartByFlowerId(int maSanPham)
        {
            return shoppingCart.RemoveAll(s => s.MaSP == maSanPham);
        }

        private bool IsAvalableItemAddToShoppingCart(int maSanPham, int soLuongDat)
        {
            SanPham sanPham = dbcontext.SanPham.Find(maSanPham);
            if (sanPham.SoLuong >= soLuongDat)
            {
                return true;
            }
            return false;
        }

        private bool TempOrderIsSelected()
        {
            if (selectedItem.SanPham.MaSP == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return false;
            }
            return true;
        }

      

       

        private void btnTim_Click(object sender, EventArgs e)
        {
            // giúp một đối tượng có thể thực hiện duyệt các phần tử
            IEnumerable<SanPham> found = dbcontext.SanPham;
            //contains giúp kiểm tra sự tồn tại của chuỗi txb trong chuỗi của đối tượng 
            var result = found.Where(x => x.MaSP.ToString().Contains(txtTimKiem.Text) || x.TenSP.Contains(txtTimKiem.Text) || x.LoaiSanPham.TenLoai.ToString().Contains(txtTimKiem.Text)).ToList();

            this.FillDataSanPham(result);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            Loaddatagv();
        }

        private void dgvDanhSachSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoaKhoiGio_Click(object sender, EventArgs e)
        {
            ResetShoppingCart();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (TimTrongGioHangTheomaSanPham(selectedItem.MaSP) == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm trong giỏ hàng!");
                return;
            }
            shoppingCart.RemoveAll(s => s.MaSP == selectedItem.MaSP);

            LoadDataDGVCart(shoppingCart);
        }
    }
}
