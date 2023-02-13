using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Infrastructure.Data;

public class CGenDbContext : DbContext
{
    #region Ctors

    public CGenDbContext(DbContextOptions<CGenDbContext> options)
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

    #region Fields

    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Category> Categories { get; set; }

    #endregion
}