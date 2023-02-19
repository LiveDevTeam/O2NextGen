using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace O2NextGen.CertificateManagement.StartupTasks.DatabaseInitializer;

public class DatabaseInitializerHostedService<TDbContext> : IHostedService
    where TDbContext : DbContext
{
    private readonly IServiceScopeFactory _scopeFactory;

    private readonly DatabaseInitializerSettings _settings;

    public DatabaseInitializerHostedService(IServiceScopeFactory scopeFactory, DatabaseInitializerSettings settings)
    {
        _scopeFactory = scopeFactory;
        _settings = settings;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

        if (_settings.Initialize) await dbContext.Database.MigrateAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}