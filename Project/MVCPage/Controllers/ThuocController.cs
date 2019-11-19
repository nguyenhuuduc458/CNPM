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

namespace MVCPage.Controllers
{
    public class ThuocController : Controller{
        private readonly IThuocService _service;
        public ThuocController (IThuocService service){
            _service = service;
        }
        public IActionResult Index(string CurrentFileter, int pageIndex = 1){
            ThuocIndexVM vm = _service.GetThuocIndexVM(CurrentFileter, pageIndex);
            return View(vm);
        }
    }
}