namespace PFRCentr.App.MvcClient.Services;

public class CGenCategoryService : BaseService, ICGenCategoryService
{
    public async Task<T> GetCategoriesAsync<T>(string token)
    {
        return await SendAsync<T>(
            new ApiRequest
        {
            ApiType = SD.ApiType.GET,
            Url = SD.CGenApiBase +"/api/v1.0/Categories",
            Token = token ?? ""
        });
    }

    public async Task<T> GetCategoryByIdAsync<T>(long id, string token)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CGenApiBase +$"/api/v1.0/Categories/{id}",
                Token = token ?? ""
            });
    }

    public async Task<T> CreateCategoryAsync<T>(T model, string token)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.CGenApiBase +"/api/v1.0/Categories",
                Token = token ?? ""
            });
    }
    

    public async Task<T> UpdateCategoryAsync<T>(long id,T model, string token)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = model,
                Url = SD.CGenApiBase + $"/api/v1.0/Categories/{id}",
                Token = token ?? ""
            });

    }

    public async Task<T> DeleteCategoryAsync<T>(long id, string token)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CGenApiBase + $"/api/v1.0/Categories/{id}",
                Token = token ?? ""
            });
    }

    public CGenCategoryService(IHttpClientFactory httpClient) : base(httpClient)
    {
        
    }
}