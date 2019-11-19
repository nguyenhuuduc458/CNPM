using System.Collections;
using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces {
    public interface INhanVienRepository : IRepository<NhanVien> {
        IEnumerable<string> GetGioiTinh ();
        IEnumerable<string> GetVaiTro ();
    }
}