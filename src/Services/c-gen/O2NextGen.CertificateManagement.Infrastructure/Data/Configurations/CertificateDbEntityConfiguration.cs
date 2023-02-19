using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Infrastructure.Data.Configurations;

public class CertificateDbEntityConfiguration : IEntityTypeConfiguration<CertificateEntity>
{
    public void Configure(EntityTypeBuilder<CertificateEntity> builder)
    {
        builder.ToTable("CertificateEntity");

        builder.Property(ci => ci.Id)
            .HasColumnType("bigint")
            .UseHiLo("certificate_hilo")
            .IsRequired();
    }
}