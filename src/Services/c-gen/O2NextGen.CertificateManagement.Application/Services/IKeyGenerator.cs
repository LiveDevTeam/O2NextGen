namespace O2NextGen.CertificateManagement.Application.Services;

public interface IKeyGenerator
{
    string Generate(int length);
    bool Validate(int maxLength, string key);
}