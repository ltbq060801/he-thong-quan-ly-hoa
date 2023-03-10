using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demov1.Model;

namespace Demov1.Forms
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }
        DBQuanLyCuaHang db = new DBQuanLyCuaHang();

        
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txbUser_Enter(object sender, EventArgs e)
        {
            if (txbUser.Text == "User")
            {
                txbUser.Text = "";
                txbUser.ForeColor = Color.LightGray;
            }
        }

        private void txbUser_Leave(object sender, EventArgs e)
        {
            if (txbUser.Text == "")
            {
                txbUser.Text = "User";
                txbUser.ForeColor = Color.Black;
            }
        }

        private void txbPassword_Enter(object sender, EventArgs e)
        {
            if (txbPassword.Text == "Password")
            {
                txbPassword.Text = "";
                txbPassword.ForeColor = Color.LightGray;
                txbPassword.UseSystemPasswordChar = true;
            }
        }

        private void txbPassword_Leave(object sender, EventArgs e)
        {
            if (txbPassword.Text == "")
            {
                txbPassword.Text = "Password";
                txbPassword.ForeColor = Color.Black;
                txbPassword.UseSystemPasswordChar = false;
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked == true)
            {
                txbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassword.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// hàm mã hoá mật khẩu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan()
            {
                 TaiKhoan1 = txbUser.Text,
                 MatKhau = MD5Hash(txbPassword.Text)
                
            };


            var result = db.TaiKhoan.Where(s => s.TaiKhoan1.Trim() == taiKhoan.TaiKhoan1.Trim() && s.MatKhau.Trim() == taiKhoan.MatKhau.Trim()).FirstOrDefault();
            if (result != null)
            {
                // do login

                this.Hide();
                var nv = db.NhanVien.Where(S => S.MaNV == result.MaNV).FirstOrDefault();
                frm_Main frm = new frm_Main(nv);
                frm.ShowDialog();
                //this.Show();
                //result.MaNV
                txbPassword.Text = "";
                return;
            }


            // do err


            MessageBox.Show("SDT hoặc mật khẩu không đúng!");
        }
    }
}
