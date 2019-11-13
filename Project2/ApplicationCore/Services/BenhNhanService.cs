using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;

namespace ApplicationCore.Services{
    public class BenhNhanService : IBenhNhanService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        public BenhNhanService(IUnitOfWork unitOfWork,IMapper mapper){
            _unitOfwork = unitOfWork;
            _mapper = mapper;
        }
        public void Create(SaveBenhNhanDTO benhnhan)
        {
            var bn = _mapper.Map<SaveBenhNhanDTO, BenhNhan>(benhnhan);
            _unitOfwork.BenhNhans.Add(bn);
            _unitOfwork.Complete();
        }

        public void Delete(int id)
        {
            var benhnhan = _unitOfwork.BenhNhans.GetById(id);
            _unitOfwork.BenhNhans.Remove(benhnhan);
            _unitOfwork.Complete();
        }

        public void Edit(SaveBenhNhanDTO BenhNhan)
        {
            var bn = _unitOfwork.BenhNhans.GetById(BenhNhan.MaBenhNhan);
            if( bn != null){
                _mapper.Map<SaveBenhNhanDTO, BenhNhan>(BenhNhan, bn);
                _unitOfwork.Complete();
            }
        }

        public SaveBenhNhanDTO GetBenhNhan(int id)
        {
            var bn = _unitOfwork.BenhNhans.GetById(id);
            return _mapper.Map<BenhNhan, SaveBenhNhanDTO>(bn);
        }

        public IEnumerable<SaveBenhNhanDTO> GetBenhNhans(string sortOrder, string searchString)
        {
            Expression<Func<BenhNhan, bool>> predicate = m => true;
            //search
            if (!String.IsNullOrEmpty(searchString))
            {
                predicate = m => m.HoTen.ToLower().Contains(searchString.ToLower());
            }
            var benhNhan = _unitOfwork.BenhNhans.Find(predicate);
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
            return _mapper.Map<IEnumerable<BenhNhan>,IEnumerable<SaveBenhNhanDTO>>(benhNhan);
        }
    }
}