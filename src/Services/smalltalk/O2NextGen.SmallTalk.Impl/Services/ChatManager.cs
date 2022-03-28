using O2NextGen.SmallTalk.Api.Services;
using O2NextGen.SmallTalk.Business.Models;
using O2NextGen.SmallTalk.Business.Services;
using System.Collections.Generic;
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


        public async Task<ChatMessageModel> AddMessage(ChatMessageModel chatMessageModel)
        {
            var chatMessage = Creator<ChatMessageModel>.CreateObject();
            chatMessage.Message = chatMessageModel.Message;


            ChatSessionModel chatSession = null;
            //Checking if a session exists or not
            if (await _sessionManager.ExistSessionAsync())
            {
                chatSession = await _sessionManager.GetSessionAsync();
                chatSession.Messages.Add(chatMessage);
            }
            else
            {
                // new session
                var newChatSession = Creator<ChatSessionModel>.CreateObject();
                newChatSession.Messages.Add(chatMessage);
                chatSession = await _sessionManager.AddSessionAsync(newChatSession, System.Threading.CancellationToken.None);
            }


            return chatMessage;
        }

        public async Task<IReadOnlyCollection<ChatMessageModel>> GetMessages()
        {
            var result = await _sessionManager.GetMessages(System.Threading.CancellationToken.None);
            return result;
        }
    }
}
