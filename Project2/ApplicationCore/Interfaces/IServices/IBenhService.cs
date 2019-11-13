using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IBenhService
    {
        IEnumerable<Benh> GetTrieuChungKhac(Expression<Func<Benh, bool>> predicate);
    }
}