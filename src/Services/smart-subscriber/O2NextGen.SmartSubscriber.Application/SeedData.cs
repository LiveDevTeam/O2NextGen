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
                GetPreconfiguredProducts());
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
                ProductId = applicationDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },
            new Subscription()
            {
                Product = applicationDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                ProductId = applicationDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },
            new Subscription()
            {
                Product = applicationDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                ProductId = applicationDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },
            new Subscription()
            {
                Product = applicationDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                ProductId = applicationDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            },

            new Subscription()
            {
                Product = applicationDbContext.Categories.FirstOrDefault(),
                CustomerId = Guid.NewGuid().ToString(),
                AddedDate = DateTime.Now.ConvertToUnixTime(),
                IsVisible = true,
                ProductId = applicationDbContext.Categories.FirstOrDefault().Id,
                CreatorId = Guid.NewGuid().ToString(),
                ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
            }
        };
    }

    private static Product[] GetPreconfiguredProducts()
    {
        return new Product[] {
            new Product()
            {
                ProductName = "PFR Centr",
                ProductCode = "1",
                ProductDescription = "desc category A",
                CustomerId = ""
            },
            new Product()
            {
                ProductName = "CGen",
                ProductCode = "2",
                ProductDescription = "desc category B",
                CustomerId = ""
            }
        };
    }
}