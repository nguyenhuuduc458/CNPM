using System.Collections.Generic;
using ApplicationCore.Entities;
using MVCPage.ViewModel;

namespace MVCPage.Services {
    public interface INhanVienServiceView {
        NhanVienIndexVM GetNhanVienIndexVM (string sortOrder, string searchString,string EmpRole, int pageIndex);
    }
}