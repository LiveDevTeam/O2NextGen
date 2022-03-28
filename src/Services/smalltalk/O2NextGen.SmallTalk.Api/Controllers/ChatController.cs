using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using O2NextGen.SmallTalk.Api.Mappings;
using O2NextGen.SmallTalk.Business.Models;
using O2NextGen.SmallTalk.Business.Services;
using O2NG.Sdk.NetCore.Models.smalltalk;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Api.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        #region Fields

        private readonly IHostingEnvironment _environment;
        private readonly ILogger<VersionController> _logger;
        private readonly IChatManager _sessionManager;

        #endregion


        #region Ctors

        public ChatController(IHostingEnvironment environment, ILogger<VersionController> logger,
            IChatManager chatManager)
        {
            _environment = environment;
            _logger = logger;
            _sessionManager = chatManager;
        }

        #endregion


        #region Methods

        public void GetMessageDetail()
        {
            throw new System.NotImplementedException();
        }

        public void GetMessage()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetMessagesAsync()
        {
            var resultSession = await _sessionManager.GetMessages();

            return Ok(resultSession.ToViewModel());
        }

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> SendMessage(ChatMessage chatMessage)
        {
            if (chatMessage == null)
                throw new System.ArgumentNullException(nameof(chatMessage));

            ChatMessageModel resultSession = await _sessionManager.AddMessage(chatMessage.ToModel());

            return Ok(resultSession.ToViewModel());
        }

        public void UpdateMessage()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMessage()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}