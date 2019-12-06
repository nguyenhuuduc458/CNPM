using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class BenhConfiguration : IEntityTypeConfiguration<Benh>
    {
        public void Configure(EntityTypeBuilder<Benh> builder)
        {
            builder.HasKey(b => b.MaBenh);

            builder.Property(b => b.TenBenh)
                   .IsRequired(true);
        }
    }
}