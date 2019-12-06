using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IThuocService
    {
        ThuocDTO GetThuoc(int id);
        IEnumerable<ThuocDTO> GetThuocs(string searchString, int pageIndex, int pageSize, out int count);
        void Create(SaveThuocDTO thuoc);
        void Delete(int id);
        void Edit(SaveThuocDTO thuoc);
    }
}