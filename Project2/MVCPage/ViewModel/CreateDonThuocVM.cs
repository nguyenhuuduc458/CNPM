using System.Collections;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace MVCPage.ViewModel
{
    public class CreateDonThuocVM
    {
        public  IEnumerable<Thuoc> thongtinthuoc { get; set; }
        public List<ThongTinDonThuoc> listThongTinDonThuoc  { get; set; }
        public ThongTinDonThuoc thongTinDonThuoc { get; set; }
        public double TongTien { get; set; }
        public int MaPhieuKham{ get; set; }
    }
}