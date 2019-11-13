using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.DTOs
{
    public class SaveDonThuocDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaveDonThuocDTO()
        {
            this.ChiTietDonThuocs = new HashSet<SaveChiTietDonThuocDTO>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã đơn thuốc")]
        public int MaDonThuoc { get; set; }
        [DisplayName("Mã phiếu khám")]
        [Required]
        public Nullable<int> MaPhieuKham { get; set; }
        [DisplayName("Tổng tiền")]
        [DataType(DataType.Currency)]
        [Required]
        public Nullable<double> TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaveChiTietDonThuocDTO> ChiTietDonThuocs { get; set; }
        public virtual SavePhieuKhamDTO PhieuKham { get; set; }
    }
}