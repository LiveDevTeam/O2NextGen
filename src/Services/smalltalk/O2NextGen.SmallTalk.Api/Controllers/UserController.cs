using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace O2NextGen.SmallTalk.Api.Controllers
{
    public class UserController: ControllerBase
    {
        #region Fields

        private readonly IHostingEnvironment _environment;
        private readonly ILogger<VersionController> _logger;

        #endregion


        #region Ctors

        public UserController(IHostingEnvironment environment, ILogger<VersionController> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        #endregion


        #region Methods



        #endregion
    }
}
