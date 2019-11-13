using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.DTOs
{
    public class SaveChiTietDonThuocDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SoThuTu { get; set; }

        [DisplayName("Mã thuốc")]
        public Nullable<int> MaThuoc { get; set; }

        [DisplayName("Số lượng")]
        public Nullable<int> SoLuong { get; set; }

        [DisplayName("Thành tiền ")]
        public Nullable<double> ThanhTien { get; set; }
        [DisplayName("Cách dùng")]
        public string CachDung { get; set; }

        [DisplayName("Mã đơn thuốc")]
        public Nullable<int> MaDonThuoc { get; set; }

        public virtual SaveDonThuocDTO DonThuoc { get; set; }
        public virtual SaveThuocDTO Thuoc { get; set; }
    }
}