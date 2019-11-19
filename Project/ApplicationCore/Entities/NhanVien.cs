using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ApplicationCore.Entities
{
    public class NhanVien : IAggregateRoot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.PhieuKhams = new HashSet<PhieuKham>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhanVien { get; set; }
        [DisplayName("Mã vai trò")]
        [Required]
        public int MaVaiTro { get; set; }
        [DisplayName("Họ tên")]
        [Required]
        public string HoTen { get; set; }
        [DisplayName("Giới tính")]
        [Required]
        public string GioiTinh { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Ngày sinh")]
        [Required]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        [DisplayName("Địa chỉ")]
        [Required]
        public string DiaChi { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        
        public virtual VaiTro VaiTro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuKham> PhieuKhams { get; set; }
    }
}