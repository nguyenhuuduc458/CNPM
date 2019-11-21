using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class BenhService : IBenhService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public BenhService(IUnitOfWork unitOfWork, IMapper mapper){
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<Benh> GetTrieuChungKhac(Expression<Func<Benh, bool>> predicate)
        {
            return _unitOfWork.Benhs.Find(predicate);
        }
        public SaveBenhDTO GetBenh(int id){
            var benh = _unitOfWork.Benhs.GetById(id);
            return _mapper.Map<Benh, SaveBenhDTO>(benh);
        }

        public void Create(SaveBenhDTO benh)
        {
            var Benh = _mapper.Map<SaveBenhDTO, Benh>(benh);
            _unitOfWork.Benhs.Add(Benh);
            _unitOfWork.Complete();
        }

        public void Edit(SaveBenhDTO benh)
        {
            var Benh = _unitOfWork.Benhs.GetById(benh.MaBenh);
            if(Benh != null){
                _unitOfWork.Benhs.Update(Benh);
                _unitOfWork.Complete();
            }
        }

        public IEnumerable<SaveBenhDTO> GetBenhs(string searchString,string sortOrder, int pageIndex, int pageSize, out int count)
        {
            BenhSpecification benhFilterPaging = new BenhSpecification(searchString, pageIndex, pageSize);
            BenhSpecification benhFilter = new BenhSpecification(searchString);

            var benh = _unitOfWork.Benhs.FindSpec(benhFilterPaging);
            count = _unitOfWork.Benhs.Count(benhFilter);
            
            switch (sortOrder)
            {
                case "ten_desc":
                    benh = benh.OrderByDescending(m => m.TenBenh);
                    break;
                default:
                    benh = benh.OrderBy(m => m.MaBenh);
                    break;
            }
            return _mapper.Map<IEnumerable<Benh>, IEnumerable<SaveBenhDTO>>(benh);
        }
    }
}