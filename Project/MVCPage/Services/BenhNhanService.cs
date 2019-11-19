using System;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MVCPage.ViewModel;

namespace MVCPage.Services {
    public class BenhNhanService : IBenhNhanService {
        private readonly IUnitOfWork _unitOfWork;
        public BenhNhanService (IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public void Create (BenhNhan benhNhan) {
            _unitOfWork.BenhNhans.Add (benhNhan);
            _unitOfWork.Complete ();
        }

        public void Delete (int id) {
            var benhNhan = _unitOfWork.BenhNhans.GetById (id);
            if (benhNhan != null) {
                _unitOfWork.BenhNhans.Remove (benhNhan);
                _unitOfWork.Complete ();
            }
        }

        public void Edit (BenhNhan benhNhan) {
            _unitOfWork.BenhNhans.Update (benhNhan);
            _unitOfWork.Complete ();
        }

        public BenhNhanIndexVM GetBenhNhanIndexVM (string sortOrder, string searchString, int pageIndex) {
            Expression<Func<BenhNhan, bool>> predicate = m => true;
            //search
            if (!String.IsNullOrEmpty(searchString))
            {
                predicate = m => m.HoTen.ToLower().Contains(searchString.ToLower());
            }
            var benhNhan = _unitOfWork.BenhNhans.Find(predicate);
            //sort 
            switch (sortOrder)
            {
                case "name_desc":
                    benhNhan = benhNhan.OrderByDescending(m => m.HoTen);
                    break;
                case "Date":
                    benhNhan = benhNhan.OrderBy(m => m.NgaySinh);
                    break;
                case "Date_desc":
                    benhNhan = benhNhan.OrderByDescending(m => m.NgaySinh);
                    break;
                default:
                    benhNhan = benhNhan.OrderBy(m => m.DiaChi);
                    break;
            }
            //paging
            int pageSize = 3;
            return new BenhNhanIndexVM
            {
                BenhNhans = PaginatedList<BenhNhan>.Create(benhNhan, pageIndex, pageSize)
            };
        }
    }
}