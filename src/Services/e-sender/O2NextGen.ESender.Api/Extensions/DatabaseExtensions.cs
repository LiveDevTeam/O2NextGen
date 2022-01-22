using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.ESender.Data;

namespace O2NextGen.ESender.Api.Extensions
{
    internal static class DatabaseExtensions
    {
        internal static async Task EnsureDbUpdate(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ESenderDbContext>();
                await context.Database.MigrateAsync();
            }
        }
    }
}