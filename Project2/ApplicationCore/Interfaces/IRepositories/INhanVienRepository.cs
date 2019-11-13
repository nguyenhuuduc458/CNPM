using System.Collections;
using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IRepositories
 {
    public interface INhanVienRepository : IRepository<NhanVien> {
        IEnumerable<string> GetGioiTinh ();
        IEnumerable<string> GetVaiTro ();
        string GetTenDangNhap(string username);
        string GetTenNhanVien(string username);
        string GetMatkhau(string username);
        int GetVaiTro(string username);
    }
}