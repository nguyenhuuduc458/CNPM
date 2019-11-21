using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
             builder.HasKey(nv => nv.MaNhanVien);

            builder.Property(nv => nv.HoTen)
                   .IsRequired(true)
                   .HasMaxLength(15);

            builder.Property(nv => nv.NgaySinh)
                   .IsRequired(true);

            builder.Property(nv => nv.GioiTinh)
                   .IsRequired(true);
            
        }
    }
}