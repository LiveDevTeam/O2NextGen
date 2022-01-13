using Microsoft.AspNetCore.Mvc;

namespace O2NextGen.Web.BFF.Core.Features.E_Sender
{
    [Route("api/features/e-sender/[controller]")]
    public class VersionController : Controller
    {
        // GET: api/features/e-sender/version
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}

