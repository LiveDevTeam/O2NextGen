using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using O2Bionics.Services.IdPortal.DbContexts;
using O2Bionics.Services.IdPortal.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var environment = builder.Environment;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString"]);
});

// Add services to the container.
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();
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
