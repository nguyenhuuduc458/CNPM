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

        public string GetTenDangNhap(string username)
        {
            return QuanLyPhongMach.NhanViens.Where(u => u.TenDangNhap.Equals(username)).Select(u => u.TenDangNhap).FirstOrDefault();
        }

        public string GetMatkhau(string username)
        {
            return QuanLyPhongMach.NhanViens.Where(u => u.TenDangNhap.Equals(username)).Select(u => u.MatKhau).FirstOrDefault();
        }

        public string GetTenNhanVien(string username)
        {
            return QuanLyPhongMach.NhanViens.Where(u => u.TenDangNhap.Equals(username)).Select(u => u.HoTen).FirstOrDefault();
        }

        public int GetVaiTro(string username)
        {
            return QuanLyPhongMach.NhanViens.Where(u => u.TenDangNhap.Equals(username)).Select(u => u.MaVaiTro).FirstOrDefault();
        }

        protected QuanLyPhongMach QuanLyPhongMach {
            get { return Context as QuanLyPhongMach; }
        }
    }
}