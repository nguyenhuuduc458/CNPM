using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IBenhNhanService
    {
        SaveBenhNhanDTO GetBenhNhan(int id);
        IEnumerable<SaveBenhNhanDTO> GetBenhNhans(string sortOrder, string searchString);
        void Create(SaveBenhNhanDTO BenhNhan);
        void Delete(int id);
        void Edit(SaveBenhNhanDTO BenhNhan);
    }
}