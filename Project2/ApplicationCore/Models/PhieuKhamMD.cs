using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel;

namespace ApplicationCore.Models
{
   public class PhieuKhamMD{
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id{ get; set; }
      [DisplayName("Tên bác sĩ")]
      public string TenBacSy{ get; set; }
      [DisplayName("Tên bệnh nhân")]
      public string TenBenhNhan{ get; set; }
      [DisplayName("Chuẩn đoán")]
      [Required]
      public string ChuanDoan { get; set; }
      [DataType(DataType.Date)]
      [DisplayName("Ngày khám")]
      public DateTime  NgayKham{ get; set; }
      [Required]
      [DisplayName("Trạng thái ")]
      public string TrangThai{ get; set; }
    }
}