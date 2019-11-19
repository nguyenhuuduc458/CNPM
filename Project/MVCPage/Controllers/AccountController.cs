using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCPage.Controllers {
    public class AccountController : Controller {
        private readonly QuanLyPhongMach _context;
        public AccountController (QuanLyPhongMach context) {
            _context = context;
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
            string usernamesql = _context.NhanViens.Where (u => u.TenDangNhap == username).Select (u => u.TenDangNhap).FirstOrDefault ();
            string passwordsql = _context.NhanViens.Where (u => u.TenDangNhap == username).Select (u => u.MatKhau).FirstOrDefault ();
            string tennhanvien = _context.NhanViens.Where(u => u.TenDangNhap == username).Select(u => u.HoTen).FirstOrDefault();
            int role = _context.NhanViens.Where (u => u.TenDangNhap == username).Select (u => u.MaVaiTro).FirstOrDefault ();
            int maNhanVien = _context.NhanViens.Where(u => u.TenDangNhap == username).Select(u => u.MaNhanVien).FirstOrDefault();
           
            using (MD5 md5hash = MD5.Create ()) {
                if (VerifyMd5Hash (md5hash, password, passwordsql) && usernamesql == username) {
                    HttpContext.Session.SetString ("Username", username);
                    HttpContext.Session.SetString("TenNhanVien", tennhanvien);
                    HttpContext.Session.SetString ("Role",role.ToString());
                    HttpContext.Session.SetString("MaNhanVien", maNhanVien.ToString());
                    ViewBag.Password = Convert.ToString (GetMd5hash (md5hash, password));
                    return View ("../Home/Index");
                } else {

                    return View ();
                }
            }
        }
        public string GetMd5hash (MD5 md5hash, string input) {
            byte[] data = md5hash.ComputeHash (Encoding.UTF8.GetBytes (input));
            StringBuilder sb = new StringBuilder ();
            for (int i = 0; i < data.Length; i++) {
                sb.Append (data[i].ToString ("X2"));
            }
            return sb.ToString ();
        }
        public bool VerifyMd5Hash (MD5 md5hash, string input, string hash) {
            var hashOfInput = GetMd5hash (md5hash, input);
            if (String.Compare (hash, hashOfInput) == 0) {
                return true;
            }
            return false;
        }
        public IActionResult Logout () {
            HttpContext.Session.Remove ("Username");
            return View ("../Account/Index");
        }
    }
}