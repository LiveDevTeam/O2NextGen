using Newtonsoft.Json;
using IdPortal.App.MvcClient.Models.Dto;

namespace IdPortal.App.MvcClient.Services;

public class IdPortalService : BaseService,IIdPortalService
{
    public async Task<T> GetCategoriesAsync<T>()
    {
        return await SendAsync<T>(
            new ApiRequest
        {
            ApiType = SD.ApiType.GET,
            Url = SD.CGenApiBase +"/Users",
            Token =""
        });
    }

    public async Task<T> GetCategoryByIdAsync<T>(string id)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CGenApiBase +$"/Users/{id}",
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
                Url = SD.CGenApiBase +"/Users",
                Token =""
            });
    }
    

    public async Task<T> UpdateCategoryAsync<T>(string id,T model)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = model,
                Url = SD.CGenApiBase + $"/Users/{id}",
                Token = ""
            });

    }

    public async Task<T> DeleteCategoryAsync<T>(string id)
    {
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CGenApiBase + $"/Users/{id}",
                Token = ""
            });
    }

    public IdPortalService(IHttpClientFactory httpClient) : base(httpClient)
    {
        
    }
}