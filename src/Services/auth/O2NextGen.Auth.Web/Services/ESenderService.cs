using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace O2NextGen.Auth.Web.Services
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data, CancellationToken cancellationToken)
        {
            var dataAsString = JsonConvert.SerializeObject(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpClient.PostAsync(url, content, cancellationToken);
        }

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content, CancellationToken cancellationToken)
        {
            var dataAsString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(dataAsString);
        }
    }
    public interface IESenderService
    {
        Task Send(string email, string subject, string htmlMessage);
    }
    public class ESenderService: IESenderService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<UrlsConfig> _config;
        
        public ESenderService(HttpClient httpClient, IOptions<UrlsConfig> config)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
        
        public async Task Send(string email, string subject, string htmlMessage)
        {
            var model = new MailRequestViewModel()
            {
                Subject = subject,
                To = email,
                Body = htmlMessage
            };
            var response = await _httpClient.PostAsJsonAsync("api/emailsender",model,CancellationToken.None);
            await response.Content.ReadAsJsonAsync<MailRequestViewModel>(CancellationToken.None);
        }
    }
}