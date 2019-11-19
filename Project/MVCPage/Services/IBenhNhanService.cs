using ApplicationCore.Entities;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public interface IBenhNhanService
    {
        BenhNhanIndexVM GetBenhNhanIndexVM(string sortOrder, string searchString, int pageIndex);
        void Delete(int id);
        void Create(BenhNhan benhNhan);
        void Edit(BenhNhan benhNhan);
    }
}