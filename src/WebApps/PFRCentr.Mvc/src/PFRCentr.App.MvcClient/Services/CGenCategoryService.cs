namespace PFRCentr.App.MvcClient.Services;

public class CGenCategoryService : BaseService, ICGenCategoryService
{
    public async Task<T> GetCategoriesAsync<T>()
    {
        return await SendAsync<T>(
            new ApiRequest
        {
            ApiType = SD.ApiType.GET,
            Url = SD.CGenApiBase +"/api/v1.0/Categories",
            Token =""
        });
    }

    public async Task<T> GetCategoryByIdAsync<T>(long id)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CGenApiBase +$"/api/v1.0/Categories/{id}",
                Token =""
            });
    }

    public async Task<T> CreateCategoryAsync<T>(T model)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.CGenApiBase +"/api/v1.0/Categories",
                Token =""
            });
    }
    

    public async Task<T> UpdateCategoryAsync<T>(long id,T model)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = model,
                Url = SD.CGenApiBase + $"/api/v1.0/Categories/{id}",
                Token = ""
            });

    }

    public async Task<T> DeleteCategoryAsync<T>(long id)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CGenApiBase + $"/api/v1.0/Categories/{id}",
                Token = ""
            });
    }

    public CGenCategoryService(IHttpClientFactory httpClient) : base(httpClient)
    {
        
    }
}