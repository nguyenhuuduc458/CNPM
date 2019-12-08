using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IBenhService
    {
        IEnumerable<Benh> GetTrieuChungKhac(Expression<Func<Benh, bool>> predicate);
        void Create(SaveBenhDTO benh);
        void Edit(SaveBenhDTO benh);
        SaveBenhDTO GetBenh(int id);
        IEnumerable<SaveBenhDTO> GetBenhs(string searchString,string sortOrder, int pageIndex, int pageSize, out int count);
    }
}