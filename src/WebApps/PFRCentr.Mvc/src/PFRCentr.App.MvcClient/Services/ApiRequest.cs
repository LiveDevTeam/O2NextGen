using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NotImplementedException = System.NotImplementedException;

namespace PFRCentr.App.MvcClient.Services;

public class ApiRequest : IApiRequest
{
    public SD.ApiType ApiType { get; set; }
    public string Url { get; set; }
    public object Data { get; set; }
    public string Token { get; set; }
}

public class ResponseDto
{
    public string DisplayMessage { get; set; }
    public List<string> ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }
    public object Result { get; set; }
}

public interface IBaseService : IDisposable
{
    ResponseDto ResponseModel { get; set; }
    Task<T> SendAsync<T>(ApiRequest apiRequest);
}

public class BaseService : IBaseService
{
    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public BaseService(IHttpClientFactory httpClient)
    {
        ResponseModel = new ResponseDto();
        HttpClient = httpClient;
    }

    protected IHttpClientFactory HttpClient { get; }
    public ResponseDto ResponseModel { get; set; }

    public async Task<T> SendAsync<T>(ApiRequest apiRequest)
    {
        try
        {
            var client = HttpClient.CreateClient("GCenApi");
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);
            client.DefaultRequestHeaders.Clear();

            if (apiRequest.Data != null)
            {
                var json = JsonConvert.SerializeObject(apiRequest.Data, new JsonSerializerSettings 
                { 
                    ContractResolver = new CamelCasePropertyNamesContractResolver() 
                });
                message.Content = new StringContent(json,Encoding.UTF8,"application/json");
            }
            HttpResponseMessage apiResponce = null;
            switch (apiRequest.ApiType)
            {
                case SD.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case SD.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case SD.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            apiResponce = await client.SendAsync(message);
            var apiContent = await apiResponce.Content.ReadAsStringAsync();
            var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
            return apiResponseDto;
        }
        catch (Exception e)
        {
            var dto = new ResponseDto()
            {
                DisplayMessage = "Error",
                ErrorMessage = new List<string> {Convert.ToString(e.Message)},
                IsSuccess = false
            };
            var res = JsonConvert.SerializeObject(dto);
            var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
            return apiResponseDto;
        }
    }
}

public interface IApiRequest
{
    SD.ApiType ApiType { get; set; }
    string Url { get; set; }
    object Data { get; set; }
    string Token { get; set; }
}