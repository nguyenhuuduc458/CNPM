using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCPage.Services;
using MVCPage.ViewModel;

namespace MVCPage.Controllers {
    public class NhanVienController : Controller {
        private readonly INhanVienServiceView _serviceView;
        private readonly INhanVienService _service;
        private readonly IMapper _mapper;

        public NhanVienController ( INhanVienServiceView serviceView, INhanVienService service, IMapper mapper) {
            _serviceView = serviceView;
            _service = service;
            _mapper = mapper;

        }
        // GET: NhanVien
        public IActionResult Index (string sortOrder, string CurrentFilter, int pageIndex = 1) {
             if (HttpContext.Session.GetString ("Username") != null && HttpContext.Session.GetString ("Role") == "1") {
            ViewData["NameSortParam"] = String.IsNullOrEmpty (sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewData["CurrentFilter"] = CurrentFilter;
            ViewData["CurrentSort"] = sortOrder;
            NhanVienIndexVM indexNV = _serviceView.GetNhanVienIndexVM(sortOrder, CurrentFilter, pageIndex);
            return View (indexNV);
            }else{
             return View("../Account/Index");
            }
        }

        // GET: NhanVien/Details/5
        public IActionResult Details (int? id) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "1")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var nhanVien = _service.GetNhanVien(id.Value);
                if (nhanVien == null)
                {
                    return NotFound();
                }
                return View(nhanVien);

            }else{
                return View("../Account/Index");
            }
        }

        // GET: NhanVien/Create

        public IActionResult Create () {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "1")
            {
                ViewData["MaVaiTro"] = _service.GetAllMaVT();
                return View();
            }else{
                return View("../Account/Index");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create ([Bind ("MaVaiTro,HoTen,GioiTinh,NgaySinh,DiaChi")] SaveNhanVienDTO nhanVien) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "1")
            {
                _service.Create(nhanVien);
                return RedirectToAction(nameof(Index));
            }else{
                return View("../Account/Index");
            }

        }

        public IActionResult Edit (int? id) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "1")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var nhanVien = _service.GetNhanVien(id.Value);
                if (nhanVien == null)
                {
                    return NotFound();
                }
                ViewData["MaVaiTro"] = nhanVien.MaVaiTro.ToString();
                ViewData["TenVaiTro"] = _service.GetTenVaiTro(nhanVien.MaVaiTro);
                ViewData["DanhSach"] = _service.GetDSVTConlai(nhanVien.MaVaiTro);
                ViewData["GioiTinh"] = nhanVien.GioiTinh.ToString();
                ViewData["GioiTinhConLai"] = nhanVien.GioiTinh.ToString().Equals("Nam") ? "Nữ" : "Nam";
                return View(nhanVien);
            }else{
                return View("../Account/Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, [Bind ("MaNhanVien,MaVaiTro,HoTen,GioiTinh,NgaySinh,DiaChi,TenDangNhap,MatKhau")] SaveNhanVienDTO nhanVien) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "1")
            {
                if (id != nhanVien.MaNhanVien)
                {
                    return NotFound();
                }
                _service.Edit(nhanVien);
                return RedirectToAction(nameof(Index));
            }else{
                return View("../Account/Index");
            }

        }

        // GET: NhanVien/Delete/5
        public IActionResult Delete (int? id) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "1")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var nhanVien = _service.GetNhanVien(id.Value);
                if (nhanVien == null)
                {
                    return NotFound();
                }
                return View(nhanVien);
            }else{
                return View("../Account/Index");
            }
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed (int id) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "1")
            {
                _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }else{
                return View("../Account/Index");
            }

        }
    }
}