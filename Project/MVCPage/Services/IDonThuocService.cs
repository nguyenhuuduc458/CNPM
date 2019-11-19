using System.Collections.Generic;
using ApplicationCore.Entities;
using MVCPage.Models;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public interface IDonThuocService
    {
        DonThuocIndexVM GetDonThuocIndexVM(int? MaDonThuoc,string searchString, int pageIndex);
        CreateDonThuocVM GetCreateDonThuocVM(CreateDonThuocVM createDonThuocVM,int MaPhieuKham);
        double TinhTongTien(IEnumerable<ThongTinDonThuoc> ttdt);
        IEnumerable<Thuoc> GetAllListThuoc();
        void LapDonThuoc(IEnumerable<ThongTinDonThuoc> ttdt,int MaPhieuKham);

    }
}