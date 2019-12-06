using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories {
    public class NhanVienRepository : Repository<NhanVien>, INhanVienRepository 
    {
        public NhanVienRepository (QuanLyPhongMach context) : base (context) { }

        public IEnumerable<string> GetGioiTinh () {
            return QuanLyPhongMach.NhanViens.Select (m => m.GioiTinh).Distinct ().ToList ();
        }

        public IEnumerable<string> GetVaiTro () {
            return QuanLyPhongMach.VaiTros.Select (m => m.TenVaiTro).Distinct ().ToList ();;
        }

        public void UpdatePassword(string username, string MatKhau, string matKhauMoi)
        {
            var nhanvien = QuanLyPhongMach.NhanViens.Where(u => u.TenDangNhap.Equals(username) && u.MatKhau.Equals(MatKhau)).FirstOrDefault();
            nhanvien.MatKhau = matKhauMoi;
            QuanLyPhongMach.Entry(nhanvien).State = EntityState.Modified;
            QuanLyPhongMach.SaveChanges();

        }

        protected QuanLyPhongMach QuanLyPhongMach {
            get { return Context as QuanLyPhongMach; }
        }
    }
}