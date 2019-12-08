using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class BenhNhanRepository : Repository<BenhNhan>, IBenhNhanRepository
    {
        public BenhNhanRepository(QuanLyPhongMach context) : base(context)
        {

        }
        protected QuanLyPhongMach context{
            get { return Context as QuanLyPhongMach; }
        }
    }
}