using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ThuocRepository : Repository<Thuoc>, IThuocRepository
    {
        public ThuocRepository(QuanLyPhongMach context) : base(context)
        {
        }


        public QuanLyPhongMach QuanLyPhongMach
        {
            get { return Context as QuanLyPhongMach; }
        }
    }
}