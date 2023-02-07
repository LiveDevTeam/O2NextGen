using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Infrastructure.Data.Configurations;

public class LanguageInfoDbEntityConfiguration : IEntityTypeConfiguration<LanguageInfo>
{
    public void Configure(EntityTypeBuilder<LanguageInfo> builder)
    {
        builder.ToTable("LanguageInfos")
            .HasOne(e => e.Subscription)
            .WithMany(e => e.LanguageInfos)
            .HasForeignKey(e => e.CertificateId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(ci => ci.Id)
            .HasColumnType("bigint")
            .UseHiLo("languageInfo_hilo")
            .IsRequired();
    }
}