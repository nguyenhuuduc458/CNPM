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
        
        private readonly IDonThuocServiceView _serviceView;
        private readonly IDonThuocService _service;
        public DonThuocController(IDonThuocServiceView serviceView, IDonThuocService service)
        {
            _serviceView = serviceView;
            _service = service;
        }
        public IActionResult Index(int MaDonThuoc, string CurrentFilter, int pageIndex = 1)
        {
            @ViewData["CurrentFilter"] = CurrentFilter;
            DonThuocIndexVM vm = _serviceView.GetDonThuocIndexVM(MaDonThuoc, CurrentFilter, pageIndex);
            return View(vm);

        }
        [HttpGet]
        public IActionResult Create(int MaPhieuKham)
        {
            CreateDonThuocVM vm = new CreateDonThuocVM
            {
                thongtinthuoc = _service.GetAllListThuoc(),
                MaPhieuKham = MaPhieuKham,
                listThongTinDonThuoc = new List<ThongTinDonThuoc>()
            };
            if (listTam != null)
            {
                listTam.Clear();
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(CreateDonThuocVM CreateDonThuocVM, int MaPhieuKham)
        {
            CreateDonThuocVM vm = _serviceView.GetCreateDonThuocVM(CreateDonThuocVM, MaPhieuKham);
            return View(vm);
        }
        [HttpPost]
        public IActionResult LapDonThuoc(int MaPhieuKham)
        {
            _service.LapDonThuoc(listTam, MaPhieuKham);
            _service.CapNhatTrangThaiPhieuKham(MaPhieuKham);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int MaDonThuoc){
            var ctdt = _service.GetChiTietDonThuocs(MaDonThuoc);
            @ViewData["MaDonThuoc"] = MaDonThuoc;
            return View(ctdt);
        }
    }
}