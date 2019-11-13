using ApplicationCore.Entities;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public interface IBenhNhanServiceView
    {
        BenhNhanIndexVM GetBenhNhanIndexVM(string sortOrder, string searchString, int pageIndex);
    }
}