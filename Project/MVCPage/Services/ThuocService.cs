using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public class ThuocService : IThuocService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ThuocService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }

        public void Create(Thuoc thuoc)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Thuoc thuoc)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Thuoc thuoc)
        {
            throw new System.NotImplementedException();
        }

        public ThuocIndexVM GetThuocIndexVM(string searchString, int pageIndex)
        {
            Expression<Func<Thuoc, bool>> predicate = m => true;
            //search
            if (!String.IsNullOrEmpty(searchString))
            {
                predicate = m => m.TenThuoc.ToLower().Contains(searchString.ToLower());
            }
            var Thuoc = _unitOfWork.Thuocs.Find(predicate);
            int pageSize = 3;
            return new ThuocIndexVM
            {
                Thuocs = PaginatedList<Thuoc>.Create(Thuoc, pageIndex, pageSize)
            };
        }
    }
}