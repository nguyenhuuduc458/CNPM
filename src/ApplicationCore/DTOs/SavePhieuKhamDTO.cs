using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.DTOs
{
    public class SavePhieuKhamDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SavePhieuKhamDTO()
        {
            this.DonThuocs = new HashSet<SaveDonThuocDTO>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhieuKham { get; set; }
        [DisplayName("Mã bệnh nhân")]
        [Required]
        public int MaBenhNhan { get; set; }
        [DisplayName("Mã bác sỹ")]
        [Required]
        public int MaNhanVien { get; set; }
        [DisplayName("Triệu chứng")]
        [Required]
        public string TrieuChung { get; set; }
        [DisplayName("Ngày khám")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> NgayKham { get; set; }
        [Required]
        [DisplayName("Trạng thái")]
        public string TrangThai{ get; set; }
        public virtual SaveBenhNhanDTO BenhNhan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaveDonThuocDTO> DonThuocs { get; set; }
        public virtual SaveNhanVienDTO NhanVien { get; set; }
    }
}