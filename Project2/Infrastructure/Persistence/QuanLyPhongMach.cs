using System.Data.Common;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence {
    public class QuanLyPhongMach : DbContext {
        public QuanLyPhongMach (DbContextOptions<QuanLyPhongMach> options) : base (options) { }

        public DbSet<Benh> Benhs { get; set; }
        public DbSet<ChiTietDonThuoc> ChiTietDonThuocs { get; set; }
        public DbSet<DonThuoc> DonThuocs { get; set; }
        public DbSet<PhieuKham> PhieuKhams { get; set; }
        public DbSet<Thuoc> Thuocs { get; set; }
        public DbSet<VaiTro> VaiTros { get; set; }
        public DbSet<BenhNhan> BenhNhans { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuanLyPhongMach).Assembly);
        }

    }
}