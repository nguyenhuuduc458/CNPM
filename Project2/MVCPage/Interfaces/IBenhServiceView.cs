using System.Collections.Generic;
using ApplicationCore.Entities;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public interface IBenhServiceVIew
    {
        BenhIndexVM GetBenhIndexVM(string sortOrder, string searchString, int pageIndex);
        void Delete(int id);
        void Create(Benh benh);
        void Edit(Benh benh);
    }
}