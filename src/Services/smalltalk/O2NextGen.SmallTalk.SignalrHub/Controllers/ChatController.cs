using Microsoft.AspNetCore.Mvc;
using O2NextGen.SmallTalk.SignalrHub.Hubs;

namespace O2NextGen.SmallTalk.SignalrHub.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatHub chatHub;

        public ChatController(IChatHub chatHub)
        {
            this.chatHub = chatHub;
        }
        [HttpGet]
        public void Test()
        {
            chatHub.UpdateMessages();
        }
    }
}
