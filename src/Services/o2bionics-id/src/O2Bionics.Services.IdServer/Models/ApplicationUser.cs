using Microsoft.AspNetCore.Identity;

namespace O2Bionics.Services.IdServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public  string LastName { get; set; }
    }
}