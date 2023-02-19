using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Infrastructure.Data.Configurations;

public class LanguageInfoDbEntityConfiguration : IEntityTypeConfiguration<LanguageInfoEntity>
{
    public void Configure(EntityTypeBuilder<LanguageInfoEntity> builder)
    {
        builder.ToTable("LanguageInfoEntity")
            .HasOne(e => e.CertificateEntity)
            .WithMany(e => e.LanguageInfos)
            .HasForeignKey(e => e.CertificateId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(ci => ci.Id)
            .HasColumnType("bigint")
            .UseHiLo("languageInfo_hilo")
            .IsRequired();
    }
}