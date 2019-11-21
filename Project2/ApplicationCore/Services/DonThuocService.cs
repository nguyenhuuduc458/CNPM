using System.Linq;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public class DonThuocService : IDonThuocService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DonThuocService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CapNhatTrangThaiPhieuKham(int MaPhieuKham)
        {
            _unitOfWork.DonThuocs.CapNhatTrangThaiPhieuKham(MaPhieuKham);
        }

        public void CreateCTDT(ChiTietDonThuoc ctdt)
        {
            _unitOfWork.ChiTietDonThuocs.Add(ctdt);
            _unitOfWork.Complete();
        }

        public void CreateDT(DonThuoc dt)
        {
            _unitOfWork.DonThuocs.Add(dt);
            _unitOfWork.Complete();
        }

        public IEnumerable<Thuoc> GetAllListThuoc()
        {
            var thuoc = _unitOfWork.Thuocs.GetAll();
            return thuoc;
        }

        public IEnumerable<ChiTietDonThuoc> GetChiTietDonThuocs(int MaDonThuoc)
        {
            Expression<Func<ChiTietDonThuoc, bool>> chitiet = ct => false;

            if (!String.IsNullOrEmpty(MaDonThuoc.ToString()))
            {
                chitiet = ct => ct.MaDonThuoc == MaDonThuoc;
            }
            var chiTietDonThuoc = _unitOfWork.ChiTietDonThuocs.Find(chitiet);
            return chiTietDonThuoc;

        }

        public IEnumerable<DonThuoc> GetDonThuocs(string searchString)
        {
            Expression<Func<DonThuoc, bool>> predicate = m => true;
            //search
            if (!String.IsNullOrEmpty(searchString))
            {
                predicate = m => m.MaDonThuoc == Convert.ToInt32(searchString);
            }
            var donThuoc = _unitOfWork.DonThuocs.Find(predicate);
            return donThuoc;
        }

        public Thuoc GetThuocCondition(string TenThuoc)
        {
            Expression<Func<Thuoc, bool>> predicate = m => true;

            predicate = m => m.TenThuoc.ToLower().Equals(TenThuoc.ToLower());

            var thuoc = _unitOfWork.Thuocs.Find(predicate).FirstOrDefault();
            return thuoc;
        }

        public void LapDonThuoc(IEnumerable<ThongTinDonThuoc> ttdt, int MaPhieuKham)
        {
            List<ChiTietDonThuoc> ctdt = new List<ChiTietDonThuoc>();
            DonThuoc dt = new DonThuoc
            {
                MaPhieuKham = MaPhieuKham,
                TongTien = TinhTongTien(ttdt)
            };
            _unitOfWork.DonThuocs.Add(dt);
            _unitOfWork.Complete();
            int MaDonThuoc = _unitOfWork.DonThuocs.GetMaDonThuoc(MaPhieuKham);
            foreach (var item in ttdt)
            {
                ChiTietDonThuoc ct = new ChiTietDonThuoc
                {
                    MaThuoc = item.MaThuoc,
                    CachDung = item.CachDung,
                    SoLuong = item.SoLuong,
                    ThanhTien = item.ThanhTien,
                    MaDonThuoc = MaDonThuoc
                };
                _unitOfWork.Thuocs.CapNhapSoLuongThuoc(item.MaThuoc,item.SoLuong);
                ctdt.Add(ct);
            }
             _unitOfWork.ChiTietDonThuocs.AddRange(ctdt);
            _unitOfWork.Complete();
        }

        public double TinhTongTien(IEnumerable<ThongTinDonThuoc> ttdt)
        {
            double? tongtien = 0;
            if(ttdt!=null){
                foreach (var item in ttdt)
                {
                    tongtien += item.ThanhTien;
                }
            }
            return tongtien.Value;
        }
    }
}