using System.Net;

namespace O2NextGen.Tracker.DbUtility
{
    public interface IGeoIpAddressResolver
    {
        GeoLocation ResolveAddress(IPAddress ip);
    }
}