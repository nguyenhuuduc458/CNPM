using System.Collections;
using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces.IServices
{
    public interface INhanVienService
    {
        SaveNhanVienDTO GetNhanVien(int id);
        IEnumerable<SaveNhanVienDTO> GetNhanViens(string sortOrder, string searchString,int pageIndex, int pageSize, out int count);
        void Create(SaveNhanVienDTO nhanvien);
        void Delete(int id);
        void Edit(SaveNhanVienDTO nhanvien);
        string GetTenVaiTro(int MaVaiTro);
        IEnumerable<SaveVaiTroDTO> GetDSVTConlai(int MaVaiTro);
        IEnumerable<SaveVaiTroDTO> GetAllMaVT();
        bool Login(string username, string password);
        List<string> CreateSession(string username, string password);
        void UpdatePassword(string username,string matKhau,string MatKhauMoi);
        bool checkValidPassword(string username,string matKhau);
    }
}