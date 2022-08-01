using System;
using Microsoft.AspNetCore.Http;

namespace O2NextGen.CertificateManagement.Business.Services
{
    public class CustomerService : ICustomerService
    {
        // ReSharper disable once NotAccessedField.Local
        private IHttpContextAccessor _context;

        public CustomerService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Guid CustomerId { get; } = Guid.Parse("A6D86517-CF70-4EEF-8340-BCBAA4B60C4A");
        public string CustomerDescription { get; set; } = "#PF_R Community";
        public string RegisterLink { get; set; } = "https://pfr-centr.com";
        public string AccountLink { get; set; } = "https://pfr-centr.com";
    }
}