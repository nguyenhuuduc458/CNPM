using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCPage.ViewModel {
    public class NhanVienIndexVM {
        public SelectList EmpRole { get; set; }
        public PaginatedList<SaveNhanVienDTO> NhanViens { get; set; }
    }
}