using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MVCPage.Models;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public class PhieuKhamService : IPhieuKhamService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhieuKhamService (IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }
        public void Create(PhieuKham phieuKham)
        {
            _unitOfWork.PhieuKhams.Add(phieuKham);
            _unitOfWork.Complete();
        }
        
        public void Edit(PhieuKham phieuKham)
        {
            _unitOfWork.PhieuKhams.Update(phieuKham);
            _unitOfWork.Complete();
        }

        public PhieuKhamIndexVM GetPhieuKhamIndexVM(string sortOrder, string searchString, int pageIndex)
        {
            Expression<Func<PhieuKham, bool>> predicate = m => true;
            //search
            if (!String.IsNullOrEmpty(searchString))
            {
                predicate = m => m.TrieuChung.ToLower().Contains(searchString.ToLower());
            }
            var phieuKham = _unitOfWork.PhieuKhams.Find(predicate);
            var nhanVien = _unitOfWork.NhanViens.GetAll();
            var benhNhan = _unitOfWork.BenhNhans.GetAll();
            //sort 
            // switch (sortOrder)
            // {
            //     case "nameBN_desc":
            //         phieuKham = phieuKham.
            //         break;
            //     case "Date":
            //         phieuKham = phieuKham.OrderBy(m => m.NgaySinh);
            //         break;
            //     case "Date_desc":
            //         phieuKham = phieuKham.OrderByDescending(m => m.NgaySinh);
            //         break;
            //     default:
            //         phieuKham = phieuKham.OrderBy(m => m.DiaChi);
            //         break;
            // }
            //paging
            int pageSize = 3;
            var tblPhieuKham = from pk in phieuKham
                                join nv in nhanVien
                                on pk.MaNhanVien equals nv.MaNhanVien
                                join bn in benhNhan
                                on pk.MaBenhNhan equals bn.MaBenhNhan
                                select new PhieuKhamMD
                                {
                                    Id = pk.MaPhieuKham,
                                    TenBacSy = nv.HoTen,
                                    TenBenhNhan = bn.HoTen,
                                    ChuanDoan = pk.TrieuChung,
                                    NgayKham = Convert.ToDateTime(pk.NgayKham)
                                };
            return new PhieuKhamIndexVM
            {
                PhieuKhams = PaginatedList<PhieuKhamMD>.Create(tblPhieuKham.OrderByDescending(m => m.NgayKham) , pageIndex, pageSize)
            };
        }

        public DateTime GetNgayKham()
        {
            DateTime NgayKham = DateTime.Now;
            return NgayKham;
        }

        public IEnumerable<Benh> GetLoaiBenh()
        {
            return _unitOfWork.Benhs.GetAll();
        }
        public PhieuKhamEditVM GetViewEditPhieuKham(int id)
        {
            Expression<Func<Benh, bool>> predicate = m => true;

            var phieuKham = _unitOfWork.PhieuKhams.GetById(id);
            var nhanVien = _unitOfWork.NhanViens.GetById(phieuKham.MaNhanVien);
            var benhNhan = _unitOfWork.BenhNhans.GetById(phieuKham.MaBenhNhan);
            var TrieuChung = phieuKham.TrieuChung;

            predicate = m => !m.TenBenh.Equals(TrieuChung);

            var trieuChungKhac = _unitOfWork.Benhs.Find(predicate);
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