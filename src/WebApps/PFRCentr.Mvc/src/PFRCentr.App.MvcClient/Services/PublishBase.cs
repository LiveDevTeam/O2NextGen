using Microsoft.AspNetCore.Mvc.Rendering;
using PFRCentr.App.MvcClient.Models.Dto;

namespace PFRCentr.App.MvcClient.Services;

public class PublishBase : BaseService,IPublishBase
{


    public PublishBase(IHttpClientFactory httpClient) : base(httpClient)
    {
    }
    
    
    // public Task<PublishCertificateDto> GetItems(int page, int take, int? brand, int? type)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<T> GetItems<T>(int page, int take, long? type)
    {
        
        return await SendAsync<T>(
            new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CGenApiBase +"/api/v1.0/PublishBase?categoryTypeId=2861&pageSize=14&pageIndex=0",
                Token = ""
            });
    }

    public Task<IEnumerable<SelectListItem>> GetTypes()
    {
        throw new NotImplementedException();
    }
}