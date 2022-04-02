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

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> AddAsync(ChatMessage chatMessage, CancellationToken ct)
        {
            if (chatMessage == null)
                throw new System.ArgumentNullException(nameof(chatMessage));

            ChatMessageModel resultSession = await _chatManager.AddMessage(chatMessage.ToModel(), ct);

            return Ok(resultSession.ToViewModel());
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateAsync(long id, ChatMessage model, CancellationToken ct)
        {
            var certificate = await _chatManager.UpdateMessageAsync(model.ToModel(), ct);
            return Ok(certificate.ToViewModel());
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> RemoveAsync(long id, CancellationToken ct)
        {
            await _chatManager.RemoveMessageAsync(id, ct);
            return NoContent();
        }

        #endregion
    }
}