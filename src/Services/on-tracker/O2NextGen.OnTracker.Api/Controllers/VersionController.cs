using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace O2NextGen.OnTracker.Api.Controllers
{
    [AllowAnonymous]
    public class VersionController : ControllerBase
    {
        #region Fields

        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<VersionController> _logger;

        #endregion


        #region Ctors

        public VersionController(IWebHostEnvironment environment, ILogger<VersionController> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        #endregion


        #region Methods

        [HttpGet("[controller]")]
        public object Index()
        {
            var exVersion = Assembly.GetExecutingAssembly().GetName().Version;
            _logger.LogInformation($"get version - {exVersion}");
            return new
            {
                Environment = _environment.EnvironmentName,
                Version = exVersion.ToString()
            };
        }

        #endregion
    }
}

