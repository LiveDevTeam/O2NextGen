using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Infrastructure.Data.Configurations;

public class ProductDbEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.Property(ci => ci.Id)
            .HasColumnType("bigint")
            .UseHiLo("product_hilo")
            .IsRequired();

        //builder.Property(ci => ci.ExternalId)
        //    .IsRequired();
    }
}