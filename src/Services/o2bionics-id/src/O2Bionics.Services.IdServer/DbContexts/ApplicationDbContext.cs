using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using O2Bionics.Services.IdServer.Models;

namespace O2Bionics.Services.IdServer.DbContexts
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>, IDataProtectionKeyContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        { 
            
        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; }
    }
}
