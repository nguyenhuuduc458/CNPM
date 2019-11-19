using System.Collections.Generic;
using ApplicationCore.Entities;
using MVCPage.ViewModel;

namespace MVCPage.Services {
    public interface INhanVienService {
        NhanVienIndexVM GetNhanVienIndexVM (string sortOrder, string searchString, int pageIndex);
        void Delete (int id);
        void Create (NhanVien nhanVien);
        void Edit (NhanVien nhanVien);
        IEnumerable<string> GetVaiTro ();
    }
}