using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.Auth.Web.Data;

namespace O2NextGen.Auth.Web.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddConfiguredIdentity(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionString"]));
            
            services
                  
                .AddIdentity<O2User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    //TODO: uncomment after some tests
                    //options.Password.RequiredLength = 12; 
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.User.RequireUniqueEmail = true;
                    // options.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            services.AddConfiguredIdentityServer(configuration);

            return services;
        }
    }
}