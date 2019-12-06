using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;

namespace MVCPage.ViewModel
{
    public class DonThuocIndexVM
    {
        public PaginatedList<DonThuoc> DonThuocs { get; set; }
        public IEnumerable<ChiTietDonThuoc> listChiTietDonThuoc{ get; set; }
    }
}