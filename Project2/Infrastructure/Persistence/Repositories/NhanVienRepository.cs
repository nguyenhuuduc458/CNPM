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
        protected QuanLyPhongMach QuanLyPhongMach {
            get { return Context as QuanLyPhongMach; }
        }
    }
}