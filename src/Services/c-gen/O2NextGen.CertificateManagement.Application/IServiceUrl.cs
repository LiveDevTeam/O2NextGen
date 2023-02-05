namespace O2NextGen.CertificateManagement.Application;

public interface IServiceUrl
{
    string IdentityUrl { get; set; }
    
    string CGenUrl { get; set; }
}