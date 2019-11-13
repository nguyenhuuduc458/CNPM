using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IDonThuocService
    {
        IEnumerable<DonThuoc> GetDonThuocs(string searchString);
        IEnumerable<ChiTietDonThuoc> GetChiTietDonThuocs(int MaDonThuoc);
        IEnumerable<Thuoc> GetAllListThuoc();
        Thuoc GetThuocCondition(string TenThuoc);
        double TinhTongTien(IEnumerable<ThongTinDonThuoc> ttdt);
        void LapDonThuoc(IEnumerable<ThongTinDonThuoc> ttdt, int MaPhieuKham);
       void CapNhatTrangThaiPhieuKham(int MaPhieuKham);
    }
}