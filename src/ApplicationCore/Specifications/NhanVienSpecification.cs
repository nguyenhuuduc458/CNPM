using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class NhanVienSpecification : Specification<NhanVien>
    {
        public NhanVienSpecification(string searchString,string EmpRole) : base(MakeCriteria(searchString,EmpRole))
        {

        } 
        public NhanVienSpecification(string searchString,string EmpRole,int pageIndex, int pageSize): this(searchString,EmpRole){
            ApplyPaging(pageIndex, pageSize);
        }
        public static Expression<Func<NhanVien,bool>> MakeCriteria(string searchString,string EmpRole){
            
            Expression<Func<NhanVien, bool>> predicate = m => m.MaVaiTro != 1;
            
            if (!String.IsNullOrEmpty(searchString)&&!String.IsNullOrEmpty(EmpRole))
            {
                if(EmpRole.Equals("Bác sĩ")){
                    predicate = m => m.HoTen.ToLower().Contains(searchString.ToLower()) && m.MaVaiTro == 2;
                }else{
                    predicate = m => m.HoTen.ToLower().Contains(searchString.ToLower()) && m.MaVaiTro == 3; 
                }            
            }else if(!String.IsNullOrEmpty(searchString)){
                predicate = m => m.HoTen.ToLower().Contains(searchString.ToLower());
            }else if(!String.IsNullOrEmpty(EmpRole)){
                if(EmpRole.Equals("Bác sĩ")){
                    predicate = m => m.MaVaiTro == 2;
                }else{
                    predicate = m => m.MaVaiTro == 3;
                }          
            }
            return predicate;
        }
    }
}