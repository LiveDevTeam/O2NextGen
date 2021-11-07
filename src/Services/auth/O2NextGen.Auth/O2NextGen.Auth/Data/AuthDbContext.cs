using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace O2NextGen.Auth.Data
{
    public class AuthDbContext : IdentityDbContext<O2User>
    {
        #region Ctors

        public AuthDbContext()
        {
            
        }

        #endregion
    }
}