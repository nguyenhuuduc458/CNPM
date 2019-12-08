using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class FindNhanVienSpecification : Specification<NhanVien>
    {
        public FindNhanVienSpecification(string Username,string Password) 
                   : base(MakeCriteria(Username,Password))
        {
        }
        public static Expression<Func<NhanVien,bool>> MakeCriteria(string Username,string Password){
            Expression<Func<NhanVien, bool>> predicate = nv => true;
            if(!String.IsNullOrEmpty(Username)&&!String.IsNullOrEmpty(Password)){
                predicate = nv => nv.TenDangNhap.Equals(Username) && nv.MatKhau.Equals(Password);
            }
            return predicate;
        }
    }
}