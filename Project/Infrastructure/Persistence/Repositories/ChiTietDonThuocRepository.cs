using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ChiTietDonThuocRepository : Repository<ChiTietDonThuoc>, IChiTietDonThuocRepository
    {
        public ChiTietDonThuocRepository(QuanLyPhongMach context) : base(context)
        {
        }
        public QuanLyPhongMach QuanLyPhongMach{
            get { return Context as QuanLyPhongMach; }
        }
    }
}