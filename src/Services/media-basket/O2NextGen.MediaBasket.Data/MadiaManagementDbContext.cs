using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2NextGen.MediaBasket.Data.Entities;

namespace O2NextGen.MediaBasket.Data
{
    public class MadiaManagementDbContext : DbContext
    {

        #region Fields

        public DbSet<MediaEntity> Certificates { get; set; }

        #endregion

        #region Ctors

        public MadiaManagementDbContext(DbContextOptions<MadiaManagementDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Configure

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaEntity>(ConfigureCertificateEntity);
        }

        private void ConfigureCertificateEntity(EntityTypeBuilder<MediaEntity> builder)
        {
            builder.ToTable("Media");

            builder.Property(ci => ci.Id)
                .HasColumnType("bigint")
                .ForSqlServerUseSequenceHiLo("media_hilo")
                .IsRequired();
        }

        #endregion
    }
}