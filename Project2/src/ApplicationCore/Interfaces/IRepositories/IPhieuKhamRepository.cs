using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IPhieuKhamRepository : IRepository<PhieuKham>
    {
        IEnumerable<PhieuKhamMD> GetTablePhieuKham(IEnumerable<PhieuKham> phieuKhams, int MaNhanVien);
        IEnumerable<int> BCBenhNhan(int startMonth, int endMonth, int year);
        IEnumerable<BaoCaoDoanhThuMD> BCDoanhThu(int startMonth, int endMonth, int year);
    }
}