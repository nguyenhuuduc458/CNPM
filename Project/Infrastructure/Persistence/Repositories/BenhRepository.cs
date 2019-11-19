using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class BenhRepository : Repository<Benh>, IBenhRepository
    {
        public BenhRepository(QuanLyPhongMach context) : base(context)
        {
        }

      
        public QuanLyPhongMach QuanLyPhongMach{
            get { return Context as QuanLyPhongMach; }
        }
    }
}