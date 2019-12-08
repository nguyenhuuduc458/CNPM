using System.Collections.Immutable;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ThuocConfiguration : IEntityTypeConfiguration<Thuoc>
    {
        public void Configure(EntityTypeBuilder<Thuoc> builder)
        {
            builder.Property(t => t.TenThuoc)
                   .HasMaxLength(15)
                   .IsRequired(true);

            builder.Property(t => t.DonGia)
                   .HasAnnotation("Range", (1, 100))
                   .IsRequired(true);

            builder.Property(t => t.DonVi)
                   .IsRequired(true)
                   .HasMaxLength(10);

            builder.Property(t => t.SoLuong)
                   .IsRequired(true);

        }
    }
}