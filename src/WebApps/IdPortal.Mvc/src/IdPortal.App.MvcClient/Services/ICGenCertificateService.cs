namespace IdPortal.App.MvcClient.Services;

public interface ICGenCertificateService
{ 
    Task<T> GetCertificatesAsync<T>();
    Task<T> GetCertificateByIdAsync<T>(long id);
    Task<T> CreateCertificateAsync<T>(T model);
    Task<T> UpdateCertificateAsync<T>(long id,T model);
    Task<T> DeleteCertificateAsync<T>(long id);
}