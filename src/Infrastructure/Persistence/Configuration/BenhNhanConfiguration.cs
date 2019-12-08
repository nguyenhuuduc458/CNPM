using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class BenhNhanConfiguration : IEntityTypeConfiguration<BenhNhan>
    {
        public void Configure(EntityTypeBuilder<BenhNhan> builder)
        {
            builder.HasKey(nv => nv.MaBenhNhan);

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