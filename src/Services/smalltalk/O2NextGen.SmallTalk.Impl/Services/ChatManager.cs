using O2NextGen.SmallTalk.Api.Services;
using O2NextGen.SmallTalk.Business.Models;
using O2NextGen.SmallTalk.Business.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Impl.Services
{
    public class ChatManager : IChatManager
    {
        private readonly ISessionManager _sessionManager;

        public ChatManager(ISessionManager sessionManager)
        {
            this._sessionManager = sessionManager ?? 
                throw new System.ArgumentNullException(nameof(sessionManager));
        }

        #region Messages
        public async Task<ChatMessageModel> AddMessage(long sessionId,ChatMessageModel chatMessageModel, CancellationToken ct)
        {
            var chatMessage = Creator<ChatMessageModel>.CreateObject();
            chatMessage.Message = chatMessageModel.Message;


            ChatSessionModel chatSession = null;
            //Checking if a session exists or not
            if (await _sessionManager.ExistSessionAsync(sessionId,ct))
            {
                chatSession = await _sessionManager.GetSessionAsync(sessionId,ct);
                var count = chatSession.Messages.Count;
                chatMessage.Id = ++count;
                chatSession.Messages.Add(chatMessage);
            }
            else
            {
                // new session
                var newChatSession = Creator<ChatSessionModel>.CreateObject();
                
                var count = newChatSession.Messages.Count;
                chatMessage.Id = ++count;

                newChatSession.Messages.Add(chatMessage);
                chatSession = await _sessionManager.AddSessionAsync(newChatSession, ct);
            }

            return chatMessage;
        }

        public async Task<ChatMessageModel> GetMessageByIdAsync(long sessionId, long id, CancellationToken ct)
        {
            var result = await _sessionManager.GetMessageByIdAsync(sessionId, id, ct);
            return result;
        }

        public async Task<IReadOnlyCollection<ChatMessageModel>> GetMessages(long idSession,CancellationToken ct)
        {
            var result = await _sessionManager.GetMessages(idSession,ct);
            return result;
        }

        public Task RemoveMessageAsync(long sessionId, long id, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }

        public Task<ChatMessageModel> UpdateMessageAsync(long sessionId, ChatMessageModel chatMessageModel, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
