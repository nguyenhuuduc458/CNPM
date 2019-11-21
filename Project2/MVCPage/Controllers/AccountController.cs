using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCPage.Controllers {
    public class AccountController : Controller {
        private INhanVienService _service;
        public AccountController (INhanVienService service) {
            _service = service;
        }
        public IActionResult Index () {
            if (HttpContext.Session.GetString ("Username") == null) {
                return View ();
            } else {
                return View ("../Home/index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index ([Bind ("TenDangNhap", "MatKhau")] NhanVien user) {
            string username = user.TenDangNhap;
            string password = user.MatKhau;       
            if (_service.Login(username,password)==true){
                List<string> listSession = _service.CreateSession(username,password);
                HttpContext.Session.SetString ("Username", username);
                HttpContext.Session.SetString("TenNhanVien",listSession.ElementAt(0));
                HttpContext.Session.SetString ("Role",listSession.ElementAt(1));
                HttpContext.Session.SetString("MaNhanVien", listSession.ElementAt(2).ToString());
                return View ("../Home/Index");
            }else{
                @ViewData["Error"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
                return View ();
            }
        }

        public IActionResult Logout () {
            HttpContext.Session.Remove ("Username");
            HttpContext.Session.Remove("TenNhanVien");
            HttpContext.Session.Remove("Role");
       //   HttpContext.Session.Remove("MaNhanVien");
            return View ("../Account/Index");
        }
    }
}