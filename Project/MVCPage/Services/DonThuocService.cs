using System.Runtime.InteropServices.ComTypes;
using System.Linq;
using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MVCPage.ViewModel;
using System.Collections.Generic;
using MVCPage.Models;
using MVCPage.Controllers;

namespace MVCPage.Services
{
    public class DonThuocService : IDonThuocService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DonThuocService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public DonThuocIndexVM GetDonThuocIndexVM(int? MaDonThuoc, string searchString, int pageIndex)
        {
            Expression<Func<DonThuoc, bool>> predicate = m => true;
            //search
            if (!String.IsNullOrEmpty(searchString))
            {
                predicate = m => m.MaDonThuoc == Convert.ToInt32(searchString);
            }
            var donThuoc = _unitOfWork.DonThuocs.Find(predicate);
            // chi tiet don thuoc
            Expression<Func<ChiTietDonThuoc, bool>> chitiet = ct => false;

            if (!String.IsNullOrEmpty(MaDonThuoc.ToString()))
            {
                chitiet = ct => ct.DonThuoc.MaDonThuoc == MaDonThuoc;
            }
            var chiTietDonThuoc = _unitOfWork.ChiTietDonThuocs.Find(chitiet);

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
            var listThuoc = _unitOfWork.Thuocs.GetAll();
            // thong tin don thoc
            Expression<Func<Thuoc, bool>> predicate = m => true;

            predicate = m => m.TenThuoc.ToLower().Equals(CreateDonThuocVM.thongTinDonThuoc.TenThuoc.ToLower());

            var thuoc = _unitOfWork.Thuocs.Find(predicate);
            var MaThuoc = thuoc.Select(m => m.MaThuoc).FirstOrDefault();
            double? DonGia = thuoc.Select(m => m.DonGia).FirstOrDefault();
            int SoLuongkeToa = CreateDonThuocVM.thongTinDonThuoc.SoLuong;
            double ThanhTien = (SoLuongkeToa * DonGia).Value;
            string TenThuoc = CreateDonThuocVM.thongTinDonThuoc.TenThuoc;
            string CachDung = CreateDonThuocVM.thongTinDonThuoc.CachDung;
            // format currency
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

            // CreateDonThuocVM.thongTinDonThuoc.ThanhTien = ThanhTien;
            // CreateDonThuocVM.listThongTinDonThuoc.Add(CreateDonThuocVM.thongTinDonThuoc);
            return new CreateDonThuocVM
            {
                thongtinthuoc = listThuoc,
                listThongTinDonThuoc = DonThuocController.listTam,
                TongTien = TinhTongTien(DonThuocController.listTam),
                MaPhieuKham = MaPhieuKham
            };
        }

        public double TinhTongTien(IEnumerable<ThongTinDonThuoc> ttdt)
        {
            double? tongtien = 0;
            foreach(var item in ttdt){
                tongtien += item.ThanhTien;
            }
            return tongtien.Value;
        }

        public IEnumerable<Thuoc> GetAllListThuoc(){
            return _unitOfWork.Thuocs.GetAll();
        }

        public void LapDonThuoc(IEnumerable<ThongTinDonThuoc> ttdt,int MaPhieuKham)
        {
            List<ChiTietDonThuoc> ctdt = new List<ChiTietDonThuoc>();
            DonThuoc dt = new DonThuoc
            {
                MaPhieuKham = MaPhieuKham,
                TongTien = TinhTongTien(ttdt)
            };
            
            _unitOfWork.DonThuocs.Add(dt);
            // them chi tiet don thuoc vao list tam 
            foreach (var item in ttdt)
            {
                ChiTietDonThuoc ct = new ChiTietDonThuoc
                {
                    MaThuoc = item.MaThuoc,
                    CachDung = item.CachDung,
                    SoLuong = item.SoLuong,
                    ThanhTien = item.ThanhTien,
                };
                ctdt.Add(ct);
            }
            // luu chi tiet vao csdl 
            foreach(var details in ctdt){
                details.DonThuoc = dt;
                _unitOfWork.ChiTietDonThuocs.Add(details);
            }
            _unitOfWork.Complete();
        }
    }
}