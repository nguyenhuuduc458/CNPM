using System;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCPage.Services;
using MVCPage.ViewModel;

namespace MVCPage.Controllers
{
    public class BenhController : Controller
    {
        private IBenhServiceView _serviceView;
        private IBenhService _service;

        public BenhController(IBenhServiceView serviceView, IBenhService service)
        {
            _service = service;
            _serviceView = serviceView;
        }
        public IActionResult Index(string currentFilter, string sortOrder, int pageIndex = 1)
        {
            
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role").Equals("3"))
            {
                ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
                ViewData["CurrentFilter"] = currentFilter;
                ViewData["CurrentSort"] = sortOrder;
                BenhIndexVM vm = _serviceView.GetBenhIndexVM(currentFilter, sortOrder, pageIndex);
                return View(vm);
            
            }
            else
            {
                 return RedirectToAction("Index", "Account");
            }
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role").Equals("3"))
            {
                return View();
            }
            else
            {
                 return RedirectToAction("Index", "Account");
            }
        }
        [HttpPost]
        public IActionResult Create(SaveBenhDTO SaveBenh)
        {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role").Equals("3"))
            {
                if (SaveBenh == null)
                {
                    return View();
                }
                _service.Create(SaveBenh);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                 return RedirectToAction("Index", "Account");
            }
        }

        public IActionResult Edit(int id)
        {
            
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role").Equals("3"))
            {
                var benh = _service.GetBenh(id);
                if (benh == null)
                {
                    return NotFound();
                }
                return View(benh);
            }
            else
            {
                 return RedirectToAction("Index", "Account");
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("MaBenh,TenBenh")] SaveBenhDTO SaveBenh)
        {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role").Equals("3"))
            {
                if(id != SaveBenh.MaBenh){
                    return NotFound();
                }
                _service.Edit(SaveBenh);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                 return RedirectToAction("Index", "Account");
            }
        }

        public IActionResult Details(int id)
        {
            
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role").Equals("3"))
            {
                var benh = _service.GetBenh(id);
                if (benh == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(benh);
                }
            }
            else
            {
                 return RedirectToAction("Index", "Account");
            }
        }
    }
}