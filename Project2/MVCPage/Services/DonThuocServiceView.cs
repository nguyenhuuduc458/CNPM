using System.Runtime.InteropServices.ComTypes;
using System.Linq;
using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MVCPage.ViewModel;
using System.Collections.Generic;
using ApplicationCore.Models;
using MVCPage.Controllers;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MVCPage.Services
{
    public class DonThuocServiceView : IDonThuocServiceView
    {
        private readonly IDonThuocService _service;
        public DonThuocServiceView(IDonThuocService service)
        {
            _service = service;
        }
        public DonThuocIndexVM GetDonThuocIndexVM(int MaDonThuoc, string searchString, int pageIndex)
        {
            // don thuoc
            var donThuoc = _service.GetDonThuocs(searchString).ToList();
            // chi tiet don thuoc
            var chiTietDonThuoc = _service.GetChiTietDonThuocs(MaDonThuoc).ToList();
            //paging
            int pageSize = 3;
            return new DonThuocIndexVM
            {
                DonThuocs = PaginatedList<DonThuoc>.Create(donThuoc, pageIndex, pageSize),
                listChiTietDonThuoc = chiTietDonThuoc.ToList()
            };
        }

        public CreateDonThuocVM GetCreateDonThuocVM(CreateDonThuocVM CreateDonThuocVM, int MaPhieuKham)
        {
            // list danh sach thuoc
            var listThuoc = _service.GetAllListThuoc();
            // thong tin don thoc
            var thuoc = _service.GetThuocCondition(CreateDonThuocVM.thongTinDonThuoc.TenThuoc.ToLower());
            // new mot don thuoc
            var MaThuoc = thuoc.MaThuoc;
            double? DonGia = thuoc.DonGia;
            int SoLuongkeToa = CreateDonThuocVM.thongTinDonThuoc.SoLuong;
            double ThanhTien = (SoLuongkeToa * DonGia).Value;
            string TenThuoc = CreateDonThuocVM.thongTinDonThuoc.TenThuoc;
            string CachDung = CreateDonThuocVM.thongTinDonThuoc.CachDung;
            ThongTinDonThuoc thongTinDonThuoc = new ThongTinDonThuoc
            {
                MaThuoc = MaThuoc,
                TenThuoc = TenThuoc,
                SoLuong = SoLuongkeToa,
                CachDung = CachDung,
                ThanhTien = ThanhTien
            };
            if (DonThuocController.listTam == null)
            {
                DonThuocController.listTam = new List<ThongTinDonThuoc>();
            }
            DonThuocController.listTam.Add(thongTinDonThuoc);
            return new CreateDonThuocVM
            {
                thongtinthuoc = listThuoc,
                listThongTinDonThuoc = DonThuocController.listTam,
                TongTien = _service.TinhTongTien(DonThuocController.listTam),
                MaPhieuKham = MaPhieuKham
            };
        }
        public IEnumerable<Thuoc> GetAllListThuoc()
        {
            return _service.GetAllListThuoc();
        }

        public void LapDonThuoc(IEnumerable<ThongTinDonThuoc> ttdt, int MaPhieuKham)
        {
            _service.LapDonThuoc(ttdt, MaPhieuKham);
            _service.CapNhatTrangThaiPhieuKham(MaPhieuKham);
        }


    }
}