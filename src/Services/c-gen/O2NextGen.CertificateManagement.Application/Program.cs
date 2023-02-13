using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using O2NextGen.CertificateManagement.Application;
using O2NextGen.CertificateManagement.Application.Helpers;
using O2NextGen.CertificateManagement.Application.IoC;
using O2NextGen.CertificateManagement.Infrastructure.Data;
using O2NextGen.CertificateManagement.StartupTasks.DatabaseInitializer;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var environment = builder.Environment;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(o =>
{
    o.ReportApiVersions = true;
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1.1", 
        new OpenApiInfo
        {
            Title = "Versioned Api v1.1", Version = "v1.1"
        });
    options.SwaggerDoc("v1.0",
        new OpenApiInfo
        {
            Title = "Versioned Api v1.0",
            Version = "v1.0"
        }
    );
    options.DescribeAllParametersInCamelCase();

    // Apply the filters
    options.OperationFilter<RemoveVersionFromParameter>();
    options.DocumentFilter<ReplaceVersionWithExactValueInPath>();

    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        var actionApiVersionModel = apiDesc.ActionDescriptor?.GetApiVersion();

        if (actionApiVersionModel == null) return true;

        return actionApiVersionModel.DeclaredApiVersions.Any()
            ? actionApiVersionModel.DeclaredApiVersions.Any(v => $"v{v.ToString()}" == docName)
            : actionApiVersionModel.ImplementedApiVersions.Any(v => $"v{v.ToString()}" == docName);
    });
});
builder.Services
    .AddConfigEf(configuration)
    .AddDatabaseInitializer<CGenDbContext>()
    .AddBusiness()
    .AddInfrastructure();

var app = builder.Build();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<CGenDbContext>();
SeedData.SeedAsync(context, configuration).Wait();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1.1/swagger.json", "O2Certificate Management API V1.1");
    options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "O2Certificate Management API V1.0");
    //options.OAuthClientId("swaggerca");
});
app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers.Add("X-Powered-By", "O2NextGen Platform");
        return Task.CompletedTask;
    });

    await next.Invoke();
});
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}