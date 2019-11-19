using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Interfaces {
    public interface IRepository<T> where T : IAggregateRoot {
        T GetById (int id);
        IEnumerable<T> GetAll ();
        IEnumerable<T> Find (Expression<Func<T, bool>> predicate);
        void Add (T Entity);
        void AddRange (IEnumerable<T> Entities);
        void Remove (T Entity);
        void RemoveRange (IEnumerable<T> Entities);
        void Update (T Entity);

    }
}