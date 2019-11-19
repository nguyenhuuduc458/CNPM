using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public class BenhService : IBenhService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public BenhService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }
        public void Create(Benh benh)
        {
            _unitOfWork.Benhs.Add(benh);
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            var benh = _unitOfWork.Benhs.GetById(id);
            if(benh !=null){
                _unitOfWork.Benhs.Remove(benh);
                _unitOfWork.Complete();
            }
        }
        public void Edit(Benh benh)
        {
            _unitOfWork.Benhs.Update(benh);
        }

        public BenhIndexVM GetBenhIndexVM(string sortOrder, string searchString, int pageIndex)
        {
             Expression<Func<Benh, bool>> predicate = m => true;
            //search
            if (!String.IsNullOrEmpty (searchString)) {
                predicate = m => m.TenBenh.ToLower ().Contains (searchString.ToLower ());
            }
            var benh = _unitOfWork.Benhs.Find (predicate);
            //sort 
            switch (sortOrder) {
                case "Ma_desc":
                    benh = benh.OrderBy(m => m.MaBenh);
                    break;
                default:
                    benh = benh.OrderByDescending (m => m.TenBenh);
                    break;
            }
            //paging
            int pageSize = 3;
            return new BenhIndexVM {
                Benhs = PaginatedList<Benh>.Create (benh, pageIndex, pageSize)
            };
        }

    }
}