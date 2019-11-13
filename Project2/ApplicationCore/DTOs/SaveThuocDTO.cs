using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.DTOs
{
    public class SaveThuocDTO : IAggregateRoot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaveThuocDTO()
        {
            this.ChiTietDonThuocs = new HashSet<SaveChiTietDonThuocDTO>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThuoc { get; set; }
        [DisplayName("Tên thuốc")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string TenThuoc { get; set; }
        [Required]
        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }
        [DisplayName("Đơn vị")]
        [Required]
        public string DonVi { get; set; }
        [DisplayName("Đơn giá")]
        [Required]
        public Nullable<double> DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaveChiTietDonThuocDTO> ChiTietDonThuocs { get; set; }
    }
}