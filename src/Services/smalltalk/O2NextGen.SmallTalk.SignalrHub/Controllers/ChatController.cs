using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using O2NextGen.SmallTalk.SignalrHub.Hubs;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.SignalrHub.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<ChatHub> _hubContext;

        public ChatController(IHubContext<ChatHub> chatHub)
        {
            this._hubContext = chatHub;
        }
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            //await chatHub.UpdateMessages();
            
            await _hubContext.Clients
                .All
                .SendAsync("OnUserUpdateState");
            return Ok("Ok");
        }
    }
}
