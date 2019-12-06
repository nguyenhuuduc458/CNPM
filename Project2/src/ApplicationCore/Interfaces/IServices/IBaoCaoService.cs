using System;
using System.Collections.Generic;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.IServices {
    public interface IBaoCaoService {
        IEnumerable<BaoCao> SoLuongThuocDaBan (int startMonth, int endMonth, int year);
        IEnumerable<BaoCaoDoanhThuMD> DoanhThu (int startMonth, int endMonth, int year);
    }
}