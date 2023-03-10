using Demov1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Demov1.Forms
{
    public partial class frm_SanPham : Form
    {
        public frm_SanPham()
        {
            InitializeComponent();
          
        }

        private void LoadTheme()
        {   
            btnThem.BackColor = ThemeColor.PrimaryColor;
            btnThem.ForeColor = Color.White;
            btnThem.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnXoa.BackColor = ThemeColor.PrimaryColor;
            btnXoa.ForeColor = Color.White;
            btnXoa.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnSua.BackColor = ThemeColor.PrimaryColor;
            btnSua.ForeColor = Color.White;
            btnSua.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnTimKiem.BackColor = ThemeColor.PrimaryColor;
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            /*btnThemAnh.BackColor = ThemeColor.PrimaryColor;
            btnThemAnh.ForeColor = Color.White;
            btnThemAnh.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;*/

            lblTTSP.ForeColor = ThemeColor.SecondaryColor;
            lblDSSP.ForeColor = ThemeColor.PrimaryColor;
        }


        DBQuanLyCuaHang dbcontext = new DBQuanLyCuaHang();
        private void btnThem_Click(object sender, EventArgs e)
        {
           

            if (CheckDataInput())
            {
                if (KiemTraMaSanPham(txtMaSanPham.Text) == -1)//san pham chua ton tai trong ds
                {
                    SanPham sanPham = new SanPham();
                    //gan gia tri tu control vao sinhvien
                    //sanPham.MaSP = Convert.ToInt32(txtMaSanPham.Text);
                    sanPham.TenSP = txtTenSanPham.Text;
                    sanPham.GiaNhap = Convert.ToDouble(txtGiaNhap.Text);
                    sanPham.GiaBan = Convert.ToDouble(txtGiaBan.Text);
                    sanPham.SoLuong = (long)nupSoLuong.Value;
                    sanPham.MaLoai = Convert.ToInt32(cbbTenLoaiSP.SelectedValue.ToString());
                    //truyen du lieu vao db
                    dbcontext.SanPham.AddOrUpdate(sanPham);
                    //luu thay doi
                    dbcontext.SaveChanges();

                    
                    ReLoadDgv();
                    ResetForm();
                    MessageBox.Show($"Thêm sản phẩm có mã { sanPham.MaSP} thành công");
                }
                else
                    MessageBox.Show($"Mã sản phẩm {txtMaSanPham.Text} đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            nupSoLuong.Value = 0;
            cbbTenLoaiSP.SelectedValue = "";
        }

        private void ReLoadDgv()
        {
            List<SanPham> newSanPham = dbcontext.SanPham.ToList();
            FillDataDgv(newSanPham);
        }

        // do data len dgv
        private void FillDataDgv(List<SanPham> dsSanPham)
        {
            dgvDanhSachSanPham.Rows.Clear();//xoa du lieu cu
            foreach (var item in dsSanPham)
            {
                int RowNew = dgvDanhSachSanPham.Rows.Add();//khoi tao dong moi
                dgvDanhSachSanPham.Rows[RowNew].Cells[0].Value = item.MaSP;
                dgvDanhSachSanPham.Rows[RowNew].Cells[1].Value = item.TenSP;
                dgvDanhSachSanPham.Rows[RowNew].Cells[2].Value = item.GiaNhap.ToString("#,###,###");
                dgvDanhSachSanPham.Rows[RowNew].Cells[3].Value = item.GiaBan.ToString("#,###,###");
                dgvDanhSachSanPham.Rows[RowNew].Cells[4].Value = item.SoLuong;
                dgvDanhSachSanPham.Rows[RowNew].Cells[5].Value = item.LoaiSanPham.TenLoai;
            }
        }

        private bool CheckDataInput()
        {
            float gianhap = float.Parse(txtGiaNhap.Text);
            float giaban = float.Parse(txtGiaBan.Text);
            if ( txtTenSanPham.Text == "" || txtGiaNhap.Text == "" || txtGiaBan.Text == ""  )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return false;
            }
            else if ( gianhap > giaban)
            {
                MessageBox.Show("Giá nhập phải nhỏ hơn giá bán", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private int KiemTraMaSanPham(string idStudent)
        {
            int length = dgvDanhSachSanPham.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                if (dgvDanhSachSanPham.Rows[i].Cells[0].Value.ToString() == idStudent)
                    return i; // i da ton tai
            }
            return -1; // -1 chua ton tai
        }

        private void frm_SanPham_Load(object sender, EventArgs e)
        {
            LoadTheme();
            List<SanPham> dsSanPham = dbcontext.SanPham.ToList();
            List<LoaiSanPham> dsLoaiSanPham = dbcontext.LoaiSanPham.ToList();
            //do du lieu vao dgv
            FillDataDgv(dsSanPham);
            FillCbbLoaiSanPham(dsLoaiSanPham);
        }

        private void FillCbbLoaiSanPham(List<LoaiSanPham> dsLoaiSanPham)
        {
            cbbTenLoaiSP.DataSource = dsLoaiSanPham;
            cbbTenLoaiSP.DisplayMember = "TenLoai";
            cbbTenLoaiSP.ValueMember = "MaLoai";
        }

        private void dgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSachSanPham.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvDanhSachSanPham.CurrentCell.Selected = true;
                    // gan du lieu nguoc ve cac control;
                    txtMaSanPham.Text = dgvDanhSachSanPham.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTenSanPham.Text = dgvDanhSachSanPham.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtGiaNhap.Text = dgvDanhSachSanPham.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    txtGiaBan.Text = dgvDanhSachSanPham.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    nupSoLuong.Value = Convert.ToDecimal(dgvDanhSachSanPham.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                    cbbTenLoaiSP.SelectedIndex = cbbTenLoaiSP.FindString(dgvDanhSachSanPham.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Bạn chọn sai, vui lòng chọn lại!", "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã!");
                return;
            }

            int id;

            bool success = int.TryParse(txtMaSanPham.Text, out id);

            if (!success)
            {
                MessageBox.Show("Mã không đúng định dạng!");
                return;
            }

            if (MessageBox.Show("Bạn thật sự muốn xoá?", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            if (!dbcontext.SanPham.ToList().Any(s => s.MaSP == id))
            {
                MessageBox.Show("Không tìm thấy sản phẩm!");
                return;
            }

            if (dbcontext.ChiTietLapDonHang.ToList().Any(s => s.MaSP == id))
            {
                MessageBox.Show("Sản phẩm này đã được mua, không thể xoá!");
                return;
            }


            SanPham sanPham = dbcontext.SanPham.FirstOrDefault(p => p.MaSP == id);
            dbcontext.SanPham.Remove(sanPham);
            dbcontext.SaveChanges();


            ReLoadDgv();
            MessageBox.Show("Xoá sản phẩm thành công!");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int masp = int.Parse((txtMaSanPham.Text));
            //FirtOrDefault lấy phần tử đầu tiên thỏa điều kiện
            SanPham sanPham = dbcontext.SanPham.FirstOrDefault(p => p.MaSP == masp);
            //Kiểm tra đối tượng 
            if (sanPham != null)
            {
                //gắn lại các đối tượng thay đổi
                sanPham.TenSP = txtTenSanPham.Text.Trim();
                sanPham.GiaNhap = Convert.ToDouble(txtGiaNhap.Text);
                sanPham.GiaBan = Convert.ToDouble(txtGiaBan.Text);
                sanPham.SoLuong = long.Parse(nupSoLuong.Value.ToString());
                sanPham.MaLoai = Convert.ToInt32(cbbTenLoaiSP.SelectedValue.ToString());
                //Đưa dữ liệu vào lại DB
                dbcontext.SanPham.AddOrUpdate(sanPham);
                dbcontext.SaveChanges();
                ReLoadDgv();
                ResetForm();
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Không tìm tháy mã hoa cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // giúp một đối tượng có thể thực hiện duyệt các phần tử
            IEnumerable<SanPham> found = dbcontext.SanPham;
            //contains giúp kiểm tra sự tồn tại của chuỗi txb trong chuỗi của đối tượng 
            var result = found.Where(x => x.MaSP.ToString().Contains(txtTimKiem.Text) || x.TenSP.Contains(txtTimKiem.Text) || x.LoaiSanPham.TenLoai.ToString().Contains(txtTimKiem.Text)).ToList();

            this.FillDataDgv(result);
        }
    }
}
