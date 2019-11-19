using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class BenhNhan 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BenhNhan()
        {
            this.PhieuKhams = new HashSet<PhieuKham>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaBenhNhan { get; set; }
        [DisplayName("Họ tên")]
        [Required]
        public string HoTen { get; set; }
        [DisplayName("Giới tính")]
        [Required]
        public string GioiTinh { get; set; }
        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        [Required]
        public System.DateTime NgaySinh { get; set; }
        [DisplayName("Địa chỉ")]
        [Required]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuKham> PhieuKhams { get; set; }
    }
}