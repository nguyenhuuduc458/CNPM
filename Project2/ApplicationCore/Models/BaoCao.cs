using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationCore.Models
{
    public class BaoCao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DisplayName("Số lượng thuốc đã bán")]
        public int SLTDaban { get; set; }
        [Required]
        [DisplayName("Tên thuốc")]
        public string TenThuoc { get; set; }
    }
}