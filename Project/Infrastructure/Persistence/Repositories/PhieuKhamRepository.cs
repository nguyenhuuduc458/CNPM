using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class PhieuKhamRepository : Repository<PhieuKham>, IPhieuKhamRepository
    {
        public PhieuKhamRepository(QuanLyPhongMach context) : base(context)
        {
        }

        protected QuanLyPhongMach QuanLyPhongMach{
            get { return Context as QuanLyPhongMach; }
        }
    }
}