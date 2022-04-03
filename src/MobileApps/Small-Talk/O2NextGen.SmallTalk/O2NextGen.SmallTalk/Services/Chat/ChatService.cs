using O2NextGen.Sdk.NetCore.Models.smalltalk;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Core.Services.Chat
{
    public class ChatService : IChatService
    {
        public void GetByIdMessage(long sessionId, long id)
        {
            throw new NotImplementedException();
        }

        public void GetMessages(long sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<ChatSession>> GetSessionsAsync()
        {
            throw new NotImplementedException();
        }

        public void Sessions(long sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
