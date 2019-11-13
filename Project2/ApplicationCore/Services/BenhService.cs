using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;

namespace ApplicationCore.Services
{
    public class BenhService : IBenhService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BenhService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Benh> GetTrieuChungKhac(Expression<Func<Benh, bool>> predicate)
        {
            return _unitOfWork.Benhs.Find(predicate);
        }
    }
}