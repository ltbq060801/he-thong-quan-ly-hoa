namespace Demov1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LapDonHang")]
    public partial class LapDonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LapDonHang()
        {
            ChiTietLapDonHang = new HashSet<ChiTietLapDonHang>();
        }

        [Key]
        public int MaLDH { get; set; }

        public DateTime NgayLap { get; set; }

        public int MaKH { get; set; }

        public int MaNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietLapDonHang> ChiTietLapDonHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
