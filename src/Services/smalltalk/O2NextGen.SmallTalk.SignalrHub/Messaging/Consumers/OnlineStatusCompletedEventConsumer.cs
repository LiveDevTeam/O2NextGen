using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using O2NextGen.SmallTalk.SignalrHub.Hubs;

namespace O2NextGen.Common.Consumers
{
    public class OnlineStatusCompletedEventConsumer:IConsumer<OnlineStatusCompletedEvent>
    {
        private readonly IHubContext<ChatHub> _chatHub;

        public OnlineStatusCompletedEventConsumer(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }
        public async Task Consume(ConsumeContext<OnlineStatusCompletedEvent> context)
        {
            await _chatHub.Clients
                .All
                .SendAsync("OnSetOnline");
        }
    }
}