using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using O2NextGen.Sdk.NetCore.Models.smalltalk;
using O2NextGen.SmallTalk.Api.Mappings;
using O2NextGen.SmallTalk.Business.Models;
using O2NextGen.SmallTalk.Business.Services;
using System.Threading;
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
        private readonly IChatManager _chatManager;

        #endregion


        #region Ctors

        public ChatController(IHostingEnvironment environment, ILogger<VersionController> logger,
            IChatManager chatManager)
        {
            _environment = environment;
            _logger = logger;
            _chatManager = chatManager;
        }

        #endregion


        #region Methods

        [HttpGet]
        [Route("session/{sessionId}/messages/{id}")]
        public async Task<IActionResult> GetByIdAsync(long sessionId, long id, CancellationToken ct)
        {
            var resultSession = await _chatManager.GetMessageByIdAsync(sessionId, id, ct);
            return Ok(resultSession.ToViewModel());
        }

        [HttpGet]
        [Route("session/{sessionId}/messages")]
        public async Task<IActionResult> GetMessagesAsync(long sessionId, CancellationToken ct)
        {
            var resultWithMessages = await _chatManager.GetMessages(sessionId, ct);
            return Ok(resultWithMessages.ToViewModel());
        }

        //[HttpGet]
        //[Route("session/{sessionId}")]
        //public async Task<IActionResult> GetSessionsAsync(long sessionId, CancellationToken ct)
        //{
        //    var resultWithMessages = await _chatManager.GetSession(sessionId, ct);
        //    return Ok(resultWithMessages.ToViewModel());
        //}

        [HttpPost]
        [HttpPut]
        [Route("session/{sessionId}/messages")]
        public async Task<IActionResult> AddAsync(long sessionId, ChatMessage chatMessage, CancellationToken ct)
        {
            if (chatMessage == null)
                throw new System.ArgumentNullException(nameof(chatMessage));

            ChatMessageModel resultSession = await _chatManager.AddMessage(sessionId, chatMessage.ToModel(), ct);

            return Ok(resultSession.ToViewModel());
        }

        [HttpPut]
        [Route("session/{sessionId}/messages/{id}")]
        public async Task<IActionResult> UpdateAsync(long sessionId, long id, ChatMessage model, CancellationToken ct)
        {
            var certificate = await _chatManager.UpdateMessageAsync(sessionId, model.ToModel(), ct);
            return Ok(certificate.ToViewModel());
        }

        [HttpDelete]
        [Route("session/{sessionId}/messages/{id}")]
        public async Task<IActionResult> RemoveAsync(long sessionId, long id, CancellationToken ct)
        {
            await _chatManager.RemoveMessageAsync(sessionId,id, ct);
            return NoContent();
        }

        #endregion
    }
}