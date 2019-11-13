using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCPage.Interfaces;
using MVCPage.ViewModel;

namespace MVCPage.Controllers {
    public class ThuocController : Controller {
        private readonly IThuocServiceView _serviceView;
        private readonly IThuocService _service;
        private readonly IMapper _mapper;
        public ThuocController (IThuocServiceView serviceView, IThuocService service, IMapper mapper) {
            _serviceView = serviceView;
            _service = service;
            _mapper = mapper;
        }
        public IActionResult Index (string CurrentFilter, int pageIndex = 1) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "3")
            {
                ViewData["CurrentFilter"] = CurrentFilter;
                ThuocIndexVM vm = _serviceView.GetThuocIndexVM(CurrentFilter, pageIndex);
                return View(vm);
            }else{
                return View("../Account/Index");
            }
          
        }
        public IActionResult Create () {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "3")
            {
                return View();
            }else{
                return View("../Account/Index");
            }
          
        }

        [HttpPost]
        public IActionResult Create (SaveThuocDTO thuoc) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "3")
            {
                _service.Create(thuoc);
                return RedirectToAction(nameof(Index));
            }else
            {
                return View("../Account/Index");
            }
           
        }
        public IActionResult Edit (int? id) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "3")
            {
                if (id == null)
                {
                    return NotFound();
                }
                var thuoc = _service.GetThuoc(id.Value);
                SaveThuocDTO svt = _mapper.Map<ThuocDTO, SaveThuocDTO>(thuoc);
                return View(svt);
            }else
            {
                return View("../Account/Index");
            }

           
        }

        [HttpPost]
        public IActionResult Edit (SaveThuocDTO thuoc) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "3")
            {
                if (ModelState.IsValid)
                {
                    _service.Edit(thuoc);
                }
                return RedirectToAction(nameof(Index));
            }else
            {
                return View("../Account/Index");
            }
          
        }
        public IActionResult Delete (int? id) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "3")
            {
                if (id == null)
                {
                    return NotFound();
                }
                var thuoc = _service.GetThuoc(id.Value);
                SaveThuocDTO svt = _mapper.Map<ThuocDTO, SaveThuocDTO>(thuoc);
                return View(svt);
            }else
            {
                return View("../Account/Index");
            }
           
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int? id){
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "3")
            {
                if (id == null)
                {
                    return NotFound();
                }
                _service.Delete(id.Value);
                return RedirectToAction(nameof(Index));
            }else
            {
                return View("../Account/Index");
            }
           
        }

        public IActionResult Details(int? id){
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "3")
            {
                if (id == null)
                {
                    return NotFound();
                }
                var thuoc = _service.GetThuoc(id.Value);
                return View(thuoc);
            }
            else
            {
                return View("../Account/Index");
            }
        }
        
    }
}