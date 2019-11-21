using System.Collections;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Models;
using System;

namespace Infrastructure.Persistence
{
    public class PhieuKhamRepository : Repository<PhieuKham>, IPhieuKhamRepository
    {
        public PhieuKhamRepository(QuanLyPhongMach context) : base(context)
        {
        }

        protected QuanLyPhongMach QuanLyPhongMach
        {
            get { return Context as QuanLyPhongMach; }
        }
        // lap bao cao 
        public IEnumerable<int> BCBenhNhan(int startMonth, int endMonth, int year)
        {
            var bn = QuanLyPhongMach.PhieuKhams
                    .Where(m => m.NgayKham.Value.Month >= startMonth && m.NgayKham.Value.Month <= endMonth)
                    .Select(m => m.MaBenhNhan)
                    .Distinct();
            return bn;
        }

        public IEnumerable<BaoCaoDoanhThuMD> BCDoanhThu(int startMonth, int endMonth, int year)
        {
            var tableDoanhThu = QuanLyPhongMach.PhieuKhams
                                .Where(pk => pk.NgayKham.Value.Month >= startMonth && pk.NgayKham.Value.Month <= endMonth && pk.NgayKham.Value.Year == year)
                                .Join(
                                    QuanLyPhongMach.DonThuocs,
                                    pk => pk.MaPhieuKham,
                                    d => d.MaPhieuKham,
                                    (pk, d) => new BaoCaoDoanhThuMD
                                    {
                                        ThoiGian = pk.NgayKham.Value,
                                        DoanhThu = d.TongTien.Value
                                    }
                                )
                                .GroupBy( dt => new{
                                            dt.ThoiGian})
                                .Select(bc => new BaoCaoDoanhThuMD
                                {
                                    ThoiGian = bc.Key.ThoiGian,
                                    DoanhThu = bc.Sum(dt => dt.DoanhThu)
                                });             
            return tableDoanhThu;
        }

        public IEnumerable<PhieuKhamMD> GetTablePhieuKham(IEnumerable<PhieuKham> phieukham, int MaNhanVien)
        {
            var tblPhieuKham = from pk in phieukham
                               join nv in QuanLyPhongMach.NhanViens
                               on pk.MaNhanVien equals nv.MaNhanVien
                               join bn in QuanLyPhongMach.BenhNhans
                               on pk.MaBenhNhan equals bn.MaBenhNhan
                               where pk.MaNhanVien == MaNhanVien
                               select new PhieuKhamMD
                               {
                                   Id = pk.MaPhieuKham,
                                   TenBacSy = nv.HoTen,
                                   TenBenhNhan = bn.HoTen,
                                   ChuanDoan = pk.TrieuChung,
                                   NgayKham = pk.NgayKham.Value,
                                   TrangThai = pk.TrangThai
                               };
            // var table = phieukham.Join(QuanLyPhongMach.NhanViens,
            //                 pk => pk.MaNhanVien,
            //                 nv => nv.MaNhanVien,
            //                 (pk, nv) => new 
            //                 {
            //                     // Id = pk.MaPhieuKham,
            //                     // MaBenhNhan = pk.MaBenhNhan,
            //                     // MaNhanVien = nv.MaNhanVien,
            //                     id = pk.MaPhieuKham,
            //                     MaBenhNhan=pk.MaBenhNhan,
            //                     MaNhanVien = nv.MaNhanVien,
            //                     TenNhanVien = nv.HoTen
            //                 }
            //                 )
            //                 .Join(QuanLyPhongMach.BenhNhans,
            //                     pk => pk.MaBenhNhan,
            //                     b => b.MaBenhNhan,
            //                     (pk,b) => new PhieuKhamMD{
            //                         Id = id,
            //                         TenBacSy = TenNhanVien.

            //                     }
            //                 );
            return tblPhieuKham;
        }

    }
}