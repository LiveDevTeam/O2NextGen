using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Infrastructure.Data;
using O2NextGen.Sdk.NetCore.Extensions;

namespace IntegrationTests.O2NextGen.CertificateManagement.Application.Features;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    public CGenDbContext Context { get; set; }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // var path = Assembly.GetAssembly(typeof(CategoriesApiTests))
        //     .Location;
        //         
        // builder.UseContentRoot(Path.GetDirectoryName(path));
        builder.ConfigureAppConfiguration(config =>
        {
            //
            config.AddJsonFile("appsettings.Tests.json", false)
                .AddEnvironmentVariables();
        });

        builder.ConfigureServices(services =>
        {
            // Build the service provider.
            var sp = services.BuildServiceProvider();
            Context = sp.GetRequiredService<CGenDbContext>();
            // context.Database.EnsureDeleted();
            Context.Database.Migrate();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            // foreach (var category in context.Categories)
            //     context.Categories.Remove(category);

            Context.Categories.AddRange(new Category
                {
                    //Id = 1,
                    CategoryName = "AA Category",
                    CategorySeries = "A",
                    CategoryDescription = "desc category A",
                    QuantityCertificates = 120
                },
                new Category
                {
                    //Id = 2,
                    CategoryName = "AA Category 2",
                    CategorySeries = "A",
                    CategoryDescription = "desc category A",
                    QuantityCertificates = 120
                });

            Context.Certificates.AddRange(new Certificate
                {
                    Category = Context.Categories.FirstOrDefault(),
                    CustomerId = Guid.NewGuid().ToString(),
                    AddedDate = DateTime.Now.ConvertToUnixTime(),
                    IsVisible = true,
                    CategoryId = Context.Categories.FirstOrDefault().Id,
                    CreatorId = Guid.NewGuid().ToString(),
                    ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
                },
                new Certificate
                {
                    Category = Context.Categories.FirstOrDefault(),
                    CustomerId = Guid.NewGuid().ToString(),
                    AddedDate = DateTime.Now.ConvertToUnixTime(),
                    IsVisible = true,
                    CategoryId = Context.Categories.FirstOrDefault().Id,
                    CreatorId = Guid.NewGuid().ToString(),
                    ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
                });

            Context.SaveChanges();
            // var _options = new DbContextOptionsBuilder<CGenDbContext>()
            //     .UseInMemoryDatabase("testDB").Options;
            // var context = new CGenDbContext(_options);

            // var dbContextDescriptor = services.SingleOrDefault(
            //     d => d.ServiceType ==
            //          typeof(DbContextOptions<CGenDbContext>));
            //
            // services.Remove(dbContextDescriptor);
            //
            // services.AddDbContext<CGenDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"), 
            // ServiceLifetime.Scoped, 
            // ServiceLifetime.Scoped);
            // var serviceProvider = new ServiceCollection()
            //     .AddEntityFrameworkInMemoryDatabase()
            //     .BuildServiceProvider();

            // services.AddDbContext<CGenDbContext>(options =>
            // {
            //     options.UseInMemoryDatabase("InMemoryDbForTesting");
            //     //options.UseInternalServiceProvider(serviceProvider);
            //     //options.EnableSensitiveDataLogging();
            // });
        });
    }

    protected override void Dispose(bool disposing)
    {
        Context.Database.EnsureDeleted();
        base.Dispose(disposing);
    }
}