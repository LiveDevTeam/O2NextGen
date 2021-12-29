using System;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace O2NextGen.CertificateManagement.Web.Controllers
{
    
    [AllowAnonymous]
    public class VersionController:ControllerBase
    {
        #region Fields

        private readonly IHostingEnvironment _environment;

        #endregion

        
        #region Ctors

        public VersionController(IHostingEnvironment  environment)
        {
            _environment = environment;
        }

        #endregion

        [HttpGet("[controller]")]
        public object Index()
        {
            var exVersion = Assembly.GetExecutingAssembly().GetName().Version;
            return new
            {
                Environment = _environment.EnvironmentName,
                Version = exVersion.ToString()
            };
        }
    }
}