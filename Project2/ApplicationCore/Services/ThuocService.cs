using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services {
    public class ThuocService : IThuocService{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ThuocService (IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Create (SaveThuocDTO thuoc) {
            var Thuoc = _mapper.Map<SaveThuocDTO, Thuoc> (thuoc);
            _unitOfWork.Thuocs.Add (Thuoc);
            _unitOfWork.Complete();
        }

        public void Delete (int id) {
            var thuoc = _unitOfWork.Thuocs.GetById (id);
            if (thuoc != null) {
                _unitOfWork.Thuocs.Remove (thuoc);
                _unitOfWork.Complete ();
            }
        }

        public void Edit (SaveThuocDTO thuoc) {
            var Thuoc = _unitOfWork.Thuocs.GetById (thuoc.MaThuoc);
            if (thuoc == null) return;
            _mapper.Map<SaveThuocDTO, Thuoc> (thuoc, Thuoc);
            _unitOfWork.Complete ();
        }

        public ThuocDTO GetThuoc (int id) {
            var thuoc = _unitOfWork.Thuocs.GetById (id);
            return _mapper.Map<Thuoc, ThuocDTO> (thuoc);
        }

        public IEnumerable<ThuocDTO> GetThuocs(string searchString,int pageIndex, int pageSize, out int count){
            
            ThuocSpecification thuocFilterPaging = new ThuocSpecification(searchString, pageIndex, pageSize);
            ThuocSpecification thuocFilter = new ThuocSpecification(searchString);
            
            var thuoc = _unitOfWork.Thuocs.FindSpec(thuocFilterPaging);      
            count = _unitOfWork.Thuocs.Count(thuocFilter);

            return _mapper.Map<IEnumerable<Thuoc>, IEnumerable<ThuocDTO>>(thuoc);
        }

    }
}