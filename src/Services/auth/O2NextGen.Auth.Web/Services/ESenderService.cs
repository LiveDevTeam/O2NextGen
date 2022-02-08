using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace O2NextGen.Auth.Web.Services
{
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
            await response.Content.ReadAsAsync<MailRequestViewModel>(CancellationToken.None);
        }
    }
}