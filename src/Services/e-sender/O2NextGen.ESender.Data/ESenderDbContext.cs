using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2NextGen.ESender.Data.Entities;

namespace O2NextGen.ESender.Data
{
    public class ESenderDbContext: DbContext
    {
        #region Fields

        public DbSet<MailRequestEntity> MailRequests { get; set; }

        #endregion
        
        #region Ctors

        public ESenderDbContext(DbContextOptions<ESenderDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Configure

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailRequestEntity>(ConfigureMailRequestEntity);
        }

        private void ConfigureMailRequestEntity(EntityTypeBuilder<MailRequestEntity> builder)
        {
            builder.ToTable("MailRequest");

            builder.Property(ci => ci.Id)
                .HasColumnType("bigint")
                .ForSqlServerUseSequenceHiLo("mailrequest_hilo")
                .IsRequired();
        }

        #endregion
    }
}