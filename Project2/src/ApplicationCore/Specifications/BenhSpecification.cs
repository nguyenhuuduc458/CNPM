using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class BenhSpecification : Specification<Benh>
    {
        public BenhSpecification(string searchString, int pageIndex, int pageSize) : this(searchString)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        public BenhSpecification(string searchString):base(MakeCriteria(searchString))
        {
        }

        public static Expression<Func<Benh,bool>> MakeCriteria(string searchString){
            Expression<Func<Benh, bool>> predicate = b => true;
            if(!String.IsNullOrEmpty(searchString)){
                predicate = b => b.TenBenh.ToUpper().Contains(searchString.ToUpper()) 
                || b.TenBenh.ToLower().Contains(searchString.ToLower());
            }
            return predicate;
        }
    }
}