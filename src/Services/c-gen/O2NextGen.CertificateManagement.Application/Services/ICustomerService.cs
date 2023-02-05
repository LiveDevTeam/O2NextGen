namespace O2NextGen.CertificateManagement.Application.Services
{
    public interface ICustomerService
    {
        Guid CustomerId { get; }
        string CustomerDescription { get; set; }
        string RegisterLink { get; set; }
        string AccountLink { get; set; }
    }
}

