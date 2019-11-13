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

        public Nullable<int> MaThuoc { get; set; }

        public Nullable<int> SoLuong { get; set; }

        public Nullable<double> ThanhTien { get; set; }
        public string CachDung { get; set; }

        public Nullable<int> MaDonThuoc { get; set; }

        public virtual DonThuoc DonThuoc { get; set; }
        public virtual Thuoc Thuoc { get; set; }
    }
}