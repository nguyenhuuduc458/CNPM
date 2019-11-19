using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCPage.Services;
using MVCPage.ViewModel;

namespace MVCPage.Controllers {
    public class PhieuKhamController : Controller {
        private readonly QuanLyPhongMach _context;
        private readonly IPhieuKhamService _service;

        public PhieuKhamController (QuanLyPhongMach context, IPhieuKhamService service) {
            _context = context;
            _service = service;

        }
        public IActionResult Index (string sortOrder, string CurrentFilter, int pageIndex = 1) {
           if (HttpContext.Session.GetString ("Username") != null && HttpContext.Session.GetString ("Role") == "2") {
            ViewData["NameSortParam"] = String.IsNullOrEmpty (sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewData["CurrentFilter"] = CurrentFilter;
            ViewData["CurrentSort"] = sortOrder;
            PhieuKhamIndexVM indexNV = _service.GetPhieuKhamIndexVM (sortOrder, CurrentFilter, pageIndex);
            return View (indexNV);
            }else{
             return View("../Account/Index");
            }
        }

        public IActionResult Create(int id)
        {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "2"){
                ViewData["MaBenhNhan"] = id;
                ViewData["MaBacSy"] = HttpContext.Session.GetString("MaNhanVien");
                ViewData["TenBacSy"] = HttpContext.Session.GetString("TenNhanVien");
                PhieuKhamCreateVM vm = new PhieuKhamCreateVM
                {
                    PhieuKhams = new PhieuKham
                    {
                        MaBenhNhan = id,
                        MaNhanVien = Convert.ToInt32(HttpContext.Session.GetString("MaNhanVien")),
                        NgayKham = _service.GetNgayKham()
                    },

                    listTenBenh = _service.GetLoaiBenh()
                };
                 return View(vm);
            }else{
                return View("../Account/Index");
            }               
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create ( PhieuKhamCreateVM vm) {
            PhieuKham pk = new PhieuKham
            {
                MaNhanVien = vm.PhieuKhams.MaNhanVien,
                MaBenhNhan = vm.PhieuKhams.MaBenhNhan,
                TrieuChung = vm.PhieuKhams.TrieuChung,
                NgayKham = vm.PhieuKhams.NgayKham
            };
            if(ModelState.IsValid){
                _service.Create(pk);
                return RedirectToAction(nameof(Index));
            }      
            return View (pk);
        }

        public IActionResult Edit(int id){
            PhieuKhamEditVM vm = _service.GetViewEditPhieuKham(id);
            ViewData["TrieuChung"] = vm.PhieuKhamEdit.TrieuChung;
            return View (vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id,PhieuKhamEditVM vm){
            if(Id != vm.PhieuKhamEdit.Id){
                return NotFound();
            }
            PhieuKham pk = new PhieuKham
            {
                MaPhieuKham = vm.PhieuKhamEdit.Id,
                MaNhanVien = vm.PhieuKhamEdit.MaNhanVien,
                MaBenhNhan = vm.PhieuKhamEdit.MaBenhNhan,
                TrieuChung = vm.PhieuKhamEdit.TrieuChung,
                NgayKham = Convert.ToDateTime(vm.PhieuKhamEdit.NgayKham),
            };
            _service.Edit(pk);
            return RedirectToAction(nameof(Index));
        }

    }
}