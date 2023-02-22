namespace PFRCentr.App.MvcClient.Services;

public interface ICGenCertificateService
{ 
    Task<T> GetCertificatesAsync<T>(string token);
    Task<T> GetCertificateByIdAsync<T>(long id,string token);
    Task<T> CreateCertificateAsync<T>(T model,string token);
    Task<T> UpdateCertificateAsync<T>(long id,T model, string token);
    Task<T> DeleteCertificateAsync<T>(long id,string token);
}