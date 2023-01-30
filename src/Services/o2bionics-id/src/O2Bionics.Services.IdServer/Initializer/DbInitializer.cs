using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using O2Bionics.Services.IdServer.DbContexts;
using O2Bionics.Services.IdServer.Models;

namespace O2Bionics.Services.IdServer.Initializer;

public class DbInitializer : IDbInitializer
{
    private readonly UserManager<ApplicationUser> _manager;
    private readonly ApplicationDbContext _db;
    private readonly RoleManager<IdentityRole> _roleManager;

    public DbInitializer(UserManager<ApplicationUser> manager, ApplicationDbContext db,
        RoleManager<IdentityRole> roleManager)
    {
        _manager = manager;
        _db = db;
        _roleManager = roleManager;
    }

    public void Initialize()
    {
        if (_roleManager.FindByNameAsync(SD.Admin).Result == null)
        {
            _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
        }
        else
        {
            return;
        }

        string password = "P@ssword1";
        ApplicationUser adminUser = new ApplicationUser()
        { 
            Id = Guid.NewGuid().ToString(),
            UserName = "demo@demo.com",
            Email = "demo@demo.com",
            EmailConfirmed = true,
            PhoneNumber = "1111111111111",
            FirstName = "Admin",
            LastName = "Root"
        };

        _manager.CreateAsync(adminUser, password).GetAwaiter().GetResult();
        _manager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

        var temp1 = _manager.AddClaimsAsync(adminUser, new Claim []
        {
            new Claim(JwtClaimTypes.Name, adminUser.FirstName + " " + adminUser.LastName),
            new Claim(JwtClaimTypes.GivenName, adminUser.FirstName ),
            new Claim(JwtClaimTypes.FamilyName , adminUser.LastName ),
            new Claim(JwtClaimTypes.Role , SD.Admin  )
        }).GetAwaiter().GetResult() ;


        ApplicationUser customerUser = new ApplicationUser()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "customer@demo.com",
            Email = "customer@demo.com",
            EmailConfirmed = true,
            PhoneNumber = "1111111111111",
            FirstName = "Denis",
            LastName = "Prox",
        };
       
        _manager.CreateAsync(customerUser, password).GetAwaiter().GetResult();
        _manager.AddToRoleAsync(customerUser, SD.Customer).GetAwaiter().GetResult();

        var temp2 = _manager.AddClaimsAsync(customerUser, new Claim[]
        {
            new Claim(JwtClaimTypes.Name, customerUser.FirstName + " " + customerUser.LastName),
            new Claim(JwtClaimTypes.GivenName, customerUser.FirstName ),
            new Claim(JwtClaimTypes.FamilyName , customerUser.LastName ),
            new Claim(JwtClaimTypes.Role , SD.Customer  )
        }).GetAwaiter().GetResult();

        
    }
}