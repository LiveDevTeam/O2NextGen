using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using O2NextGen.SmallTalk.SignalrHub.Hubs;

namespace O2NextGen.Common.Consumers
{
    
    public class SendMessageCompletedEventConsumer: IConsumer<SendMessageCompletedEvent>
    {
        private readonly IHubContext<ChatHub> _chatHub;

        public SendMessageCompletedEventConsumer(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }
        public async Task Consume(ConsumeContext<SendMessageCompletedEvent> context)
        {
            await _chatHub.Clients
                .All
                .SendAsync("OnGetNewMessage");
        }
    }
}