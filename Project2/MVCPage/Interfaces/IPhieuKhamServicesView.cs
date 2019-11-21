using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using ApplicationCore.Entities;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public interface IPhieuKhamServiceView
    {
        PhieuKhamIndexVM GetPhieuKhamIndexVM(string searchString, int pageIndex, int MaNhanVien);
        PhieuKhamEditVM GetViewEditPhieuKham(int id);
        PhieuKhamCreateVM GetPhieuKhamCreateVM(int MaBenhNhan,int MaNhanVien);
    }
}