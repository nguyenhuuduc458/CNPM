using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;

    public class QuanLyPhongKham : DbContext
    {
        public QuanLyPhongKham (DbContextOptions<QuanLyPhongKham> options)
            : base(options)
        {
        }

        public DbSet<ApplicationCore.Entities.ChiTietDonThuoc> ChiTietDonThuoc { get; set; }
    }
