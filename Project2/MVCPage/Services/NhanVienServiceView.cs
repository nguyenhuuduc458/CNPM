using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using MVCPage.ViewModel;

namespace MVCPage.Services {
    public class NhanVienServiceView : INhanVienServiceView{
        private readonly INhanVienService _service;
        private int pageSize = 3;
        public NhanVienServiceView (INhanVienService service) {
            _service = service;
        }
        
        public NhanVienIndexVM GetNhanVienIndexVM (string sortOrder, string searchString, int pageIndex) {
            int count;
            var nhanvien = _service.GetNhanViens(sortOrder, searchString,pageIndex, pageSize, out count);
            //paging
            return new NhanVienIndexVM {
                NhanViens = new PaginatedList<SaveNhanVienDTO>(nhanvien, pageIndex, pageSize,count)
            };
        }
    }
}