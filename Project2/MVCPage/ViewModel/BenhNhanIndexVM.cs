using ApplicationCore.DTOs;
using ApplicationCore.Entities;

namespace MVCPage.ViewModel
{
    public class BenhNhanIndexVM
    {
        public PaginatedList<SaveBenhNhanDTO> BenhNhans { get; set; }
    }
}