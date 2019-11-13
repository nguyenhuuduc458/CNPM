using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IBenhNhanRepository
    {
        BenhNhan GetById(int id);
        IEnumerable<BenhNhan> GetAll();
        IEnumerable<BenhNhan> Find(Expression<Func<BenhNhan, bool>> predicate);
        void Add(BenhNhan Entity);
        void AddRange(IEnumerable<BenhNhan> Entities);
        void Remove(BenhNhan Entity);
        void RemoveRange(IEnumerable<BenhNhan> Entities);
        void Update(BenhNhan Entity);
    }
}