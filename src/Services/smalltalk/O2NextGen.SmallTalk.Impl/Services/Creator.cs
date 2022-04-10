using O2NextGen.SmallTalk.Business.Models;
using System;

namespace O2NextGen.SmallTalk.Impl.Services
{
    public class ChatSessionCreator
    {
        internal static object Create()
        {
            var model = new ChatSessionModel();
            SetDefaultValues(model);
            //SetSystemEvents(chatSession);
            return model;
        }

        private static void SetSystemEvents(ChatSessionModel chatSessionModel)
        {
            throw new NotImplementedException();
        }

        private static void SetDefaultValues(ChatSessionModel chatSessionModel)
        {
            chatSessionModel.Events = new System.Collections.Generic.List<ChatEventModel>();
            chatSessionModel.Messages = new System.Collections.Generic.List<ChatMessageModel>();
            chatSessionModel.Invites = new System.Collections.Generic.List<ChatSessionInviteModel>();
        }
    }


    internal class Creator<T> where T : class
    {
        internal static T CreateObject()
        {
            if(typeof(T) == typeof(ChatSessionModel))
                return (T)ChatSessionCreator.Create();
            if(typeof(T) == typeof(ChatMessageModel))
                return (T)ChatMessageCreator.Create();
            return null;
        }
    }

    internal class ChatMessageCreator
    {
        internal static object Create()
        {
            var chatMessage = new ChatMessageModel()
            {
            };
            return chatMessage;
        }
    }
}