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
using MVCPage.Models;

namespace MVCPage.Controllers {
    public class DonThuocController : Controller{
        public static List<ThongTinDonThuoc> listTam = null;

        private readonly IDonThuocService _service;
        public DonThuocController (IDonThuocService service){
            _service = service;
        }
        public IActionResult Index(int? MaDonThuoc,string CurrentFilter,int pageIndex = 1){
            @ViewData["CurrentFilter"] = CurrentFilter;
            DonThuocIndexVM vm = _service.GetDonThuocIndexVM(MaDonThuoc,CurrentFilter, pageIndex);
            return View(vm);

        }
        [HttpGet]
        public IActionResult Create(int MaPhieuKham){
            CreateDonThuocVM vm = new CreateDonThuocVM
            {
                listThongTinDonThuoc = new List<ThongTinDonThuoc>(),
                thongtinthuoc = _service.GetAllListThuoc(),
                MaPhieuKham = MaPhieuKham
            };
            if(listTam != null){
                listTam.Clear();
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(CreateDonThuocVM CreateDonThuocVM,int MaPhieuKham){    
            CreateDonThuocVM vm = _service.GetCreateDonThuocVM(CreateDonThuocVM,MaPhieuKham);
            return View(vm);
        }
        [HttpPost]
        public IActionResult LapDonThuoc(int MaPhieuKham){
            _service.LapDonThuoc(listTam,MaPhieuKham);
            return RedirectToAction("Index");
        }

    }
}