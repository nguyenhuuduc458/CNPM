using ApplicationCore.DTOs;
using ApplicationCore.Entities;

namespace MVCPage.ViewModel {
    public class NhanVienIndexVM {
        public PaginatedList<SaveNhanVienDTO> NhanViens { get; set; }
    }
}