using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.DTOs
{
    public class SaveBenhDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaBenh { get; set; }
        [DisplayName("Tên bệnh")]
        [Required]
        public string TenBenh { get; set; }
    }
}