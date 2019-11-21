using System.Net.Http.Headers;
using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;

namespace MVCPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == "1" ||role == "2" || role == "3"){
                return View();
            }else{
                return View("../Account/Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
    }
}
