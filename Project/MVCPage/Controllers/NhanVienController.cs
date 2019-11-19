using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCPage.Services;
using MVCPage.ViewModel;

namespace MVCPage.Controllers {
    public class NhanVienController : Controller {
        private readonly QuanLyPhongMach _context;
        private readonly INhanVienService _service;

        public NhanVienController (QuanLyPhongMach context, INhanVienService service) {
            _context = context;
            _service = service;

        }
        // GET: NhanVien
        public IActionResult Index (string sortOrder, string CurrentFilter, int pageIndex = 1) {
            // if (HttpContext.Session.GetString ("Username") != null && HttpContext.Session.GetString ("Role") == "1") {
            ViewData["NameSortParam"] = String.IsNullOrEmpty (sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewData["CurrentFilter"] = CurrentFilter;
            ViewData["CurrentSort"] = sortOrder;
            NhanVienIndexVM indexNV = _service.GetNhanVienIndexVM (sortOrder, CurrentFilter, pageIndex);
            return View (indexNV);
            //  }else{
            // return View("../Account/Index");
            //  }
        }

        // GET: NhanVien/Details/5
        public IActionResult Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var nhanVien = _context.NhanViens
                .FirstOrDefault (m => m.MaNhanVien == id);
            if (nhanVien == null) {
                return NotFound ();
            }

            return View (nhanVien);
        }

        // GET: NhanVien/Create

        public IActionResult Create () {
            ViewData["MaVaiTro"] = _service.GetVaiTro ().ToList ();
            return View ();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create ([Bind ("MaVaiTro,HoTen,GioiTinh,NgaySinh,DiaChi")] NhanVien nhanVien) {
            if (ModelState.IsValid) {
                _service.Create (nhanVien);
                return RedirectToAction (nameof (Index));
            }
            return View (nhanVien);
        }

        public IActionResult Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var nhanVien = _context.NhanViens.Find (id);
            if (nhanVien == null) {
                return NotFound ();
            }

            ViewData["MaVaiTro"] = nhanVien.MaVaiTro.ToString();
            ViewData["TenVaiTro"] = _context.VaiTros.Where(m => m.MaVaiTro==nhanVien.MaVaiTro).Select(n => n.TenVaiTro).FirstOrDefault().ToString();
            ViewData["DanhSach"] = _context.VaiTros.Where(n => n.MaVaiTro!=nhanVien.MaVaiTro).ToList();
            ViewData["GioiTinh"] = nhanVien.GioiTinh.ToString();
            ViewData["GioiTinhConLai"] = nhanVien.GioiTinh.ToString().Equals("Nam") ? "Nữ" : "Nam";
            return View (nhanVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, [Bind ("MaNhanVien,MaVaiTro,HoTen,GioiTinh,NgaySinh,DiaChi")] NhanVien nhanVien) {
            if (id != nhanVien.MaNhanVien) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _service.Edit (nhanVien);
                } catch (DbUpdateConcurrencyException) {
                    if (!NhanVienExists (nhanVien.MaNhanVien)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (nhanVien);
        }

        // GET: NhanVien/Delete/5
        public IActionResult Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var nhanVien = _context.NhanViens
                .FirstOrDefault (m => m.MaNhanVien == id);
            if (nhanVien == null) {
                return NotFound ();
            }

            return View (nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed (int id) {
            _service.Delete (id);
            return RedirectToAction (nameof (Index));
        }

        private bool NhanVienExists (int id) {
            return _context.NhanViens.Any (e => e.MaNhanVien == id);
        }
    }
}