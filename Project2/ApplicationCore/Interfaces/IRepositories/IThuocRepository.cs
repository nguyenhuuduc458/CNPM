using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IThuocRepository : IRepository<Thuoc>
    {
        IEnumerable<BaoCao> BCThuoc(int startMonth, int endMonth, int year);
        void CapNhapSoLuongThuoc(int maThuoc, int soLuong);
    }
}