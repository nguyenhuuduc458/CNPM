using System;
using System.Linq.Expressions;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public Specification(Expression<Func<T,bool>> criteria){
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public bool IsPaginated { get; private set; }

        protected void ApplyPaging(int pageIndex, int pageSize){
            PageIndex = pageIndex;
            PageSize = pageSize;
            IsPaginated = true;
        }

    }
}