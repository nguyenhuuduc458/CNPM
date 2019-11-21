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
        private int pageSize = 3;
        public BenhNhanServiceView (IBenhNhanService service) {
            _service = service;
        }
        public BenhNhanIndexVM GetBenhNhanIndexVM (string sortOrder, string searchString, int pageIndex) {
            //paging
            int count;
            var benhNhan = _service.GetBenhNhans(sortOrder, searchString,pageIndex,pageSize,out count);
            return new BenhNhanIndexVM
            {
                BenhNhans = new  PaginatedList<SaveBenhNhanDTO>(benhNhan, pageIndex, pageSize,count)
            };
        }
    }
}