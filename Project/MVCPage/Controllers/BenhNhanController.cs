using System;
using System.Linq;
using ApplicationCore.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPage.Services;
using MVCPage.ViewModel;

namespace MVCPage.Controllers
{
    public class BenhNhanController : Controller
    {
        private readonly QuanLyPhongMach _context;
        private readonly IBenhNhanService _service;

        public BenhNhanController(QuanLyPhongMach context, IBenhNhanService service)
        {
            _context = context;
            _service = service;

        }

        public IActionResult Index(string sortOrder, string CurrentFilter, int pageIndex = 1)
        {
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewData["CurrentFilter"] = CurrentFilter;
            ViewData["CurrentSort"] = sortOrder;

            //if (HttpContext.Session.GetString ("Username") != null && HttpContext.Session.GetString ("Role").Equals ("1")) {
            BenhNhanIndexVM indexNV = _service.GetBenhNhanIndexVM(sortOrder, CurrentFilter, pageIndex);
            return View(indexNV);
            // } else {
            //     return View ("../Login/Index");
            // }
        }

        // GET: NhanVien/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benhNhan = _context.BenhNhans
                .FirstOrDefault(m => m.MaBenhNhan == id);
            if (benhNhan == null)
            {
                return NotFound();
            }

            return View(benhNhan);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("HoTen,GioiTinh,NgaySinh,DiaChi")] BenhNhan benhNhan)
        {
            if (ModelState.IsValid)
            {
                _service.Create(benhNhan);
                return RedirectToAction(nameof(Index));
            }
            return View(benhNhan);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benhNhan = _context.BenhNhans.Find(id);
            if (benhNhan == null)
            {
                return NotFound();
            }
            ViewData["GioiTinh"] = benhNhan.GioiTinh.ToString();
            ViewData["GioiTinhConLai"] = _context.BenhNhans.Where(m => m.GioiTinh != benhNhan.GioiTinh).Select(m => m.GioiTinh).FirstOrDefault().ToString();
            return View(benhNhan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("MaBenhNhan,HoTen,GioiTinh,NgaySinh,DiaChi")] BenhNhan benhNhan)
        {
            if (id != benhNhan.MaBenhNhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Edit(benhNhan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BenhNhanExists(benhNhan.MaBenhNhan))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(benhNhan);
        }

        // GET: NhanVien/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benhNhan = _context.BenhNhans
                .FirstOrDefault(m => m.MaBenhNhan == id);
            if (benhNhan == null)
            {
                return NotFound();
            }

            return View(benhNhan);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BenhNhanExists(int id)
        {
            return _context.BenhNhans.Any(e => e.MaBenhNhan == id);
        }
    }
}