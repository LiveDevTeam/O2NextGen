using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Api.Services
{
    public class SignalRService: ISignalRService
    {
        private readonly HttpClient _httpClient;
        public SignalRService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task GetAsync(CancellationToken ct)
        {
             await _httpClient.GetAsync($"api/chat", ct);
        }
    }

    public interface ISignalRService
    {
        Task GetAsync(CancellationToken ct);
    }
}
