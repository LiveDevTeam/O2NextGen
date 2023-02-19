namespace PFRCentr.App.MvcClient.Services;

public class CGenCertificateService: BaseService,ICGenCertificateService
{
    public CGenCertificateService(IHttpClientFactory httpClient) : base(httpClient)
    {
    }
    public async Task<T> GetCertificatesAsync<T>()
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CGenApiBase +"/api/v1.0/Certificates",
                Token =""
            });
    }

    public async Task<T> GetCertificateByIdAsync<T>(long id)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CGenApiBase +$"/api/v1.0/Certificates/{id}",
                Token =""
            });
    }

    public async Task<T> CreateCertificateAsync<T>(T model)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.CGenApiBase +"/api/v1.0/Certificates",
                Token =""
            });
    }
    

    public async Task<T> UpdateCertificateAsync<T>(long id,T model)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = model,
                Url = SD.CGenApiBase + $"/api/v1.0/Certificates/{id}",
                Token = ""
            });

    }

    public async Task<T> DeleteCertificateAsync<T>(long id)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CGenApiBase + $"/api/v1.0/Certificates/{id}",
                Token = ""
            });
    }
}