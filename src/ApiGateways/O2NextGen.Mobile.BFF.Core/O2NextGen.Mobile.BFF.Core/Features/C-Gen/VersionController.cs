using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace O2NextGen.Mobile.BFF.Core.Features.CGen
{
    [Route("api/features/c-gen/[controller]")]
    public class VersionController : Controller
    {
        // GET: api/features/c-gen/version
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}

