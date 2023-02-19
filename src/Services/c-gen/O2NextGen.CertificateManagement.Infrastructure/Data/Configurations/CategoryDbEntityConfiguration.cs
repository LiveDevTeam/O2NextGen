using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Infrastructure.Data.Configurations;

public class CategoryDbEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("CategoryEntity");

        builder.Property(ci => ci.Id)
            .HasColumnType("bigint")
            .UseHiLo("category_hilo")
            .IsRequired();

        //builder.Property(ci => ci.ExternalId)
        //    .IsRequired();
    }
}