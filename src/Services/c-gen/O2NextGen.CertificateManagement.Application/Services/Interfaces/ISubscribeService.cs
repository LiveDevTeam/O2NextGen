namespace O2NextGen.CertificateManagement.Application.Services.Interfaces;

public interface ISubscribeService
{
    Guid GetTenantInfo();

    Guid GetProductId();
}