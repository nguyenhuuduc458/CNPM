using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCPage.ViewModel;

namespace MVCPage.Services {
    public class NhanVienServiceView : INhanVienServiceView{
        private readonly INhanVienService _service;
        private int pageSize = 3;
        public NhanVienServiceView (INhanVienService service) {
            _service = service;
        }
        
        public NhanVienIndexVM GetNhanVienIndexVM (string sortOrder, string searchString,string EmpRole, int pageIndex) {
            int count;
            var nhanvien = _service.GetNhanViens(sortOrder, searchString, EmpRole ,pageIndex, pageSize, out count);
            var vaitro = _service.GetVaiTro();
            //paging
            return new NhanVienIndexVM
            {
                EmpRole = new SelectList(vaitro),
                NhanViens = new PaginatedList<SaveNhanVienDTO>(nhanvien, pageIndex, pageSize,count)
            };
        }
    }
}