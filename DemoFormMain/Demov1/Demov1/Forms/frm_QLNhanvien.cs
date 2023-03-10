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
using Demov1.Model;

namespace Demov1.Forms
{
    public partial class frm_QLNhanvien : Form
    {

        NhanVien nhanVien;
        DBQuanLyCuaHang dbcontext;
        public frm_QLNhanvien()
        {
            
        }

        public frm_QLNhanvien(NhanVien nhanVien, DBQuanLyCuaHang dbcontext)
        {
            InitializeComponent();
            this.nhanVien = nhanVien;
            this.dbcontext = dbcontext;
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

            lblNTTNV.ForeColor = ThemeColor.SecondaryColor;
            lblDSNV.ForeColor = ThemeColor.PrimaryColor;
        }
       
        private void FormQLNhanvien_Load(object sender, EventArgs e)
        {
            dbcontext = new DBQuanLyCuaHang();
            LoadTheme();
            List<NhanVien> listNhanVien = dbcontext.NhanVien.ToList();
            List<ChucVu> listChucVu = dbcontext.ChucVu.ToList();
            FillCbbChucVu(listChucVu);
            FillDataDgv(listNhanVien);
        }

    

        private void FillCbbChucVu(List<ChucVu> listChucVu)
        {
            cbbChucVu.DataSource = listChucVu;
            cbbChucVu.DisplayMember = "TenChucVu";
            cbbChucVu.ValueMember = "MaChucVu";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
         
            if (CheckDataInput())
            {
                if (KiemTraMaNhanVien(txtMaNhanVien.Text) == -1)// == -1 :nhan vien chua ton tai trong ds
                {
                    NhanVien nhanVien = new NhanVien();
                    //gan gia tri tu control vao sinhvien
                    nhanVien.MaNV = int.Parse((txtMaNhanVien.Text));
                    nhanVien.TenNV = txtTenNhanVien.Text;
                    nhanVien.SDT = txtSoDienThoai.Text;
                    nhanVien.DiaChi = txtDiaChi.Text;
                    nhanVien.CCCD = txtCCCD.Text;
                    nhanVien.NgaySinh = dtpNgaySinh.Value;
                    nhanVien.MaCV = Convert.ToInt32(cbbChucVu.SelectedValue.ToString());
                    //truyen du lieu vao db
                    dbcontext.NhanVien.AddOrUpdate(nhanVien);
                    //luu thay doi
                    dbcontext.SaveChanges();
                    MessageBox.Show($"Thêm nhân viên có mã { nhanVien.MaNV} thành công");
                    LoadDgv();
                    LoadForm();
                }
                else
                    MessageBox.Show($"Mã nhân viên {txtMaNhanVien.Text} đã tồn tại");
            }
        }

        private void LoadForm()
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
           
            dd.Text = "";

        }

        private void LoadDgv()
        {
            List<NhanVien> newListNhanVien = dbcontext.NhanVien.ToList();
            FillDataDgv(newListNhanVien);
        }

        private void FillDataDgv(List<NhanVien> newListNhanVien)
        {
            dgvDanhSachNhanVien.Rows.Clear();//xoa du lieu cu
            foreach (var item in newListNhanVien)
            {
                int RowNew = dgvDanhSachNhanVien.Rows.Add();//khoi tao dong moi
                dgvDanhSachNhanVien.Rows[RowNew].Cells[0].Value = item.MaNV;
                dgvDanhSachNhanVien.Rows[RowNew].Cells[1].Value = item.TenNV;
                dgvDanhSachNhanVien.Rows[RowNew].Cells[2].Value = item.SDT;
                dgvDanhSachNhanVien.Rows[RowNew].Cells[3].Value = item.DiaChi;
                dgvDanhSachNhanVien.Rows[RowNew].Cells[4].Value = item.CCCD;
                dgvDanhSachNhanVien.Rows[RowNew].Cells[5].Value = item.NgaySinh;
                dgvDanhSachNhanVien.Rows[RowNew].Cells[6].Value = item.ChucVu.TenChucVu;
            }
        }

        private bool CheckDataInput()
        {
             int yearnow = DateTime.Now.Year;
            if (   txtSoDienThoai.Text == "" || txtDiaChi.Text == "" || dd.Text == "" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return false;
            }
            else if (txtSoDienThoai.TextLength < 10)
            {
                MessageBox.Show("SĐT không hợp lệ", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if ((yearnow - dtpNgaySinh.Value.Year) < 18 )
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private int KiemTraMaNhanVien(string idNhanVien)
        {
            int length = dgvDanhSachNhanVien.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                if (dgvDanhSachNhanVien.Rows[i].Cells[0].Value.ToString() == idNhanVien)
                    return i;
            }
            return -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int manv = Convert.ToInt32(txtMaNhanVien.Text);
            NhanVien nhanVienDelete = dbcontext.NhanVien.FirstOrDefault(p => p.MaNV == manv);
            if (nhanVienDelete != null)
            {
                DialogResult dr = MessageBox.Show($"Bạn muốn xóa nhân viên có mã {nhanVienDelete.MaNV} ", "thông báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    dbcontext.NhanVien.Remove(nhanVienDelete);
                    dbcontext.SaveChanges();

                    LoadDgv();
                    LoadForm();
                }


            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int manv = int.Parse((txtMaNhanVien.Text));
            NhanVien nvtUpdate = dbcontext.NhanVien.FirstOrDefault(p => p.MaNV == manv);
            if (nvtUpdate != null)
            {
                nvtUpdate.TenNV = txtTenNhanVien.Text;
                nvtUpdate.SDT = txtSoDienThoai.Text;
                nvtUpdate.DiaChi = txtDiaChi.Text;
                nvtUpdate.CCCD = txtCCCD.Text;
                nvtUpdate.NgaySinh = dtpNgaySinh.Value;
                nvtUpdate.MaCV = Convert.ToInt32(cbbChucVu.SelectedValue.ToString());

                

                dbcontext.NhanVien.AddOrUpdate(nvtUpdate);
                dbcontext.SaveChanges();//luu thay doi

                LoadDgv();
                MessageBox.Show("Cap nhat thong tin thanh cong", "Thong bao", MessageBoxButtons.OK);
                LoadForm();
            }
        }

        private void dgvDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //kiemtra dgv co ton tao du lieu hay kh
                if (dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    //cho phep chon 1 dong
                    dgvDanhSachNhanVien.CurrentCell.Selected = true;
                    // gan du lieu nguoc ve cac control;
                    txtMaNhanVien.Text = dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTenNhanVien.Text = dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtSoDienThoai.Text = dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    txtDiaChi.Text = dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();          
                    txtCCCD.Text = dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    dtpNgaySinh.Value = Convert.ToDateTime(dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());
                    cbbChucVu.SelectedIndex = cbbChucVu.FindString(dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[6].FormattedValue.ToString());
                    

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Có vẻ bạn đang chọn sai chỗ!", "Cảnh báo!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
