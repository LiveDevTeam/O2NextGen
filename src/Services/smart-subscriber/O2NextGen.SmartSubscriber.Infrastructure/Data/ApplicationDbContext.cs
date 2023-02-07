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
    #endregion
}