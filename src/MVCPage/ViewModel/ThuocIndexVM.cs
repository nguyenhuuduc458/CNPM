using ApplicationCore.DTOs;

namespace MVCPage.ViewModel
{
    public class ThuocIndexVM
    {
        public PaginatedList<ThuocDTO> Thuocs { get; set; }
    }
}