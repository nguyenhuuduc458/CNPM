using System.Linq;
using ApplicationCore.Interfaces;

namespace Infrastructure.Persistence
{
    public class SpecificationEvaluator<T>
    {
        public static IQueryable<T> GetQuery(IQueryable<T> query,ISpecification<T> spec){
            // modify the IQueryable using the specification's criteria expression
            if(spec.Criteria!=null){
                query = query.Where(spec.Criteria);
            }
            
            // apply paging if ispagined = true;
            if(spec.IsPaginated){
                query = query
                       .Skip((spec.PageIndex - 1) * spec.PageSize)
                       .Take(spec.PageSize);
            }
            return query;
        }
    }
}