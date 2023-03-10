namespace Demov1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietNhapHang")]
    public partial class ChiTietNhapHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNhapHang { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        public double GiaNhap { get; set; }

        public int SoLuong { get; set; }

        public double DonGia { get; set; }

        public virtual NhapHang NhapHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
