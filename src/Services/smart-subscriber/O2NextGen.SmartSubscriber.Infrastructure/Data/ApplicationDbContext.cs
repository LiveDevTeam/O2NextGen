using Microsoft.EntityFrameworkCore;
using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{

    #region Fields

    public DbSet<Subscription> Certificates { get; set; }
    public DbSet<Product> Categories { get; set; }
    #endregion

    #region Ctors

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    #endregion

    #region Configure

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<CertificateEntity>(ConfigureCertificateEntity);
    //}

    //private void ConfigureCertificateEntity(EntityTypeBuilder<CertificateEntity> builder)
    //{
    //    builder.ToTable("Certificate");

    //    builder.Property(ci => ci.Id)
    //        .HasColumnType("bigint")
    //        .UseHiLo("certificate_hilo")
    //        .IsRequired();
    //}

    #endregion
}