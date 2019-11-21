using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationCore.Models {
    public class BaoCaoDoanhThuMD {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DisplayName("Thời gian")]
        [DataType(DataType.Date)]
        public DateTime ThoiGian { get; set; }
        [Required]
        [DisplayName ("Tổng doanh thu")]
        public double DoanhThu { get; set; }
    }
}