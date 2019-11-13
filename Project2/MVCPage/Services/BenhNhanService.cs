using System;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using MVCPage.ViewModel;

namespace MVCPage.Services {
    public class BenhNhanServiceView : IBenhNhanServiceView {
        private readonly IBenhNhanService _service;
        public BenhNhanServiceView (IBenhNhanService service) {
            _service = service;
        }
        public BenhNhanIndexVM GetBenhNhanIndexVM (string sortOrder, string searchString, int pageIndex) {
            //paging
            var benhNhan = _service.GetBenhNhans(sortOrder, searchString);
            int pageSize = 3;
            return new BenhNhanIndexVM
            {
                BenhNhans = PaginatedList<SaveBenhNhanDTO>.Create(benhNhan, pageIndex, pageSize)
            };
        }
    }
}