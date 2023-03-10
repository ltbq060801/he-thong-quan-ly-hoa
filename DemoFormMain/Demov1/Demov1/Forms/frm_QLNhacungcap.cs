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
    public partial class frm_QLNhacungcap : Form
    {
        DBQuanLyCuaHang dbcontext = new DBQuanLyCuaHang();
        public frm_QLNhacungcap()
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
            lblNCC.ForeColor = ThemeColor.SecondaryColor;
            lblDSNCC.ForeColor = ThemeColor.PrimaryColor;
        }
        private void frm_QLNhacungcap_Load(object sender, EventArgs e)
        {
            LoadTheme();
            List<NhaCungCap> dsNhaCungCap = dbcontext.NhaCungCap.ToList();
            //do du lieu vao dgv
            FillDataDgv(dsNhaCungCap);
        }

        private void FillDataDgv(List<NhaCungCap> dsNhaCungCap)
        {
            dgvDanhSachNhaCungCap.Rows.Clear();//xoa du lieu cu
            foreach (var item in dsNhaCungCap)
            {
                int RowNew = dgvDanhSachNhaCungCap.Rows.Add();//khoi tao dong moi
                dgvDanhSachNhaCungCap.Rows[RowNew].Cells[0].Value = item.MaNCC;
                dgvDanhSachNhaCungCap.Rows[RowNew].Cells[1].Value = item.TenNCC;
                dgvDanhSachNhaCungCap.Rows[RowNew].Cells[2].Value = item.SDT;
                dgvDanhSachNhaCungCap.Rows[RowNew].Cells[3].Value = item.DiaChi;
               
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckDataInput())
            {
                if (KiemTraMaNhaCungCap(txtMaNCC.Text) == -1)//nha cung cap chua ton tai trong ds
                {
                    NhaCungCap nhacc = new NhaCungCap();
                    //gan gia tri tu control vao sinhvien
                    //nhacc.MaNCC = Convert.ToInt32(txtMaNCC.Text);
                    nhacc.TenNCC = txtTenNCC.Text;
                    nhacc.SDT = txtSDT.Text;
                    nhacc.DiaChi = txtDiaChi.Text;
                    
                    //truyen du lieu vao db
                    dbcontext.NhaCungCap.AddOrUpdate(nhacc);
                    //luu thay doi
                    dbcontext.SaveChanges();
                    
                    ReLoadDgv();
                    ReLoadForm();
                    MessageBox.Show($"Thêm nhà cung cấp có mã { nhacc.MaNCC} thành công");
                }
                else
                    MessageBox.Show($"Mã nhà cung cấp {txtMaNCC.Text} đã tồn tại");
            }
        }

        private void ReLoadForm()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }

        private void ReLoadDgv()
        {
            List<NhaCungCap> newNhaCungCap= dbcontext.NhaCungCap.ToList();
            FillDataDgv(newNhaCungCap);
        }

        private int KiemTraMaNhaCungCap(string idNhaCungCap)
        {
            int length = dgvDanhSachNhaCungCap.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                if (dgvDanhSachNhaCungCap.Rows[i].Cells[0].Value.ToString() == idNhaCungCap)
                    return i;
            }
            return -1;
        }

        private bool CheckDataInput()
        {
            if (txtMaNCC.Text == "" || txtTenNCC.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã!");
                return;
            }

            int id;

            bool success = int.TryParse(txtMaNCC.Text, out id);

            if (!success)
            {
                MessageBox.Show("Mã không đúng định dạng!");
                return;
            }

            if (MessageBox.Show("Bạn thật sự muốn xoá?", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            if (!dbcontext.NhaCungCap.ToList().Any(s => s.MaNCC == id))
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp!");
                return;
            }

            /*if (dbcontext.ChiTietLapDonHang.ToList().Any(s => s.MaSP == id))
            {
                MessageBox.Show("Sản phẩm này đã được mua, không thể xoá!");
                return;
            }*/


            NhaCungCap nhaCungCap = dbcontext.NhaCungCap.FirstOrDefault(p => p.MaNCC == id);
            dbcontext.NhaCungCap.Remove(nhaCungCap);
            dbcontext.SaveChanges();
            ReLoadDgv();
            MessageBox.Show("Xoá thành công!");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int mancc = Convert.ToInt32(txtMaNCC.Text);
            //FirtOrDefault lấy phần tử đầu tiên thỏa điều kiện
            NhaCungCap nhaCungCap = dbcontext.NhaCungCap.FirstOrDefault(p => p.MaNCC == mancc);
            //Kiểm tra đối tượng 
            if (nhaCungCap != null)
            {
                //gắn lại các đối tượng thay đổi
                nhaCungCap.TenNCC = txtTenNCC.Text.Trim();
                nhaCungCap.SDT = txtSDT.Text;
                nhaCungCap.DiaChi = txtDiaChi.Text;
                
                //Đưa dữ liệu vào lại DB
                dbcontext.NhaCungCap.AddOrUpdate(nhaCungCap);
                dbcontext.SaveChanges();

                ReLoadDgv();
                ReLoadForm();
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Không tìm tháy mã hoa cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSachNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSachNhaCungCap.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvDanhSachNhaCungCap.CurrentCell.Selected = true;
                    // gan du lieu nguoc ve cac control;
                    txtMaNCC.Text = dgvDanhSachNhaCungCap.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTenNCC.Text = dgvDanhSachNhaCungCap.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtSDT.Text = dgvDanhSachNhaCungCap.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    txtDiaChi.Text = dgvDanhSachNhaCungCap.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                  

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Bạn chọn sai, vui lòng chọn lại!", "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
