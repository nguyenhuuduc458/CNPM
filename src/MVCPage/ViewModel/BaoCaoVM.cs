using ApplicationCore.Models;

namespace MVCPage.ViewModel
{
    public class BaoCaoVM
    {
        public PaginatedList<BaoCao> BaoCaos { get; set; }
        public PaginatedList<BaoCaoDoanhThuMD> BaoCaoDoanhThus{ get; set; }
    }
}