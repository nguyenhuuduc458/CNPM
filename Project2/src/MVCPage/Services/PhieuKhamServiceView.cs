using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Models;
using AutoMapper;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public class PhieuKhamServiceView : IPhieuKhamServiceView
    {
        private readonly IPhieuKhamService _service;
        private readonly INhanVienService _NVService;
        private readonly IBenhNhanService _BNService;
        private readonly IBenhService _BService;
        private IMapper _mapper;
        private int pageSize = 3;
        public PhieuKhamServiceView (IPhieuKhamService service, INhanVienService NVService,IBenhNhanService BNService,IBenhService BService,IMapper mapper){
            _service = service;
            _NVService = NVService;
            _BNService = BNService;
            _BService = BService;
            _mapper = mapper;
        }

        public PhieuKhamCreateVM GetPhieuKhamCreateVM(int MaBenhNhan, int MaNhanVien)
        {
            var bn = _BNService.GetBenhNhan(MaBenhNhan);
            var nv = _NVService.GetNhanVien(MaNhanVien);
            PhieuKhamCreateVM vm = new PhieuKhamCreateVM
            {
                PhieuKhams = new PhieuKhamEditMD
                {
                    MaBenhNhan = MaBenhNhan,
                    MaNhanVien = MaNhanVien,
                    TenBacSy = nv.HoTen,
                    TenBenhNhan = bn.HoTen,
                    NgayKham = _service.GetNgayKham()
                },

                listTenBenh = _service.GetLoaiBenh()
            };
            return vm;
        }

        public PhieuKhamIndexVM GetPhieuKhamIndexVM(string searchString, int pageIndex, int MaNhanVien)
        {
            var PKModel = _service.GetPhieuKhams(searchString, MaNhanVien);
            return new PhieuKhamIndexVM
            {
                PhieuKhams = PaginatedList<PhieuKhamMD>.Create(PKModel.OrderByDescending(m => m.NgayKham) , pageIndex, pageSize)
            };
        }
        public PhieuKhamEditVM GetViewEditPhieuKham(int id)
        {
            Expression<Func<Benh, bool>> predicate = m => true;

            var phieuKham = _service.GetPhieuKham(id);
            var nhanVien = _NVService.GetNhanVien(phieuKham.MaNhanVien);
            var benhNhan = _BNService.GetBenhNhan(phieuKham.MaBenhNhan);
            var TrieuChung = phieuKham.TrieuChung;

            predicate = m => !m.TenBenh.Equals(TrieuChung);

            var trieuChungKhac = _BService.GetTrieuChungKhac(predicate);
            return new PhieuKhamEditVM
            {
                PhieuKhamEdit = new PhieuKhamEditMD
                {
                    Id      = phieuKham.MaPhieuKham, 
                    TenBacSy = nhanVien.HoTen,
                    TenBenhNhan = benhNhan.HoTen,
                    MaBenhNhan = phieuKham.MaBenhNhan,
                    MaNhanVien = phieuKham.MaNhanVien,
                    TrieuChung = phieuKham.TrieuChung,
                    NgayKham = Convert.ToDateTime(phieuKham.NgayKham)
                },

                listBenh = trieuChungKhac
        };
        }
    }
}