using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace O2NextGen.CertificateManagement.StartupTasks.DatabaseInitializer;

public static class DatabaseInitializerServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseInitializer<TDbContext>(
        this IServiceCollection services,
        string databaseInitializerSettingsPath = nameof(DatabaseInitializerSettings))
        where TDbContext : DbContext
    {
        services.AddSingleton(serviceProvider
            => serviceProvider
                .GetRequiredService<IConfiguration>()
                .GetSection(databaseInitializerSettingsPath)
                .Get<DatabaseInitializerSettings>());

        return services.AddHostedService<DatabaseInitializerHostedService<TDbContext>>();
    }
}