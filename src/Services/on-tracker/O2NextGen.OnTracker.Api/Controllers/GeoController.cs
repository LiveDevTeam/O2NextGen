﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
        // [HttpGet]
        // public ActionResult Get()
        // {
        //     IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
        //     string remoteIpAddress = Convert.ToString(ipHostEntry.AddressList.FirstOrDefault(address=>address.AddressFamily==
        //         System.Net.Sockets.AddressFamily.InterNetwork))
        //     // Console.WriteLine("start");
        //     // // var ip = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
        //     // //IPAddress remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
        //     // //Request.HttpContext.Connection.RemoteIpAddress;
        //     // //IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;//
        //     //  var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
        //     //     // HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
        //     // // IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
        //     // string result = "";
        //     //
        //     // Console.WriteLine($"ip - {remoteIpAddress}");
        //     // // if (remoteIpAddress == "::1")
        //     // //     result = Dns.GetHostEntry(remoteIpAddress).AddressList[2].ToString();
        //     // if (remoteIpAddress != null)
        //     // {
        //     //     if (remoteIpAddress == "::1")
        //     //         result = Dns.GetHostEntry(remoteIpAddress).AddressList[2].ToString();
        //     //     // If we got an IPV6 address, then we need to ask the network for the IPV4 address 
        //     //     // This usually only happens when the browser is on the same machine as the server.
        //     //     // if (remoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
        //     //     // {
        //     //     //    // var iPs =  Array.FindAll(
        //     //     //    //      Dns.GetHostEntry(remoteIpAddress).AddressList,
        //     //     //    //      address => address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
        //     //     //     // remoteIpAddress = Dns.GetHostEntry(remoteIpAddress).AddressList
        //     //     //     //     .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
        //     //     //     // foreach (var ip in iPs)
        //     //     //     // {
        //     //     //     //     Console.WriteLine($"find ip address - {ip}");
        //     //     //     // }
        //     //     //     
        //     //     //     remoteIpAddress = iPs.First();
        //     //     // }
        //     //
        //     //     result = remoteIpAddress.ToString();
        //     // }
        //
        //
        //     Console.WriteLine(remoteIpAddress.ToString());
        //     
        //     if (result == "127.0.0.1")
        //         return Ok("request with localhost");
        //     Console.WriteLine("start find to base");
        //     var found = _geoIpAddressResolver.ResolveAddress(IPAddress.Parse(result));
        //
        //     if (found == null)
        //         return NotFound("Result not found");
        //     return Ok(found);
        // }

        [HttpGet]
        public ActionResult<string> GetIpAddress0fClient()
        {
            string ipAddress = string. Empty;
            IPAddress ip = Request.HttpContext. Connection. RemoteIpAddress;
            if (ip != null)
            {
                if (ip. AddressFamily == AddressFamily. InterNetworkV6)
                {
                    ip = Dns.GetHostEntry(ip) .AddressList
                        .First (_ => _. AddressFamily == AddressFamily. InterNetwork);
                }
                ipAddress = ip. ToString();
            }
            return Ok(ipAddress);
        }

        #endregion
    }
}