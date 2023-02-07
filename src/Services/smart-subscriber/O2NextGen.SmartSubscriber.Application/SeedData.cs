using Microsoft.EntityFrameworkCore;
using O2NextGen.Sdk.NetCore.Extensions;
using O2NextGen.SmartSubscriber.Domain.Entities;
using O2NextGen.SmartSubscriber.Infrastructure.Data;

namespace O2NextGen.SmartSubscriber.Application;

public class SeedData
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        context.Database.Migrate();

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

    private static Subscription[] GetPreconfiguredCertificates(ApplicationDbContext applicationDbContext)
    {
        return new Subscription[]
        {
            new Subscription()
            {
                Product = applicationDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                CategoryId = applicationDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },
            new Subscription()
            {
                Product = applicationDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                CategoryId = applicationDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },
            new Subscription()
            {
                Product = applicationDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                CategoryId = applicationDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },
            new Subscription()
            {
                Product = applicationDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                CategoryId = applicationDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },

            new Subscription()
            {
                Product = applicationDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                CategoryId = applicationDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            }
        };
    }

    private static Product[] GetPreconfiguredCategories()
    {
        return new Product[] {
            new Product()
            {
                CategoryName = "AA Category",
                CategorySeries = "A",
                CategoryDescription = "desc category A",
                QuantityCertificates = 120
            },
            new Product()
            {
                CategoryName = "B Category",
                CategorySeries = "B",
                CategoryDescription = "desc category B",
                QuantityCertificates = 120
            }
        };
    }
}