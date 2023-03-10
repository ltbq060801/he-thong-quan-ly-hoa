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
    public delegate void SelectedCustomer(KhachHang khachHang, NhanVien Nhanvien );
    public partial class frm_Quanlykhachhang : Form
    {
        NhanVien Nhanvien;
        DBQuanLyCuaHang db;

        public event SelectedCustomer selectedCustomer;

        public frm_Quanlykhachhang()
        {
            InitializeComponent();
        }
        public frm_Quanlykhachhang(NhanVien Nhanvien, DBQuanLyCuaHang db)
        {
            InitializeComponent();
           
            this.Nhanvien = Nhanvien;
            this.db = db;//
        }

        public frm_Quanlykhachhang(NhanVien nhanVien,DBQuanLyCuaHang db, string title)
        {
            InitializeComponent();
            this.Nhanvien = nhanVien;
            this.db = db;
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

            /*btnTimKiem.BackColor = ThemeColor.PrimaryColor;
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;*/

            btnChon.BackColor = ThemeColor.PrimaryColor;
            btnChon.ForeColor = Color.White;
            btnChon.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            /*btnThemAnh.BackColor = ThemeColor.PrimaryColor;
            btnThemAnh.ForeColor = Color.White;
            btnThemAnh.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;*/




            btnXEMHD.BackColor = ThemeColor.PrimaryColor;
            btnXEMHD.ForeColor = Color.White;
            btnXEMHD.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            lblNTTKH.ForeColor = ThemeColor.SecondaryColor;
            lblDSKH.ForeColor = ThemeColor.PrimaryColor;
        }

        DBQuanLyCuaHang dbcontext = new DBQuanLyCuaHang();

        private void dgvDSKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_Quanlykhachhang_Load(object sender, EventArgs e)
        {
            LoadTheme();
            List<KhachHang> dsKhachHang = dbcontext.KhachHang.ToList();


            //do du lieu vao dgv

            FillDataDgv(dsKhachHang);
        }

        private void FillDataDgv(List<KhachHang> dsKhachHang)
        {
            dgvDSKH.Rows.Clear();//xoa du lieu cu
            foreach (var item in dsKhachHang)
            {
                int RowNew = dgvDSKH.Rows.Add();//khoi tao dong moi
                dgvDSKH.Rows[RowNew].Cells[0].Value = item.MaKH;
                dgvDSKH.Rows[RowNew].Cells[1].Value = item.TenKH;
                dgvDSKH.Rows[RowNew].Cells[2].Value = item.SDT;
                dgvDSKH.Rows[RowNew].Cells[3].Value = item.DiaChi;

            }
        }

        private int CheckIDKhachHang(string idKhachHang)
        {
            int length = dgvDSKH.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                if (dgvDSKH.Rows[i].Cells[0].Value.ToString() == idKhachHang)
                    return i;
            }
            return -1;
        }

        private bool CheckDataInput()
        {
            if ( txtTenKH.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return false;
            }
            else if (txtSDT.TextLength <10 )
            {
                MessageBox.Show("SĐT không hợp lệ", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckDataInput() == true )
            {
                if (CheckIDKhachHang(txtMaKH.Text) == -1)//sinh vien chua ton tai trong ds
                {
                    //khoitao 1 khach hang rong
                    KhachHang newKhachHang = new KhachHang();
                    //gan gia tri tu control vao sinhvien
                    //newKhachHang.MaKH = Convert.ToInt32(txtMaKH.Text);
                    newKhachHang.TenKH = txtTenKH.Text;
                    newKhachHang.SDT = txtSDT.Text;
                    newKhachHang.DiaChi = txtDiaChi.Text;
                    //truyen du lieu vao db
                    dbcontext.KhachHang.AddOrUpdate(newKhachHang);
                    //luu thay doi
                    dbcontext.SaveChanges();

                    MessageBox.Show($"Thêm khách hàng có mã { newKhachHang.MaKH} thành công");
                    LoadDgv();
                    LoadForm();
                }
                else
                    MessageBox.Show($"Mã số khách hàng {txtMaKH.Text} đã tồn tại");
            }
           
           
        }

        private void LoadDgv()
        {
            List<KhachHang> newlistkhachhang = dbcontext.KhachHang.ToList();
            FillDataDgv(newlistkhachhang);
        }

        private void LoadForm()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";

        }

        private void dgvDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDSKH.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvDSKH.CurrentCell.Selected = true;
                    // gan du lieu nguoc ve cac control;
                    txtMaKH.Text = dgvDSKH.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTenKH.Text = dgvDSKH.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtSDT.Text = dgvDSKH.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    txtDiaChi.Text = dgvDSKH.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
                int makh = Convert.ToInt32(txtMaKH.Text);
                KhachHang khachHangUpdate = dbcontext.KhachHang.FirstOrDefault(p => p.MaKH == makh);
                if (khachHangUpdate != null)
                {
                if (CheckDataInput())
                {
                    khachHangUpdate.TenKH = txtTenKH.Text;
                    khachHangUpdate.SDT = txtSDT.Text;
                    khachHangUpdate.DiaChi = txtDiaChi.Text;
                    dbcontext.KhachHang.AddOrUpdate(khachHangUpdate);
                    dbcontext.SaveChanges();//luu thay doi

                    LoadDgv();
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadForm();
                }
                    
                }
            }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!");
                return;
            }
            int id;

            bool success = int.TryParse(txtMaKH.Text, out id);

            if (!success)
            {
                MessageBox.Show("Mã không đúng định dạng!");
                return;
            }

            if (MessageBox.Show("Bạn thật sự muốn xoá?", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            if (!dbcontext.KhachHang.ToList().Any(s => s.MaKH == id))
            {
                MessageBox.Show("Không tìm thấy khách hàng!");
                return;
            }

            if (dbcontext.LapDonHang.ToList().Any(s => s.MaKH == id))
            {
                MessageBox.Show("Khách hàng đã tạo đơn đặt hàng, không thể xoá!");
                return;
            }
            int makhach = Convert.ToInt32(txtMaKH.Text);
            KhachHang deleteKhachHang = dbcontext.KhachHang.FirstOrDefault(p => p.MaKH == makhach);
            if (deleteKhachHang != null)
            {
                DialogResult dr = MessageBox.Show($"Bạn muốn xóa khách hàng {deleteKhachHang.TenKH} ", "thông báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    dbcontext.KhachHang.Remove(deleteKhachHang);
                    dbcontext.SaveChanges();

                    LoadDgv();
                    LoadForm();
                }
            }
        }

       

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // giúp một đối tượng có thể thực hiện duyệt các phần tử
            IEnumerable<KhachHang> found = dbcontext.KhachHang;
            //contains giúp kiểm tra sự tồn tại của chuỗi txb trong chuỗi của đối tượng 
            var result = found.Where(x => x.MaKH.ToString().Contains(txtTimKiem.Text) || x.TenKH.Contains(txtTimKiem.Text) || x.SDT.ToString().Contains(txtTimKiem.Text) 
            || x.DiaChi.ToString().Contains(txtTimKiem.Text)).ToList();

            this.FillDataDgv(result);
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập id khách hàng!");
                return;
            }

            int id;

            bool success = int.TryParse(txtMaKH.Text, out id);

            if (!success)
            {
                MessageBox.Show("Mã khách hàng không đúng định dạng!");
                return;
            }

            if (MessageBox.Show("Bạn thật sự muốn chọn khách hàng này?", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

           
            KhachHang customer = db.KhachHang.Where(s => s.MaKH == id).FirstOrDefault();
            selectedCustomer(customer, Nhanvien);

            this.Close();
        }
    }
}

        
 
