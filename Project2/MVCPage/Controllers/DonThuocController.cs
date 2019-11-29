using System.Net;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCPage.Services;
using MVCPage.ViewModel;
using ApplicationCore.Models;
using ApplicationCore.Interfaces.IServices;

namespace MVCPage.Controllers
{
    public class DonThuocController : Controller
    {
        public static List<ThongTinDonThuoc> listTam = null;
        public static int MaPK = 0;
        private readonly IDonThuocServiceView _serviceView;
        private readonly IDonThuocService _service;
        public DonThuocController(IDonThuocServiceView serviceView, IDonThuocService service)
        {
            _serviceView = serviceView;
            _service = service;
        }
        public IActionResult Index(int MaDonThuoc, string CurrentFilter, int pageIndex = 1)
        {
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {
                @ViewData["CurrentFilter"] = CurrentFilter;
                DonThuocIndexVM vm = _serviceView.GetDonThuocIndexVM(MaDonThuoc, CurrentFilter, pageIndex);
                return View(vm);
            }else{
                return RedirectToAction("Index", "Account");
            }
        }
        [HttpGet]
        public IActionResult Create(int MaPhieuKham, int? flag)
        {
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {
                
                if(flag != null){
                    MaPK = 0;
                }
                if(MaPK == 0){
                    if (listTam != null)
                    {
                        listTam.Clear();
                    }
                    CreateDonThuocVM vm = new CreateDonThuocVM
                    {
                        thongtinthuoc = _service.GetAllListThuoc(),
                        MaPhieuKham = MaPhieuKham,
                        listThongTinDonThuoc = new List<ThongTinDonThuoc>()
                    };
                    return View(vm);
                }else if(MaPK!=0){
                    CreateDonThuocVM vm = new CreateDonThuocVM
                    {
                        thongtinthuoc = _service.GetAllListThuoc(),
                        MaPhieuKham = MaPK,
                        listThongTinDonThuoc = listTam,
                        TongTien = _service.TinhTongTien(listTam)
                    };
                    return View(vm);
                }
                return null;
            }else{
                return RedirectToAction("Index", "Account");
            }
        }
        [HttpPost]
        public IActionResult Create(CreateDonThuocVM CreateDonThuocVM, int MaPhieuKham)
        {
            string role = HttpContext.Session.GetString("Role");
            if(listTam == null){
                listTam = new List<ThongTinDonThuoc>();
            }
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {        
                if(!_serviceView.KiemTraThuocExist(CreateDonThuocVM.thongTinDonThuoc.TenThuoc)){
                    ViewData["TenThuocSai"] = "Tên thuốc không hợp lệ";
                    CreateDonThuocVM vm = new CreateDonThuocVM
                    {
                        thongtinthuoc = _service.GetAllListThuoc(),
                        MaPhieuKham = MaPhieuKham,
                        listThongTinDonThuoc = listTam,
                        TongTien = _service.TinhTongTien(listTam)
                    };
                    MaPK = MaPhieuKham;
                    return View(vm);
                }else if (!_serviceView.KiemTraSoLuongTonKho(CreateDonThuocVM.thongTinDonThuoc.TenThuoc, CreateDonThuocVM.thongTinDonThuoc.SoLuong))
                {
                        ViewData["HetThuoc"] = "Số lượng thuốc không đủ ";
                        CreateDonThuocVM vm = new CreateDonThuocVM
                        {
                            thongtinthuoc = _service.GetAllListThuoc(),
                            MaPhieuKham = MaPhieuKham,
                            listThongTinDonThuoc = listTam,
                            TongTien = _service.TinhTongTien(listTam)
                        };
                    MaPK = MaPhieuKham;
                    return View(vm);   
                }else
                {
                    CreateDonThuocVM vm = _serviceView.GetCreateDonThuocVM(CreateDonThuocVM, MaPhieuKham);
                    MaPK = MaPhieuKham;
                    return View(vm);
                }
            }else{
                return RedirectToAction("Index", "Account");
            }
           
        }
        [HttpPost]
        public IActionResult LapDonThuoc(int MaPhieuKham)
        {
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            { 
                if(listTam == null){
                    return RedirectToAction("Create","DonThuoc");
                }else{
                    _service.LapDonThuoc(listTam, MaPhieuKham);
                    _service.CapNhatTrangThaiPhieuKham(MaPhieuKham);
                    MaPK = 0;
                    return RedirectToAction("Index");
                }       
            }else{
                return RedirectToAction("Index", "Account");
            }
            
        }
        [HttpGet]
        public IActionResult Details(int MaDonThuoc){
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {
                var ctdt = _service.GetChiTietDonThuocs(MaDonThuoc);
                @ViewData["MaDonThuoc"] = MaDonThuoc;
                return View(ctdt);
            }else{
                return RedirectToAction("Index", "Account");
            }
           
        }
        [HttpGet]
        public IActionResult Remove(int MaPhieuKham,int id){
            string role = HttpContext.Session.GetString("Role");
            if (HttpContext.Session.GetString("Username") != null && (role.Equals("2") || role.Equals("3")))
            {
                if(listTam.Count == 1){
                    MaPK = 0;
                }else{
                    MaPK = MaPhieuKham;
                }
                listTam.RemoveAt(id);
                return RedirectToAction("Create","DonThuoc");
            }else{
                return RedirectToAction("Index", "Account");
            }
           
        }
    }
}