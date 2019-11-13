using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IPhieuKhamRepository : IRepository<PhieuKham>
    {
        IEnumerable<PhieuKhamMD> GetTablePhieuKham(IEnumerable<PhieuKham> phieuKhams);
    }
}