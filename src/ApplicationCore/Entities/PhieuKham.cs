using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class PhieuKham : IAggregateRoot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuKham()
        {
            this.DonThuocs = new HashSet<DonThuoc>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhieuKham { get; set; }
       
        public int MaBenhNhan { get; set; }
        public int MaNhanVien { get; set; }
        public string TrieuChung { get; set; }
        public string TrangThai { get; set; }
        public Nullable<System.DateTime> NgayKham { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonThuoc> DonThuocs { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}