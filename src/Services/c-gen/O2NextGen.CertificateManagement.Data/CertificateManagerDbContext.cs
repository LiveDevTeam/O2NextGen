using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2NextGen.CertificateManagement.Data.Entities;

namespace O2NextGen.CertificateManagement.Data
{
    public class CertificateManagerDbContext : DbContext
    {

        #region Fields

        public DbSet<CertificateEntity> Certificates { get; set; }

        #endregion

        #region Ctors

        public CertificateManagerDbContext(DbContextOptions<CertificateManagerDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Configure

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CertificateEntity>(ConfigureCertificateEntity);
        }

        private void ConfigureCertificateEntity(EntityTypeBuilder<CertificateEntity> builder)
        {
            builder.ToTable("Certificate");

            builder.Property(ci => ci.Id)
                .HasColumnType("bigint")
                .ForSqlServerUseSequenceHiLo("certificate_hilo")
                .IsRequired();
        }

        #endregion
    }
}