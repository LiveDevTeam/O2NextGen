using O2NextGen.CertificateManagement.Application;
using O2NextGen.CertificateManagement.Application.IoC;
using O2NextGen.CertificateManagement.Infrastructure.Data;
using O2NextGen.CertificateManagement.StartupTasks.DatabaseInitializer;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var environment = builder.Environment;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddConfigEf(configuration)
    .AddDatabaseInitializer<CGenDbContext>()
    .AddBusiness()
    .AddInfrastructure();

var app = builder.Build();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<CGenDbContext>();
SeedData.SeedAsync(context).Wait();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{


}
app.UseSwagger();
app.UseSwaggerUI();
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

