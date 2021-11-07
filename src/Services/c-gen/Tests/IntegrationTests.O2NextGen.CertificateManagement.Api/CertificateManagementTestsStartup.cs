using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using O2NextGen.CertificateManagement.Web;

namespace IntegrationTests.O2NextGen.CertificateManagement.Api
{
    public class CertificateManagementTestsStartup : Startup
    {
        public CertificateManagementTestsStartup(IConfiguration config,IHostingEnvironment env)
            : base(config,env)
        {
        }

        // protected override void ConfigureAuth(IApplicationBuilder app)
        // {
        //     //if (Configuration["isTest"] == bool.TrueString.ToLowerInvariant())
        //     //    app.UseMiddleware<AutoAuthorizeMiddleware>();
        //     //else
        //     app.UseMiddleware<AutoAuthorizeMiddleware>();
        //     base.ConfigureAuth(app);
        // }
    }
}