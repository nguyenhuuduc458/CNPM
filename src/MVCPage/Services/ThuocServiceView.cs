using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using MVCPage.Interfaces;
using MVCPage.ViewModel;

namespace MVCPage.Services {
    public class ThuocServiceView : IThuocServiceView {
        private readonly IThuocService _service;
        private int pageSize = 3;
        public ThuocServiceView (IThuocService service) {
            _service = service;
        }
        public ThuocIndexVM GetThuocIndexVM (string CurrentFilter, int pageIndex) {
            int count;
            var thuoc = _service.GetThuocs(CurrentFilter,pageIndex,pageSize,out count);
            return new ThuocIndexVM {
                Thuocs = new PaginatedList<ThuocDTO>(thuoc, pageIndex, pageSize,count)
            };
        }
        

    }

}