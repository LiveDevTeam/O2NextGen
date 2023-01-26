using System;
using System.Diagnostics;
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
        #region Fields

        private readonly IGeoIpAddressResolver _geoIpAddressResolver;

        #endregion


        #region Ctors

        public GeoController(IGeoIpAddressResolver geoIpAddressResolver)
        {
            _geoIpAddressResolver = geoIpAddressResolver;
        }

        #endregion


        #region Methods

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            Console.WriteLine("start");
            // var ip = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
            //IPAddress remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
            //Request.HttpContext.Connection.RemoteIpAddress;
            //IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;//
            IPAddress remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
            // IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
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


            Console.WriteLine(remoteIpAddress.ToString());
            if (result == "127.0.0.1")
                return Ok("request with localhost");
            var found = _geoIpAddressResolver.ResolveAddress(IPAddress.Parse(result));

            if (found == null)
                return NotFound("Result not found");
            return Ok(found);
        }

        #endregion
    }
}