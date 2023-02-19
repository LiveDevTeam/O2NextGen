using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.Sdk.NetCore.Extensions;

namespace IntegrationTests.O2NextGen.CertificateManagement.Application.Features;

public class CertificatesApiTests : BaseIntegrationApiTests
{
    [Fact]
    public async Task Certificates_GetById_Test()
    {
        // Act
        //var webAppFactory = new CustomWebApplicationFactory<Program>();//
        //var _httpClient = webAppFactory.CreateDefaultClient();
        const string url = "api/v1.0/certificates/1";
        var response = await _httpClient.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
    }

    [Fact]
    public async Task Categories_Get_Test()
    {
        // Act
        // var webAppFactory = new CustomWebApplicationFactory<Program>();//
        // var _httpClient = webAppFactory.CreateDefaultClient();
        const string url = "api/v1.0/certificates";
        var response = await _httpClient.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
    }

    [Fact]
    public async Task Categories_Update_Test()
    {
        // Act
        // var webAppFactory = new CustomWebApplicationFactory<Program>();//
        // var _httpClient = webAppFactory.CreateDefaultClient();
        const string url = "api/v1.0/certificates";
        var addItem = new Certificate
        {
            Category = context.Categories.FirstOrDefault(),
            CustomerId = Guid.NewGuid().ToString(),
            AddedDate = DateTime.Now.ConvertToUnixTime(),
            IsVisible = true,
            CategoryId = context.Categories.FirstOrDefault().Id,
            CreatorId = Guid.NewGuid().ToString(),
            ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
        };
        var ser = JsonConvert.SerializeObject(addItem);
        var content = new StringContent(ser,
            Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
    }

    [Fact]
    public async Task Categories_Add_Test()
    {
        // Act
        // var webAppFactory = new CustomWebApplicationFactory<Program>();//
        // var _httpClient = webAppFactory.CreateDefaultClient();
        const string url = "api/v1.0/certificates";
        var addItem = new Certificate
        {
            Category = context.Categories.FirstOrDefault(),
            CustomerId = Guid.NewGuid().ToString(),
            AddedDate = DateTime.Now.ConvertToUnixTime(),
            IsVisible = true,
            CategoryId = context.Categories.FirstOrDefault().Id,
            CreatorId = Guid.NewGuid().ToString(),
            ExpiredDate = DateTime.Now.AddYears(1).ConvertToUnixTime()
        };
        var ser = JsonConvert.SerializeObject(addItem);
        var content = new StringContent(ser,
            Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
    }

    [Fact]
    public async Task Categories_Delete_Test()
    {
        // Act
        // var webAppFactory = new CustomWebApplicationFactory<Program>();//
        // var _httpClient = webAppFactory.CreateDefaultClient();
        const string url = "api/v1.0/certificates/2";
        var response = await _httpClient.DeleteAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Null(
            response.Content.Headers.ContentType);
    }
}