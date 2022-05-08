using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using O2NextGen.SmallTalk.SignalrHub.Hubs;
using System.Threading.Tasks;
using MassTransit;
using O2NextGen.Common;

namespace O2NextGen.SmallTalk.SignalrHub.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<ChatHub> _hubContext;
        private readonly IBus _bus;

        public ChatController(IHubContext<ChatHub> chatHub,IBus bus)
        {
            this._hubContext = chatHub;
            _bus = bus;
        }
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            //await chatHub.UpdateMessages();
            _bus.Publish<SendMessageCompletedEvent>(new { userId = "1" , recipientId="2"}).Wait();
            await _hubContext.Clients
                .All
                .SendAsync("OnUserUpdateState");
            return Ok("Ok");
        }
    }
}
