using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.Auth.Web.Data;

namespace O2NextGen.Auth.Web.StartupHelpers
{
    internal static class DatabaseExtensions
    {
        internal static async Task EnsureDbUpToDateAsync(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var hostingEnvironment = scope.ServiceProvider.GetRequiredService<IHostingEnvironment>();
                var authDbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
                await authDbContext.Database.MigrateAsync();

                // var grantDbContext = scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();
                // await grantDbContext.Database.MigrateAsync();
            }
        }
    }
}