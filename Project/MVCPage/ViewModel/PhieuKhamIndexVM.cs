using ApplicationCore.Entities;
using MVCPage.Models;

namespace MVCPage.ViewModel
{
    public class PhieuKhamIndexVM
    {
        public PaginatedList<PhieuKhamMD> PhieuKhams { get; set; }
    }
}