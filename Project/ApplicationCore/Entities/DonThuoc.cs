using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class DonThuoc : IAggregateRoot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonThuoc()
        {
            this.ChiTietDonThuocs = new HashSet<ChiTietDonThuoc>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã đơn thuốc")]
        public int MaDonThuoc { get; set; }
        [DisplayName("Mã phiếu khám")]
        public Nullable<int> MaPhieuKham { get; set; }
        [DisplayName("Tổng tiền")]
        [DataType(DataType.Currency)]
        public Nullable<double> TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonThuoc> ChiTietDonThuocs { get; set; }
        public virtual PhieuKham PhieuKham { get; set; }
    }
}