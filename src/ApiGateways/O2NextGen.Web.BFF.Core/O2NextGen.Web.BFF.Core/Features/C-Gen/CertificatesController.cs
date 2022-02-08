using Microsoft.AspNetCore.Mvc;

namespace O2NextGen.Web.BFF.Core.Features.C_Gen
{
    [Route("api/features/c-gen/[controller]")]
    public class CertificatesController : Controller
    {
        // GET: api/features/c-gen/certificates
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}

