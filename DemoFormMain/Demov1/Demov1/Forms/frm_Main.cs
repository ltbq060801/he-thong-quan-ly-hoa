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



namespace Demov1
{
    public partial class frm_Main : Form
    {
        private Button currentButton;
        private Random random;
        private int temp;
        private Form activeform;

        NhanVien nhanvien;
        DBQuanLyCuaHang db;
        TaiKhoan taiKhoan;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public frm_Main()
        {
            InitializeComponent();
        }
        public frm_Main(NhanVien nhanVien)
        {
        
            InitializeComponent();
            random = new Random();
            btnCloseForms.Visible = false;
            this.nhanvien = nhanVien;
            db = new DBQuanLyCuaHang();
       

        }


        public Color SelectThemeColor()
        {
            random = new Random();
            int index = random.Next(ThemeColor.ColorList.Count);
            while(temp == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            temp = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActiveButton(object btnSender)
        {
            if( btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    pnlTitleBar.BackColor = color;
                    panel1.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseForms.Visible = true;
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                }
            }
        }

        private void DisableButton()
        {
            foreach (Control nutDaBam in panelMenu.Controls)
            {
                if(nutDaBam.GetType() == typeof(Button))
                {
                    nutDaBam.BackColor = Color.FromArgb(51, 51, 76);
                    nutDaBam.ForeColor = Color.Gainsboro;
                    nutDaBam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

       
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeform!= null)
            {
                activeform.Close();
            }
            ActiveButton(btnSender);
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlChildForm.Controls.Add(childForm);
            this.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;

        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frm_SanPham(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frm_DonDatHang(nhanvien,db), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frm_Quanlykhachhang(nhanvien,db), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frm_QLNhanvien(nhanvien,db), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frm_QLNhacungcap(), sender);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(activeform != null)
            {
                activeform.Close();

            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            pnlTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panel1.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseForms.Visible = false; 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.QLDonDatHang(nhanvien,db), sender);
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToLongTimeString();
        }

        private void pnlChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Import(nhanvien, db), sender);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn đăng xuất", "Thông báo", MessageBoxButtons.OKCancel);
            if(dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
