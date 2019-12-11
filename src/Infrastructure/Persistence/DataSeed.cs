using System;
using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class DataSeed
    {
        public static void Initialize(QuanLyPhongMach context)
        {
            context.Database.EnsureCreated();

            //nhan vien 
            if (!context.NhanViens.Any())
            {
                context.NhanViens.AddRange(
                     new NhanVien
                     {
                         MaVaiTro = 2, // Bac si
                         HoTen = "Hà Thái Anh",
                         GioiTinh = "Nữ",
                         NgaySinh = DateTime.Parse("1999-8-10"),
                         DiaChi = "137/48/19",
                         TenDangNhap = "bacsi2",
                         MatKhau = "202CB962AC59075B964B07152D234B70"
                     },
                      new NhanVien
                      {
                          MaVaiTro = 2, // Bac si
                          HoTen = "Phạm Tuyết Quỳnh Như",
                          GioiTinh = "Nữ",
                          NgaySinh = DateTime.Parse("1999-8-22"),
                          DiaChi = "137/48/19",
                          TenDangNhap = "bacsi3",
                          MatKhau = "202CB962AC59075B964B07152D234B70"
                      },

                     new NhanVien
                     {
                         MaVaiTro = 3, // Nhan vien 
                         HoTen = "Phạm Minh Hiển",
                         GioiTinh = "Nam",
                         NgaySinh = DateTime.Parse("1999-8-12"),
                         DiaChi = "137/48/20",
                         TenDangNhap = "nhanvien1",
                         MatKhau = "202CB962AC59075B964B07152D234B70"
                     },
                    new NhanVien
                    {
                        MaVaiTro = 1, // Quan tri vien 
                        HoTen = "Nguyễn Hữu Đức",
                        GioiTinh = "Nam",
                        NgaySinh = DateTime.Parse("1999-4-10"),
                        DiaChi = "137/48/18",
                        TenDangNhap = "Admin",
                        MatKhau = "202CB962AC59075B964B07152D234B70"
                    },
                    new NhanVien
                    {
                        MaVaiTro = 2, // Bac si
                        HoTen = "Mạc Vĩ Hào",
                        GioiTinh = "Nam",
                        NgaySinh = DateTime.Parse("1999-8-10"),
                        DiaChi = "137/48/19",
                        TenDangNhap = "bacsi1",
                        MatKhau = "202CB962AC59075B964B07152D234B70"
                    }

                );
            }

            // vai tro
            if (!context.VaiTros.Any())
            {
                context.VaiTros.AddRange(
                    new VaiTro
                    {
                        TenVaiTro = "Bác sỹ"
                    },
                    new VaiTro
                    {
                        TenVaiTro = "Nhân viên"
                    },
                     new VaiTro
                     {
                         TenVaiTro = "Quản trị viên"
                     }

              );
            }
            // benh nhanh
            if (!context.BenhNhans.Any())
            {
                context.BenhNhans.AddRange(
           new BenhNhan
           {
               HoTen = "Nguyễn Văn ",
               GioiTinh = "Nam",
               NgaySinh = DateTime.Parse("1999-4-10"),
               DiaChi = "137/48/18",
           },
           new BenhNhan
           {

               HoTen = "Thái Hà Nam",
               GioiTinh = "Nam",
               NgaySinh = DateTime.Parse("1999-8-10"),
               DiaChi = "137/48/19",

           },
           new BenhNhan
           {
               HoTen = "Đỗ Minh  Luân",
               GioiTinh = "Nam",
               NgaySinh = DateTime.Parse("1999-8-12"),
               DiaChi = "137/48/20",

           },
            new BenhNhan
            {
                HoTen = "Phạm Như Quỳnh",
                GioiTinh = "Nữ",
                NgaySinh = DateTime.Parse("1999-8-15"),
                DiaChi = "137/48/20",

            },
           new BenhNhan
           {
               HoTen = "Trần Kim kha",
               GioiTinh = "Nữ",
               NgaySinh = DateTime.Parse("1999-8-17"),
               DiaChi = "137/48/25",

           },
            new BenhNhan
            {
                HoTen = "Lê Minh Thư",
                GioiTinh = "Nữ",
                NgaySinh = DateTime.Parse("1999-6-25"),
                DiaChi = "137/58/20",

            }
            );
            }
            // benh
            if (!context.Benhs.Any())
            {
                context.Benhs.AddRange(
                  new Benh
                  {
                      TenBenh = "Cảm cúm",
                  },
                  new Benh
                  {
                      TenBenh = "Viêm mũi",
                  },
                  new Benh
                  {
                      TenBenh = "Viêm khớp"
                  },
                    new Benh
                  {
                      TenBenh = "Căng cơ"
                  },
                  new Benh
                  {
                      TenBenh = "Chóng mặt"
                  },
                  new Benh
                  {
                      TenBenh = "Viêm xoang"
                  }
                  );
            }
            // Phieu kham
            if (!context.PhieuKhams.Any())
            {
                context.PhieuKhams.AddRange(
                new PhieuKham
                {
                    MaBenhNhan = 1,
                    MaNhanVien = 1,
                    TrieuChung = "Cảm cúm",
                    NgayKham = DateTime.Parse("2019-8-10"),
                    TrangThai = "Chưa kê toa"
                },
                new PhieuKham
                {
                    MaBenhNhan = 2,
                    MaNhanVien = 2,
                    TrieuChung = "Viêm mũi",
                    NgayKham = DateTime.Parse("8-10-2019"),
                    TrangThai = "Chưa kê toa"
                }
            );
            }
            // Thuoc
            if (!context.Thuocs.Any())
            {
                context.Thuocs.AddRange(
                    new Thuoc
                    {
                        TenThuoc = "Phenylephrine",
                        SoLuong = 500000,
                        DonVi = "Viên",
                        DonGia = 15000
                    },
                    new Thuoc
                    {
                        TenThuoc = "Fluoxetine",
                        SoLuong = 500000,
                        DonVi = "Lọ",
                        DonGia = 20000
                    },
                    new Thuoc
                    {
                        TenThuoc = "Hydrochloride",
                        SoLuong = 500000,
                        DonVi = "Viên",
                        DonGia = 25000
                    },
                    new Thuoc
                    {
                        TenThuoc = "Halothane",
                        SoLuong = 500000,
                        DonVi = "Viên",
                        DonGia = 30000
                    },
                    new Thuoc
                    {
                        TenThuoc = "Isoflurane",
                        SoLuong = 500000,
                        DonVi = "Viên",
                        DonGia = 35000
                    },
                    new Thuoc
                    {
                        TenThuoc = "Bupivacaine",
                        SoLuong = 500000,
                        DonVi = "Viên",
                        DonGia = 42000
                    },
                    new Thuoc
                    {
                        TenThuoc = "Atropine",
                        SoLuong = 500000,
                        DonVi = "Viên",
                        DonGia = 42000
                    },
                    new Thuoc
                    {
                        TenThuoc = "Midazolam",
                        SoLuong = 500000,
                        DonVi = "Viên",
                        DonGia = 42000
                    },
                    new Thuoc
                    {
                        TenThuoc = "Morphine",
                        SoLuong = 500000,
                        DonVi = "Viên",
                        DonGia = 42000
                    }
                );

            }
            context.SaveChanges();
        }
    }
}