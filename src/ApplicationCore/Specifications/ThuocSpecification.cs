using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class ThuocSpecification : Specification<Thuoc>
    {
        public ThuocSpecification(string searchString) 
                 :base(MakeCriteria(searchString))
        {
            
        }
        public ThuocSpecification(string searchString,int pageIndex,int pageSize) : this(searchString)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        protected static Expression<Func<Thuoc,bool>> MakeCriteria(string searchString){
            Expression<Func<Thuoc,bool>> predicate = m =>true;
            if(!String.IsNullOrEmpty(searchString)){
                predicate = m => m.TenThuoc.ToLower().Contains(searchString.ToLower());
            }
            return predicate;
        }
    }
}