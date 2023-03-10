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
using Microsoft.Reporting.WinForms;

namespace Demov1.Reports
{
    public partial class OrderReport : Form
    {
        LapDonHang lapDonhang;
        public OrderReport(LapDonHang lapDonhang)
        {
            InitializeComponent();
            this.lapDonhang = lapDonhang;
        }

        private void OrderReport_Load(object sender, EventArgs e)
        {
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void OrderReport_Load_1(object sender, EventArgs e)
        {
            ReportParameter[] param = new ReportParameter[] {
                new ReportParameter("Date", "Ngày " + lapDonhang.NgayLap.ToString("dd") + " tháng " + lapDonhang.NgayLap.ToString("MM") + " năm " + lapDonhang.NgayLap.ToString("yyyy") ),
                new ReportParameter("tenKhachHang", "Họ tên khách hàng: " + lapDonhang.KhachHang.TenKH ),
                new ReportParameter("soHoaDon", "Mã đơn hàng: " + lapDonhang.MaLDH.ToString() ),
                new ReportParameter("TongTien", lapDonhang.ChiTietLapDonHang.Sum(s=>s.DonGia * s.SoLuong).ToString("#,###,###") )

            };
            this.reportViewer1.LocalReport.ReportPath = "OrderReport.rdlc";
            this.reportViewer1.LocalReport.SetParameters(param);
            
            var result = from s in lapDonhang.ChiTietLapDonHang.ToList()
                         select new { MaSP = s.MaSP, tenSP = s.SanPham.TenSP, soLuong = s.SoLuong, donGia = s.DonGia.ToString("#,###,###"), thanhTien = (s.SoLuong * s.DonGia).ToString("#,###,###") };

            var reportDataResource = new ReportDataSource("DataSetOrder", result.ToList());
            this.reportViewer1.LocalReport.DataSources.Add(reportDataResource);
            this.reportViewer1.RefreshReport();
        }
    }
}
