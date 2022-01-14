using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using O2NextGen.Web.BFF.Core.Config;
using O2NextGen.Web.BFF.Core.Features.E_Sender.Models;

namespace O2NextGen.Web.BFF.Core.Features.E_Sender.Services
{
    public class ESenderService: IESenderService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<UrlsConfig> _config;
        private string ApiVersion { get; } = "1.0";
        
        public ESenderService(HttpClient httpClient, IOptions<UrlsConfig> config)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
        public async Task<MailRequestViewModel> AddAsync(MailRequestViewModel model, CancellationToken ct)
        {
            var response = await _httpClient.PostAsJsonAsync(_config.Value.ESenderUrl+"/api/emailsender",model,ct);
            return await response.Content.ReadAsAsync<MailRequestViewModel>(ct);
        }

        public async Task<MailRequestViewModel> GetAsync(long id, CancellationToken ct)
        {
            var response = await _httpClient.GetAsync(_config.Value.ESenderUrl+$"/api/emailsender/{id}",ct);
            return await response.Content.ReadAsAsync<MailRequestViewModel>(ct);
            
        }
    }
}