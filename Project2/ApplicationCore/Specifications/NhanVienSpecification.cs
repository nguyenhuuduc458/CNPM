using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class NhanVienSpecification : Specification<NhanVien>
    {
        public NhanVienSpecification(string searchString) : base(MakeCriteria(searchString))
        {

        } 
        public NhanVienSpecification(string searchString,int pageIndex, int pageSize): this(searchString){
            ApplyPaging(pageIndex, pageSize);
        }
        public static Expression<Func<NhanVien,bool>> MakeCriteria(string searchString){
            
            Expression<Func<NhanVien, bool>> predicate = m => true;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                predicate = m => m.HoTen.ToLower().Contains(searchString.ToLower());
            }
            return predicate;
        }


    }
}