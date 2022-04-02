using System;
using System.Collections.Generic;
using System.Text;

namespace O2NextGen.SmallTalk.Core.Services.Chat
{
    public class ChatServiceMock : IChatService
    {
        public void GetByIdMessage(long sessionId, long id)
        {
            throw new NotImplementedException();
        }

        public void GetMessages(long sessionId)
        {
            throw new NotImplementedException();
        }

        public void Sessions(long sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
