using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class BenhNhanSpecification : Specification<BenhNhan>
    {
        public BenhNhanSpecification(string searchString) : base(MakeCriteria(searchString))
        {

        }
        public BenhNhanSpecification(string searchString,int pageIndex, int pageSize) : this(searchString){
            ApplyPaging(pageIndex, pageSize);
        }
        public static Expression<Func<BenhNhan,bool>> MakeCriteria(string searchString){
            Expression<Func<BenhNhan, bool>> predicate = m => true;
            //search
            if (!String.IsNullOrEmpty(searchString))
            {
                predicate = m => m.HoTen.ToLower().Contains(searchString.ToLower());
            }
            return predicate;
        }

    }
}