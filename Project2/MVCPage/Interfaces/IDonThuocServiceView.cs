using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public interface IDonThuocServiceView
    {
        DonThuocIndexVM GetDonThuocIndexVM(int MaDonThuoc,string searchString, int pageIndex);
        CreateDonThuocVM GetCreateDonThuocVM(CreateDonThuocVM createDonThuocVM,int MaPhieuKham);
        IEnumerable<Thuoc> GetAllListThuoc();
        bool KiemTraSoLuongTonKho(string TenThuoc,int soluongketoa);
        bool KiemTraThuocExist(string TenThuoc);
    }
}