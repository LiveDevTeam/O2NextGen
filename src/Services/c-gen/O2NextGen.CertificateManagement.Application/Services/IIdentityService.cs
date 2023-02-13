namespace O2NextGen.CertificateManagement.Application.Services;

public interface IIdentityService
{
    string GetUserIdentity();

    string GetUserName();
}