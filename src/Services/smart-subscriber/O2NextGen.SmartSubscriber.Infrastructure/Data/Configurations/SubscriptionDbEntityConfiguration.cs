using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Infrastructure.Data.Configurations;

public class SubscriptionDbEntityConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("Subscription");

        builder.Property(ci => ci.Id)
            .HasColumnType("bigint")
            .UseHiLo("subscription_hilo")
            .IsRequired();
    }
}