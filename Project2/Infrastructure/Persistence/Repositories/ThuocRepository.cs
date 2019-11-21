using System.Net.NetworkInformation;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;

namespace Infrastructure.Persistence.Repositories
{
    public class ThuocRepository : Repository<Thuoc>, IThuocRepository
    {
        public ThuocRepository(QuanLyPhongMach context) : base(context)
        {
        }


        public  QuanLyPhongMach QuanLyPhongMach 
        {
            get { return Context as QuanLyPhongMach; }
        }
        public IEnumerable<BaoCao> BCThuoc(int startMonth, int endMonth, int year)
        {
            var slThuoc = QuanLyPhongMach.PhieuKhams
                        .Join(
                            QuanLyPhongMach.DonThuocs,
                            pk => pk.MaPhieuKham,
                            dt => dt.MaPhieuKham,
                            (pk, dt) => new
                            {
                                pk.NgayKham,
                                dt.MaDonThuoc
                            }
                        )
                        .Where(pk => pk.NgayKham.Value.Month >= startMonth && pk.NgayKham.Value.Month <= endMonth && pk.NgayKham.Value.Year == year)
                        .Join(
                            QuanLyPhongMach.ChiTietDonThuocs,
                            dt => dt.MaDonThuoc,
                            ctdt => ctdt.MaDonThuoc,
                            (dt, ctdt) => new
                            {
                                 ctdt.MaThuoc,
                                 ctdt.SoLuong
                            }
                        )
                        .Join(
                            QuanLyPhongMach.Thuocs,
                            ctdt => ctdt.MaThuoc,
                            t => t.MaThuoc,
                            (ctdt, t) => new BaoCao
                            {
                                TenThuoc = t.TenThuoc,
                                SLTDaban = ctdt.SoLuong.Value
                            }
                        );
            var bcThuoc = slThuoc.GroupBy(slThuoc => slThuoc.TenThuoc)
                          .Select(bc => new BaoCao
                          {
                              TenThuoc = bc.Key,
                              SLTDaban = bc.Sum(ctdt => ctdt.SLTDaban)

                          }).ToList();
            return bcThuoc;
        }

        public void CapNhapSoLuongThuoc(int maThuoc, int soLuong)
        {
            var thuoc = QuanLyPhongMach.Thuocs.Find(maThuoc);
            if(thuoc == null){
                return;
            }
            var tongSoLuong = thuoc.SoLuong;
            thuoc.SoLuong = tongSoLuong - soLuong;
            QuanLyPhongMach.SaveChanges();
        }
    }
}