using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MVCPage.ViewModel;

namespace MVCPage.Services {
    public class NhanVienService : INhanVienService {
        private readonly IUnitOfWork _unitOfWork;
        public NhanVienService (IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public void Create (NhanVien nhanVien) {
            _unitOfWork.NhanViens.Add (nhanVien);
            _unitOfWork.Complete ();
        }

        public void Delete (int id) {
            var NhanVien = _unitOfWork.NhanViens.GetById (id);
            if (NhanVien != null) {
                _unitOfWork.NhanViens.Remove (NhanVien);
                _unitOfWork.Complete ();
            }
        }

        public void Edit (NhanVien nhanVien) {
            _unitOfWork.NhanViens.Update (nhanVien);
            _unitOfWork.Complete ();
        }

        public NhanVienIndexVM GetNhanVienIndexVM (string sortOrder, string searchString, int pageIndex) {

            Expression<Func<NhanVien, bool>> predicate = m => true;
            //search
            if (!String.IsNullOrEmpty (searchString)) {
                predicate = m => m.HoTen.ToLower ().Contains (searchString.ToLower ());
            }
            var NhanVien = _unitOfWork.NhanViens.Find (predicate);
            //sort 
            switch (sortOrder) {
                case "name_desc":
                    NhanVien = NhanVien.OrderByDescending (m => m.HoTen);
                    break;
                case "Date":
                    NhanVien = NhanVien.OrderBy (m => m.NgaySinh);
                    break;
                case "Date_desc":
                    NhanVien = NhanVien.OrderByDescending (m => m.NgaySinh);
                    break;
                default:
                    NhanVien = NhanVien.OrderBy (m => m.DiaChi);
                    break;
            }
            //paging
            int pageSize = 3;
            return new NhanVienIndexVM {
                NhanViens = PaginatedList<NhanVien>.Create (NhanVien, pageIndex, pageSize)
            };
        }

        public IEnumerable<string> GetVaiTro () {
            return _unitOfWork.NhanViens.GetVaiTro ();
        }

    }
}