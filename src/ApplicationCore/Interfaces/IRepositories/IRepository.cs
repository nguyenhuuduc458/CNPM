using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Interfaces.IRepositories
 {
    public interface IRepository<T> where T : IAggregateRoot {
        T GetById (int id);
        IEnumerable<T> GetAll ();
        IEnumerable<T> Find (Expression<Func<T, bool>> predicate);
        // find using specification
        IEnumerable<T> FindSpec(ISpecification<T> spec);
        int Count(ISpecification<T> spec);
        void Add (T Entity);
        void AddRange (IEnumerable<T> Entities);
        void Remove (T Entity);
        void RemoveRange (IEnumerable<T> Entities);
        void Update (T Entity);

    }
}