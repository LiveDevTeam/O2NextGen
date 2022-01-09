using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace O2NextGen.Mobile.BFF.Core.Features.ESender
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

