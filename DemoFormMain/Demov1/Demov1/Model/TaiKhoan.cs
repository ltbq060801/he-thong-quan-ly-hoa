namespace Demov1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        public int IDTK { get; set; }

        [Column("TaiKhoan")]
        [Required]
        [StringLength(50)]
        public string TaiKhoan1 { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        public int MaNV { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
