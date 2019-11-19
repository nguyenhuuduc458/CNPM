using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MVCPage.Models
{
   public class PhieuKhamMD{
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id{ get; set; }
      public string TenBacSy{ get; set; }
      public string TenBenhNhan{ get; set; }
      public string ChuanDoan { get; set; }
      [DataType(DataType.Date)]
      public DateTime  NgayKham{ get; set; }

    }
}