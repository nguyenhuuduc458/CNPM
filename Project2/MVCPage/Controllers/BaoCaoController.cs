using System.Globalization;
using System.Runtime.Serialization;
using System.Linq;
using System;
using System.ComponentModel.Design;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCPage.Services;
using MVCPage.ViewModel;
using Microsoft.AspNetCore.Http;

namespace MVCPage.Controllers {
    public class BaoCaoController : Controller {
        private readonly IBaoCaoServiceView _service;
        public BaoCaoController (IBaoCaoServiceView service) {
            _service = service;
        }

        public IActionResult Index (int StartMonth, int EndMonth,int year, int pageIndex = 1) {
            if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Role") == "1")
            {
                BaoCaoVM vm = _service.GetIndexBaoCaoVM(StartMonth, EndMonth, year, pageIndex);
                List<int> startMonth = new List<int>();
                List<int> endMonth = new List<int>();
                List<int> Year = new List<int>();
                var currentYear = DateTime.Now.Year;
                for (int i = 2010; i <= currentYear; i++)
                {
                    Year.Add(i);
                }
                for (int i = 1; i <= 12; i++)
                {
                    endMonth.Add(i);
                    startMonth.Add(i);
                }
                ViewData["startMonth"] = startMonth as List<int>;
                ViewData["endMonth"] = endMonth as List<int>;
                ViewData["year"] = Year as List<int>;
                return View(vm);
            }else
            {
                return View("../Account/Index");
            }
           
        }
        
    }
}