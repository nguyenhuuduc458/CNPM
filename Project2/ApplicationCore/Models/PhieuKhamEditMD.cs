using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models
{
    public class PhieuKhamEditMD
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id{ get; set; }
      [DisplayName("Tên bác sĩ")]
      public string TenBacSy{ get; set; }
      [DisplayName("Tên bệnh nhân ")]
      public string TenBenhNhan{ get; set; }
      public int MaNhanVien{ get; set; }
      public int MaBenhNhan { get; set; }
      [DisplayName("Triệu chứng")]
      public string TrieuChung { get; set; }
      [DisplayName("Ngày khám")]
      [DataType(DataType.Date)]
      public DateTime  NgayKham{ get; set; }   
    }
}