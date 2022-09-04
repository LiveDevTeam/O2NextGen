using O2NextGen.IdentityServer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(IdentityServerConfiguration.GetApiResources())
    .AddInMemoryClients(IdentityServerConfiguration.GetClients())
    .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResources())
    .AddInMemoryApiScopes(IdentityServerConfiguration.GetApiScope())
    .AddDeveloperSigningCredential();  
builder.Services.AddControllersWithViews(); 
var app = builder.Build();
app.UseCors(builder => { builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); }); 
app.UseRouting(); 
app.UseAuthentication();
app.UseAuthorization();
app.UseIdentityServer(); 
app.MapDefaultControllerRoute();

app.Run();

