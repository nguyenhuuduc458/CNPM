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
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using ApplicationCore.DTOs;

namespace MVCPage.Controllers {
    public class PhieuKhamController : Controller {
        private readonly IPhieuKhamServiceView _serviceView;
        private readonly IMapper _mapper;
        private readonly IPhieuKhamService _service;

        public PhieuKhamController (IPhieuKhamServiceView serviceView, IPhieuKhamService service,IMapper mapper) {
            _serviceView = serviceView;
            _service = service;
            _mapper = mapper;

        }
        public IActionResult Index (string sortOrder, string CurrentFilter, int pageIndex = 1) {
           if (HttpContext.Session.GetString ("Username") != null && HttpContext.Session.GetString ("Role") == "2") {
            ViewData["CurrentFilter"] = CurrentFilter;
                int  MaNhanVien = Convert.ToInt32(HttpContext.Session.GetString("MaNhanVien"));
                PhieuKhamIndexVM indexNV = _serviceView.GetPhieuKhamIndexVM (CurrentFilter, pageIndex,MaNhanVien);
             return View (indexNV);
            }else{
                return RedirectToAction("Index", "Account");
            }
        }

        public IActionResult Create(int id)
        {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "2"){
                int MaNhanVien = Convert.ToInt32(HttpContext.Session.GetString("MaNhanVien"));
                PhieuKhamCreateVM vm = _serviceView.GetPhieuKhamCreateVM(id,MaNhanVien);
                return View(vm);
            }else{
                return RedirectToAction("Index", "Account");
            }               
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (string TrieuChung,PhieuKhamCreateVM vm) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "2")
            {
                PhieuKham pk = new PhieuKham
                {
                    MaNhanVien = vm.PhieuKhams.MaNhanVien,
                    MaBenhNhan = vm.PhieuKhams.MaBenhNhan,
                    TrieuChung = TrieuChung,
                    NgayKham = DateTime.Parse(String.Format("{0:yyyy-MM-dd}",vm.PhieuKhams.NgayKham)),
                    TrangThai = "Chưa kê toa"
                };
                var savePK = _mapper.Map<PhieuKham, SavePhieuKhamDTO>(pk);
                if (ModelState.IsValid)
                {
                    _service.Create(savePK);
                    return RedirectToAction(nameof(Index));
                }
                return View(pk);
            }else{
                return RedirectToAction("Index", "Account");
            }
           
        }

        public IActionResult Edit(int id){
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "2")
            {
                PhieuKhamEditVM vm = _serviceView.GetViewEditPhieuKham(id);
                ViewData["TrieuChung"] = vm.PhieuKhamEdit.TrieuChung;
                return View(vm);
            }else{
                return RedirectToAction("Index", "Account");
            }
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id,PhieuKhamEditVM vm){
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "2")
            {
                if (Id != vm.PhieuKhamEdit.Id)
                {
                    return NotFound();
                }
                PhieuKham pk = new PhieuKham
                {
                    MaPhieuKham = vm.PhieuKhamEdit.Id,
                    MaNhanVien = vm.PhieuKhamEdit.MaNhanVien,
                    MaBenhNhan = vm.PhieuKhamEdit.MaBenhNhan,
                    TrieuChung = vm.PhieuKhamEdit.TrieuChung,
                    NgayKham = Convert.ToDateTime(vm.PhieuKhamEdit.NgayKham),
                    TrangThai = "Chưa kê toa"
                };
                var savePK = _mapper.Map<PhieuKham, SavePhieuKhamDTO>(pk);
                _service.Edit(savePK);
                return RedirectToAction(nameof(Index));
            }else{
                return RedirectToAction("Index", "Account");
            }       
        }
    }
}