using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models
{
    public class ThongTinDonThuoc
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int SoThuTu{ get; set; }
      [DisplayName("Mã Thuốc")]
      public int  MaThuoc{ get; set; }
      [DisplayName("Tên thuốc")]
      [Required]
      public string TenThuoc{ get; set; }
      [DisplayName("Số lượng")]
      [Required]
      [RegularExpression(@"^[0-9]{1,3}$")]
      public int SoLuong{ get; set; }
      [DisplayName("Cách dùng")]
      [Required]
      public string CachDung { get; set; }
      [DisplayName("Thành tiền")]
      public Nullable<double> ThanhTien{ get; set; }
    }
}