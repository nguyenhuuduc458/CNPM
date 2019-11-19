using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using ApplicationCore.Entities;
using MVCPage.Models;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public interface IPhieuKhamService
    {
        PhieuKhamIndexVM GetPhieuKhamIndexVM(string sortOrder, string searchString, int pageIndex);
     // void Delete(int id);
        void Create(PhieuKham phieuKham);
        void Edit(PhieuKham phieuKham);
        DateTime GetNgayKham();
        IEnumerable<Benh> GetLoaiBenh();
        PhieuKhamEditVM GetViewEditPhieuKham(int id);
    }
}