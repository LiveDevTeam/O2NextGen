using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace O2NextGen.Mobile.BFF.Core.Features.CGen
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

