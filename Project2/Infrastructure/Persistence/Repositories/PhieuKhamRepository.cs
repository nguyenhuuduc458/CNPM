using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Models;

namespace Infrastructure.Persistence
{
    public class PhieuKhamRepository : Repository<PhieuKham> , IPhieuKhamRepository
    {
        public PhieuKhamRepository(QuanLyPhongMach context) : base(context)
        {
        }

        protected QuanLyPhongMach QuanLyPhongMach{
            get { return Context as QuanLyPhongMach; }
        }

        public IEnumerable<PhieuKhamMD> GetTablePhieuKham(IEnumerable<PhieuKham> phieukham)
        {
            var tblPhieuKham = from pk in phieukham
                               join nv in QuanLyPhongMach.NhanViens
                               on pk.MaNhanVien equals nv.MaNhanVien
                               join bn in QuanLyPhongMach.BenhNhans
                               on pk.MaBenhNhan equals bn.MaBenhNhan
                               select new PhieuKhamMD
                               {
                                   Id = pk.MaPhieuKham,
                                   TenBacSy = nv.HoTen,
                                   TenBenhNhan = bn.HoTen,
                                   ChuanDoan = pk.TrieuChung,
                                   NgayKham = pk.NgayKham.Value,
                                   TrangThai = pk.TrangThai
                               };
            return tblPhieuKham;
        }
    }
}