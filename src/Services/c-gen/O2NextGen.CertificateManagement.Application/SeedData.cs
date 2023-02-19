using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Infrastructure.Data;
using O2NextGen.Sdk.NetCore.Extensions;

namespace O2NextGen.CertificateManagement.Application;

public class SeedData
{
    public static async Task SeedAsync(CGenDbContext context, ConfigurationManager configuration)
    {
        // context.Database.EnsureDeleted();
        if (bool.Parse(configuration["IsTests"]) == false)
        {
            await context.Database.MigrateAsync();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    GetPreconfiguredCategories());
                await context.SaveChangesAsync();
            }

            if (!context.Certificates.Any())
            {
                context.Certificates.AddRange(
                    GetPreconfiguredCertificates(context));
                await context.SaveChangesAsync();
            }
        }
    }

    private static CertificateEntity[] GetPreconfiguredCertificates(CGenDbContext cGenDbContext)
    {
        return new[]
        {
            new()
            {
                CategoryEntity = cGenDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                CategoryId = cGenDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },
            new CertificateEntity
            {
                CategoryEntity = cGenDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                CategoryId = cGenDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },
            new CertificateEntity
            {
                CategoryEntity = cGenDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                CategoryId = cGenDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },
            new CertificateEntity
            {
                CategoryEntity = cGenDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                CategoryId = cGenDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },

            new CertificateEntity
            {
                CategoryEntity = cGenDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                CategoryId = cGenDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            }
        };
    }

    private static CategoryEntity[] GetPreconfiguredCategories()
    {
        return new[]
        {
            new()
            {
                CategoryName = "AA Category",
                CategorySeries = "A",
                CategoryDescription = "desc category A",
                QuantityCertificates = 120
            },
            new CategoryEntity
            {
                CategoryName = "B Category",
                CategorySeries = "B",
                CategoryDescription = "desc category B",
                QuantityCertificates = 120
            }
        };
    }
}