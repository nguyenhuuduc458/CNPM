
using System;
using ApplicationCore.Interfaces.IRepositories;

namespace ApplicationCore.Interfaces {
    public interface IUnitOfWork : IDisposable {
        INhanVienRepository NhanViens { get; }
        IBenhNhanRepository BenhNhans { get; }
        IPhieuKhamRepository PhieuKhams { get; }
        IBenhRepository Benhs { get; }
        IDonThuocRepository DonThuocs { get; }
        IChiTietDonThuocRepository ChiTietDonThuocs{ get; }
        IThuocRepository Thuocs { get; }
        IVaiTroRepository VaiTros { get; }
        int Complete ();
    }
}