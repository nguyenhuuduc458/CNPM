using System;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Models;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public class BaoCaoServiceView : IBaoCaoServiceView
    {
        private IBaoCaoService _service;
        private int pageSize = 3;
        public BaoCaoServiceView(IBaoCaoService service){
            _service = service;
        }
        public BaoCaoVM GetIndexBaoCaoVM(int startDate, int endDate, int year, int pageIndex){
            int startMonth = startDate;
            int endMonth = endDate;
            var baoCaoView = _service.SoLuongThuocDaBan(startDate, endDate,year);
            var baoCaoDoanhThu = _service.DoanhThu(startDate, endDate, year);
            return new BaoCaoVM
            {
                BaoCaos = PaginatedList<BaoCao>.Create(baoCaoView, pageIndex, pageSize),
                BaoCaoDoanhThus = PaginatedList<BaoCaoDoanhThuMD>.Create(baoCaoDoanhThu, pageIndex, pageSize)
            };
        }
    }
}