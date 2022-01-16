using System.Net;

namespace O2.Tracker.DbUtility
{
    public interface IGeoIpAddressResolver
    {
        GeoLocation ResolveAddress(IPAddress ip);
    }
}