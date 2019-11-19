using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories {
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot {
        protected DbContext Context { get; private set; }
        public Repository (DbContext context) {
            Context = context;
        }
        public void Add (T Entity) {
            Context.Set<T> ().Add (Entity);
        }

        public void AddRange (IEnumerable<T> Entities) {
            Context.Set<T> ().AddRange (Entities);
        }

        public IEnumerable<T> Find (Expression<Func<T, bool>> predicate) {
            return Context.Set<T> ().Where (predicate);
        }

        public IEnumerable<T> GetAll () {
            return Context.Set<T> ().ToList ();
        }

        public T GetById (int id) {
            return Context.Set<T> ().Find (id);
        }

        public void Remove (T Entity) {
            Context.Set<T> ().Remove (Entity);
        }

        public void RemoveRange (IEnumerable<T> Entities) {
            Context.Set<T> ().RemoveRange (Entities);
        }

        public void Update (T Entity) {
            Context.Set<T>().Update(Entity);
        }
    }
}