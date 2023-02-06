using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace O2Bionics.Services.IdPortal.Controllers
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

        [HttpGet("[controller]")]
        public object Index()
        {
            var exVersion = GetVersion();
            _logger.LogInformation($"get version - {exVersion}");
            return new
            {
                Environment = _environment.EnvironmentName,
                Version = exVersion?.ToString()
            };
        }

        protected virtual Version GetVersion()
        {
            var exVersion = Assembly.GetExecutingAssembly().GetName().Version;
            return exVersion ?? throw new InvalidOperationException();
        }
    }
}
