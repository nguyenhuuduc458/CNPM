using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace ApplicationCore.DTOs
{
    public class ThuocDTO : IAggregateRoot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThuocDTO()
        {
            this.ChiTietDonThuocs = new HashSet<ChiTietDonThuoc>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThuoc { get; set; }
        public string TenThuoc { get; set; }

        public int SoLuong { get; set; }

        public string DonVi { get; set; }
        public double DonGia {get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ChiTietDonThuoc> ChiTietDonThuocs { get; set; }
}
}