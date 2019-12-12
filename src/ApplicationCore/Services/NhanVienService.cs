using System.Dynamic;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using ApplicationCore.Specifications;

namespace ApplicationCore.Services
{
    public class NhanVienService : INhanVienService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NhanVienService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(SaveNhanVienDTO nhanvien)
        {
            var nv = _mapper.Map<SaveNhanVienDTO, NhanVien>(nhanvien);
            MD5 md5hash = MD5.Create();
            if(nv.MaVaiTro == 1){
                NhanVien nv2 = new NhanVien
                {
                    HoTen = nv.HoTen,
                    NgaySinh = nv.NgaySinh,
                    DiaChi = nv.DiaChi,
                    MaVaiTro = nv.MaVaiTro,
                    GioiTinh = nv.GioiTinh,
                    TenDangNhap = "Admin" + getMaTaiKhoan(),
                    MatKhau = GetMd5hash(md5hash, "123")
                };
                _unitOfWork.NhanViens.Add(nv2);

            }else if(nv.MaVaiTro == 2){
                NhanVien nv2 = new NhanVien
                {
                    HoTen = nv.HoTen,
                    NgaySinh = nv.NgaySinh,
                    DiaChi = nv.DiaChi,
                    MaVaiTro = nv.MaVaiTro,
                    GioiTinh = nv.GioiTinh,
                    TenDangNhap = "bacsi" + getMaTaiKhoan(),
                    MatKhau = GetMd5hash(md5hash, "123")
                };
                _unitOfWork.NhanViens.Add(nv2);

            }else{
                NhanVien nv2 = new NhanVien
                {
                    HoTen = nv.HoTen,
                    NgaySinh = nv.NgaySinh,
                    DiaChi = nv.DiaChi,
                    MaVaiTro = nv.MaVaiTro,
                    GioiTinh = nv.GioiTinh,
                    TenDangNhap = "nhanvien" + getMaTaiKhoan(),
                    MatKhau = GetMd5hash(md5hash, "123")
                };
                _unitOfWork.NhanViens.Add(nv2);
            }
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            var nv = _unitOfWork.NhanViens.GetById(id);
            _unitOfWork.NhanViens.Remove(nv);
            _unitOfWork.Complete();
        }

        public void Edit(SaveNhanVienDTO nhanvien)
        {
            var nv = _mapper.Map<SaveNhanVienDTO, NhanVien>(nhanvien);
            _unitOfWork.NhanViens.Update(nv);
            _unitOfWork.Complete();
        }

        public IEnumerable<SaveVaiTroDTO> GetAllMaVT()
        {
            IEnumerable<VaiTro> vt = _unitOfWork.VaiTros.GetAll();
            return _mapper.Map<IEnumerable<VaiTro>, IEnumerable<SaveVaiTroDTO>>(vt);
        }

        public IEnumerable<SaveVaiTroDTO> GetDSVTConlai(int MaVaiTro)
        {
            Expression<Func<VaiTro, bool>> predicate = m => true;

            predicate = m => m.MaVaiTro != MaVaiTro;

            IEnumerable<VaiTro> vt = _unitOfWork.VaiTros.Find(predicate);
            return _mapper.Map<IEnumerable<VaiTro>, IEnumerable<SaveVaiTroDTO>>(vt);
        }

        public SaveNhanVienDTO GetNhanVien(int id)
        {
            var nhanvien = _unitOfWork.NhanViens.GetById(id);
            return _mapper.Map<NhanVien, SaveNhanVienDTO>(nhanvien);
        }

        public IEnumerable<SaveNhanVienDTO> GetNhanViens(string sortOrder, string searchString,string EmpRole, int pageIndex, int pageSize, out int count)
        {
            NhanVienSpecification nhanVienFilterPaging = new NhanVienSpecification(searchString,EmpRole, pageIndex, pageSize);
            NhanVienSpecification nhanVienFilter = new NhanVienSpecification(searchString,EmpRole);
             
            var NhanVien = _unitOfWork.NhanViens.FindSpec(nhanVienFilterPaging);
            count = _unitOfWork.NhanViens.Count(nhanVienFilter);
            //sort 
            switch (sortOrder)
            {
                case "name_desc":
                    NhanVien = NhanVien.OrderByDescending(m => m.HoTen);
                    break;
                case "Date":
                    NhanVien = NhanVien.OrderBy(m => m.NgaySinh);
                    break;
                case "Date_desc":
                    NhanVien = NhanVien.OrderByDescending(m => m.NgaySinh);
                    break;
                default:
                    NhanVien = NhanVien.OrderBy(m => m.DiaChi);
                    break;
            }
            return _mapper.Map<IEnumerable<NhanVien>, IEnumerable<SaveNhanVienDTO>>(NhanVien);
        }

        public string GetTenVaiTro(int MaVaiTro)
        {
            Expression<Func<VaiTro, bool>> predicate = m => true;
            predicate = m => m.MaVaiTro == MaVaiTro;
            return _unitOfWork.VaiTros.Find(predicate).Select(m => m.TenVaiTro).FirstOrDefault().ToString();
        }

        public bool Login(string username, string password)
        {
            // mã hóa password trước khi tìm kiếm 
            MD5 md5 = MD5.Create();
            var hashPassword = GetMd5hash(md5, password);

            FindNhanVienSpecification nhanVienSpecification = new FindNhanVienSpecification(username,hashPassword);
            var nhanVien = _unitOfWork.NhanViens.FindSpec(nhanVienSpecification).FirstOrDefault();
            
            string usernamesql;
            string passwordsql;
            if(nhanVien == null){
                return false;
            }else{
                usernamesql = nhanVien.TenDangNhap;
                passwordsql = nhanVien.MatKhau;
            }
               
              
            using (MD5 md5hash = MD5.Create())
            {
                if (VerifyMd5Hash(md5hash, password, passwordsql) && usernamesql == username)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        public string GetMd5hash(MD5 md5hash, string input)
        {
            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public bool VerifyMd5Hash(MD5 md5hash, string input, string hash)
        {
            var hashOfInput = GetMd5hash(md5hash, input);
            if (String.Compare(hash, hashOfInput) == 0)
            {
                return true;
            }
            return false;
        }

        public List<string> CreateSession(string username,string password)
        {   
            // mã hóa password trước khi tìm kiếm
            MD5 md5hash = MD5.Create();
            var hasPassword = GetMd5hash(md5hash, password); 

            List<string> listSession = new List<string>();

            FindNhanVienSpecification nhanVienSpecification = new FindNhanVienSpecification(username, hasPassword);
            var nhanVien = _unitOfWork.NhanViens.FindSpec(nhanVienSpecification).FirstOrDefault();

            string tennhanvien = nhanVien.HoTen;
            int role           = nhanVien.MaVaiTro;
            int manhanvien     = nhanVien.MaNhanVien;
            
            listSession.Add(tennhanvien);
            listSession.Add(role.ToString());
            listSession.Add(manhanvien.ToString());
            return listSession;
        }
        // tao tên đăng nhập mac dinh cho tài khoản
        public int getMaTaiKhoan(){
            
            var ListNhanVien = _unitOfWork.NhanViens.GetAll();

            var nhanvien = ListNhanVien.ElementAtOrDefault(0);

            var max = nhanvien.MaNhanVien;

            foreach(var nv in ListNhanVien){
                if(nv.MaNhanVien >= max){
                    max = nv.MaNhanVien;
                }
            }
            return max;
        }
       
        public void UpdatePassword(string username,string matKhau,string MatKhauMoi)
        {
            using (MD5 md5hash = MD5.Create())
            {
                var hashPassword = GetMd5hash(md5hash, matKhau);
                var hashPasswordNew = GetMd5hash(md5hash, MatKhauMoi);
                _unitOfWork.NhanViens.UpdatePassword(username,hashPassword,hashPasswordNew);
            }
        }

        public bool checkValidPassword(string username, string matKhau)
        {
            using(MD5 md5hash = MD5.Create()){
                var hashPassword = GetMd5hash(md5hash, matKhau);
                FindNhanVienSpecification nv = new FindNhanVienSpecification(username,hashPassword);
                NhanVien nhanvien = _unitOfWork.NhanViens.FindSpec(nv).FirstOrDefault();
                if (nhanvien == null)
                {
                    return false;
                }
                return true;
            }
        }

        public IEnumerable<string> GetVaiTro()
        {
            Expression<Func<VaiTro, bool>> predicate = v => v.MaVaiTro != 1;
            return _unitOfWork.VaiTros.Find(predicate).Select(s => s.TenVaiTro);
        }
    }
}