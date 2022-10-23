using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.Tracker.DbUtility;

namespace O2NextGen.OnTracker.Api.Controllers
{
    [Route("api/geo")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        private readonly IGeoIpAddressResolver _geoIpAddressResolver;

        public GeoController(IGeoIpAddressResolver geoIpAddressResolver)
        {
            _geoIpAddressResolver = geoIpAddressResolver;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            // var ip = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
            //IPAddress remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;//Request.HttpContext.Connection.RemoteIpAddress;
            //IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;//
            IPAddress remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
            string result = "";
            if (remoteIpAddress != null)
            {
                // If we got an IPV6 address, then we need to ask the network for the IPV4 address 
                // This usually only happens when the browser is on the same machine as the server.
                if (remoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    remoteIpAddress = Dns.GetHostEntry(remoteIpAddress).AddressList
                        .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                }
                result = remoteIpAddress.ToString();
            }

            if (result.ToString() == "127.0.0.1")
                return Ok("request with localhost");
            return Ok(_geoIpAddressResolver.ResolveAddress(IPAddress.Parse(result.ToString())));
            // return new string[] { "value1", "value2" };
        }

    }
}

