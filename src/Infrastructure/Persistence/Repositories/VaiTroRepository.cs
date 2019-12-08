using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class VaiTroRepository : Repository<VaiTro>, IVaiTroRepository
    {
        public VaiTroRepository(QuanLyPhongMach context) : base(context)
        {
        }
        public QuanLyPhongMach QuanLyPhongMach{
            get { return Context as QuanLyPhongMach; }
        }
    }
}