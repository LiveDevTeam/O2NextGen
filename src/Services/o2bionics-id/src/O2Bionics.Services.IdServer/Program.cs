using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using O2Bionics.Services.IdServer;
using O2Bionics.Services.IdServer.Certificates;
using O2Bionics.Services.IdServer.DbContexts;
using O2Bionics.Services.IdServer.Initializer;
using O2Bionics.Services.IdServer.Models;
using O2Bionics.Services.IdServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString"]);
});
// Add services to the container.
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
// var dataProtectionKeysLocation =
//     builder.Configuration.GetSection<DataProtectionSettings>(nameof(DataProtectionSettings))?.Location;
// if (!string.IsNullOrWhiteSpace(dataProtectionKeysLocation))
var settings = builder.Configuration.GetSection("DataProtection").Get<DataProtectionSettings>();
Console.WriteLine(" ========================= SETTINGS ========================== ");
Console.WriteLine(
    $"DataProtection AadTenantId={settings.AadTenantId} keyId={settings.KeyVaultKeyId} account={settings.StorageAccountName} blob={settings.StorageKeyBlobName}  blob-dev={settings.StorageDevKeyBlobName}");
Console.WriteLine(" ================= END SETTINGS ====================\r\n");

// var storageAccount = CloudStorageAccount.Parse(
//     "DefaultEndpointsProtocol=https;AccountName=o2nextgen001;AccountKey=twBN1I6NPVBTDfaaowm71LznRdfcN9f5uA8MhcW6fYqCOBxl5wtchEinoE7EVHdi0FLDz2sSd4Io+AStJfqN2A==;EndpointSuffix=core.windows.net");
// Console.WriteLine($"storageAccount={storageAccount}");
// var client = storageAccount.CreateCloudBlobClient();
// var container = client.GetContainerReference(settings.StorageKeyContainerName);
// container.CreateIfNotExistsAsync().GetAwaiter().GetResult();
// var blobName = IsProduction ? settings.StorageKeyBlobName : settings.StorageDevKeyBlobName;

var keysFolder = Path.Combine(builder.Environment.ContentRootPath, "temp-keys");
{
    builder.Services
        .AddDataProtection()
        // This blob must already exist before the application is run
        .PersistKeysToAzureBlobStorage(
            "DefaultEndpointsProtocol=https;AccountName=o2nextgen001;AccountKey=twBN1I6NPVBTDfaaowm71LznRdfcN9f5uA8MhcW6fYqCOBxl5wtchEinoE7EVHdi0FLDz2sSd4Io+AStJfqN2A==;EndpointSuffix=core.windows.net",
            "dataprotection", "keys.xml");
    // Removing this line below for an initial run will ensure the file is created correctly
    //.ProtectKeysWithAzureKeyVault(new Uri("<keyIdentifier>"), new DefaultAzureCredential());
    // .PersistKeysToAzureBlobStorage(container, blobName);
    // .PersistKeysToDbContext<DataProtectedDbContext>()
    // .SetApplicationName("fow-customer-portal")
    // .PersistKeysToFileSystem(new DirectoryInfo(keysFolder))
    // .SetDefaultKeyLifetime(TimeSpan.FromDays(30))
    //.ProtectKeysWithDpapi();

    // .PersistKeysToFileSystem(new DirectoryInfo(dataProtectionKeysLocation));
    // TODO: encrypt the keys
}
var pass = "P@55w0rd";
var filename = "IdentityServer4_certificate";
var filepath = Path.Combine(builder.Environment.ContentRootPath, filename);
// var options = new GenerateCertificateOptions
// (
//     pathToSave: builder.Environment.ContentRootPath,
//     commonName: "IdentityServer4",
//     fileName: filename,
//     password: pass,
//     5
// );
// certificateHelper.MakeCert(options);

var certificate = new X509Certificate2(
    Path.Combine(builder.Environment.ContentRootPath, "IdentityServer4_certificate.pfx"), pass);

builder.Services.AddIdentityServer(options =>
    {
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;

        options.EmitStaticAudienceClaim = true;
    }).AddKeyManagement()
    .AddInMemoryIdentityResources(SD.IdentityResources)
    .AddInMemoryApiScopes(SD.ApiScopes)
    .AddInMemoryClients(SD.GetClients(SD.GetUrls(builder.Configuration)))
    .AddAspNetIdentity<ApplicationUser>()
    //.AddDeveloperSigningCredential()
    .AddSigningCredential(certificate);

//.AddDeveloperSigningCredential();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

}
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
// app.UseHsts();
// app.UseHttpsRedirection();
// app.Use((context, next) => { context.Request.Scheme = "https"; return next(); });
app.UseStaticFiles();
using var scope = app.Services.CreateScope();
var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
initializer?.Initialize();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();