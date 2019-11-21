using System;
using System.Linq.Expressions;
namespace ApplicationCore.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        int PageIndex { get; }
        int PageSize { get; }
        bool IsPaginated{ get; }
    }
}