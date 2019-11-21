using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class DonThuocRepository : Repository<DonThuoc>, IDonThuocRepository
    {
        public DonThuocRepository(QuanLyPhongMach context) : base(context)
        {
        }

      
        public QuanLyPhongMach QuanLyPhongMach{
            get { return Context as QuanLyPhongMach; }
        }

        public void CapNhatTrangThaiPhieuKham(int MaPhieuKham)
        {
            var phieukham = QuanLyPhongMach.PhieuKhams.Where(m => m.MaPhieuKham == MaPhieuKham).FirstOrDefault();
            phieukham.TrangThai = "Đã kê toa";
            QuanLyPhongMach.Entry(phieukham).State = EntityState.Modified;
            QuanLyPhongMach.SaveChanges();
        }

        public int GetMaDonThuoc(int MaPhieuKham)
        {
            return QuanLyPhongMach.DonThuocs.Where(m => m.MaPhieuKham == MaPhieuKham).Select(m => m.MaDonThuoc).FirstOrDefault();
        }
    }
}