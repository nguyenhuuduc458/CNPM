using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public class BaoCaoService : IBaoCaoService
    {
        private IUnitOfWork _unitOfWork;
        public BaoCaoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BaoCaoDoanhThuMD> DoanhThu(int startMonth, int endMonth, int year)
        {
            IEnumerable<BaoCaoDoanhThuMD> DoanhThu = _unitOfWork.PhieuKhams.BCDoanhThu(startMonth, endMonth, year);
            return DoanhThu;
        }

        public IEnumerable<BaoCao> SoLuongThuocDaBan(int startMonth, int endMonth, int year)
        {
            IEnumerable<BaoCao> bcThuoc = _unitOfWork.Thuocs.BCThuoc(startMonth, endMonth, year);
            return bcThuoc;
        }
        

    }
}