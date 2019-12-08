using System.Data;
using System.Security.Principal;
using System;
using System.Linq;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPage.Services;
using MVCPage.ViewModel;
using Microsoft.AspNetCore.Http;

namespace MVCPage.Controllers {
    public class BenhNhanController : Controller {
        private readonly IBenhNhanServiceView _serviceView;
        private readonly IBenhNhanService _service;

        public BenhNhanController (IBenhNhanServiceView serviceView, IBenhNhanService service) {
            _service = service;
            _serviceView = serviceView;

        }

        public IActionResult Index (string sortOrder, string CurrentFilter, int pageIndex = 1) {
            ViewData["NameSortParam"] = String.IsNullOrEmpty (sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewData["CurrentFilter"] = CurrentFilter;
            ViewData["CurrentSort"] = sortOrder;
            string role = HttpContext.Session.GetString ("Role");
            if (HttpContext.Session.GetString ("Username") != null && (role.Equals("2")||role.Equals("3"))) {
                BenhNhanIndexVM indexNV = _serviceView.GetBenhNhanIndexVM (sortOrder, CurrentFilter, pageIndex);
                return View (indexNV);
            } else {
                 return RedirectToAction("Index", "Account");
            }           
        }

        // GET: NhanVien/Details/5
        public IActionResult Details (int? id) {
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var benhNhan = _service.GetBenhNhan(id.Value);
                if (benhNhan == null)
                {
                    return NotFound();
                }

                return View(benhNhan);
            }else{
                 return RedirectToAction("Index", "Account");   
            }
          
        }
        public IActionResult Create () {
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {
                return View ();
            }else{
                 return RedirectToAction("Index", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create ([Bind ("HoTen,GioiTinh,NgaySinh,DiaChi")] SaveBenhNhanDTO benhNhan) {
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {
                if (ModelState.IsValid)
                {
                    _service.Create(benhNhan);
                    return RedirectToAction(nameof(Index));
                }
                return View(benhNhan);
            }else{
                 return RedirectToAction("Index", "Account");
            }
           
        }

        public IActionResult Edit (int? id) {
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var benhNhan = _service.GetBenhNhan(id.Value);
                if (benhNhan == null)
                {
                    return NotFound();
                }
                ViewData["GioiTinh"] = benhNhan.GioiTinh.ToString();
                ViewData["GioiTinhConLai"] = benhNhan.GioiTinh == "Nam" ? "Nữ" : "Nam";
                return View(benhNhan);
            }
            else
            {
                 return RedirectToAction("Index", "Account");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, [Bind ("MaBenhNhan,HoTen,GioiTinh,NgaySinh,DiaChi")] SaveBenhNhanDTO benhNhan) {
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {
                if (id != benhNhan.MaBenhNhan)
                {
                    return NotFound();
                }
                _service.Edit(benhNhan);
                return RedirectToAction(nameof(Index));
            }else{
                 return RedirectToAction("Index", "Account");
            }
           
        }

        // GET: NhanVien/Delete/5
        public IActionResult Delete (int? id) {
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var benhNhan = _service.GetBenhNhan(id.Value);
                if (benhNhan == null)
                {
                    return NotFound();
                }

                return View(benhNhan);
            }else{
                 return RedirectToAction("Index", "Account");
            }

        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed (int id) {
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {
                _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }else{
                 return RedirectToAction("Index", "Account");
            }
           
        }

    }
}