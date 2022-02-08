using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using O2.Tracker.DbUtility;

namespace O2.OnTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IGeoIpAddressResolver _geoIpAddressResolver;

        public ValuesController(IGeoIpAddressResolver geoIpAddressResolver)
        {
            _geoIpAddressResolver = geoIpAddressResolver;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            // var ip = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
            IPAddress remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;//Request.HttpContext.Connection.RemoteIpAddress;
            string result = "";
            if (remoteIpAddress != null)
            {
                // If we got an IPV6 address, then we need to ask the network for the IPV4 address 
                // This usually only happens when the browser is on the same machine as the server.
                if (remoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    remoteIpAddress = System.Net.Dns.GetHostEntry(remoteIpAddress).AddressList
                        .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                }
                result = remoteIpAddress.ToString();
            }

            if (result.ToString() == "127.0.0.1")
                return Ok("request with localhost");
            return Ok(_geoIpAddressResolver.ResolveAddress(IPAddress.Parse(result.ToString())));
            // return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

