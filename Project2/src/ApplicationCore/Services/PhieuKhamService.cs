using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using ApplicationCore.Entities;
using System.Linq.Expressions;
using ApplicationCore.Models;
using System.Linq;

namespace ApplicationCore.Services
{
    public class PhieuKhamService : IPhieuKhamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PhieuKhamService(IUnitOfWork unitOfWork,IMapper mapper){
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public void Create(SavePhieuKhamDTO phieuKham)
        {
          var pk = _mapper.Map<SavePhieuKhamDTO, PhieuKham>(phieuKham);
            _unitOfWork.PhieuKhams.Add(pk);
            _unitOfWork.Complete();
        }

        public void Edit(SavePhieuKhamDTO phieuKham)
        {
            var pk = _unitOfWork.PhieuKhams.GetById(phieuKham.MaPhieuKham);
            if( pk != null){
                _mapper.Map<SavePhieuKhamDTO, PhieuKham>(phieuKham, pk);
                _unitOfWork.Complete();
            }
        }

        public IEnumerable<Benh> GetLoaiBenh()
        {
            var benh = _unitOfWork.Benhs.GetAll();
            return benh.ToList();
        }

        public DateTime GetNgayKham()
        {
            DateTime time  = DateTime.Now;
            return time;
        }

        public SavePhieuKhamDTO GetPhieuKham(int id)
        {
            var phieuKham = _unitOfWork.PhieuKhams.GetById(id);
            return _mapper.Map<PhieuKham, SavePhieuKhamDTO>(phieuKham);
        }

        public IEnumerable<PhieuKhamMD> GetPhieuKhams(string searchString, int MaNhanVien)
        {
            Expression<Func<BenhNhan, bool>> predicate = b => true;
           
            if(!String.IsNullOrEmpty(searchString)){
                predicate = b => b.HoTen.ToLower().Contains(searchString.ToLower());
            }
            var benhnhan = _unitOfWork.BenhNhans.Find(predicate);
            var tblPhieuKham = _unitOfWork.PhieuKhams.GetTablePhieuKham(benhnhan,MaNhanVien);
            return tblPhieuKham.ToList();
        }
    }
}