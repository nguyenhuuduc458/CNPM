using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities {
    public class ChiTietDonThuoc : IAggregateRoot {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int SoThuTu { get; set; }

        [DisplayName ("Mã thuốc")]
        public Nullable<int> MaThuoc { get; set; }

        [DisplayName ("Số lượng")]
        public Nullable<int> SoLuong { get; set; }

        [DisplayName ("Thành tiền ")]
        [DisplayFormat (DataFormatString = "{0:C0}")]
        public Nullable<double> ThanhTien { get; set; }
        [DisplayName("Cách dùng")]
        public string CachDung { get; set; }

        [DisplayName ("Mã đơn thuốc")]
        public Nullable<int> MaDonThuoc { get; set; }

        public virtual DonThuoc DonThuoc { get; set; }
        public virtual Thuoc Thuoc { get; set; }
    }
}