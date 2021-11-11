using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace O2NextGen.Auth.Data
{
    public class AuthDbContext : IdentityDbContext<O2User>
    {
        #region Ctors

        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Override Methods

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        // }

        #endregion
    }
}