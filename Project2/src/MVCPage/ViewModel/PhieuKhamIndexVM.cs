using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace MVCPage.ViewModel
{
    public class PhieuKhamIndexVM
    {
        public PaginatedList<PhieuKhamMD> PhieuKhams { get; set; }
    }
}