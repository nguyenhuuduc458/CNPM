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
            _unitOfWork.NhanViens.Add(nv);
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

        public IEnumerable<SaveNhanVienDTO> GetNhanViens(string sortOrder, string searchString)
        {
            Expression<Func<NhanVien, bool>> predicate = m => true;
            //search
            if (!String.IsNullOrEmpty(searchString))
            {
                predicate = m => m.HoTen.ToLower().Contains(searchString.ToLower());
            }
            var NhanVien = _unitOfWork.NhanViens.Find(predicate);
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
            string usernamesql = _unitOfWork.NhanViens.GetTenDangNhap(username);
            string passwordsql = _unitOfWork.NhanViens.GetMatkhau(username);
            string tennhanvien = _unitOfWork.NhanViens.GetTenNhanVien(username);
            int role = _unitOfWork.NhanViens.GetVaiTro(username);
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

        public List<string> CreateSession(string username)
        {
            List<string> listSession = new List<string>();
            var tennhanvien = _unitOfWork.NhanViens.GetTenNhanVien(username);
            var role = _unitOfWork.NhanViens.GetVaiTro(username);
            listSession.Add(tennhanvien);
            listSession.Add(role.ToString());
            return listSession;
        }
    }
}