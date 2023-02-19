using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Infrastructure.Data.Configurations;

public class CategoryDbEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.Property(ci => ci.Id)
            .HasColumnType("bigint")
            .UseHiLo("category_hilo")
            .IsRequired();

        //builder.Property(ci => ci.ExternalId)
        //    .IsRequired();
    }
}