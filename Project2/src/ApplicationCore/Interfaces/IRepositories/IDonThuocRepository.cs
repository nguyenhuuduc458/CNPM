using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IDonThuocRepository : IRepository<DonThuoc>
    {
        void CapNhatTrangThaiPhieuKham(int MaPhieuKham);
        int  GetMaDonThuoc(int MaPhieuKham);
    }
}