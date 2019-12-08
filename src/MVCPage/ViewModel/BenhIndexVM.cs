using ApplicationCore.DTOs;
using ApplicationCore.Entities;

namespace MVCPage.ViewModel
{
    public class BenhIndexVM
    {
        public PaginatedList<SaveBenhDTO> Benhs { get; set; }
    }
}