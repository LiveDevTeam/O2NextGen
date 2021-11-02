using Microsoft.AspNetCore.Http;

namespace O2NextGen.CertificateManagement.Web.Helpers
{
    public static class ExceptionExtensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Contol-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}