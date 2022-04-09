using O2NextGen.Sdk.NetCore.Models.smalltalk;
using O2NextGen.SmallTalk.Core.Extensions;
using O2NextGen.SmallTalk.Core.Helpers;
using O2NextGen.SmallTalk.Core.Services.RequestProvider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Core.Services.Chat
{
    public class ChatService : IChatService
    {
        public ChatService(IRequestProvider requestProvider)
        {
            this._requestProvider = requestProvider;
        }
        private const string _apiUrlBase = "/api/chat";
        private readonly IRequestProvider _requestProvider;

        public async Task<ChatMessage> AddMessageToSessionAsync(string message)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayChatEndpoint, $"{_apiUrlBase}/session/1/messages");

            var addMessage = await _requestProvider.PostAsync(uri, new ChatMessage()
            {
                Id = 0,
                Message = message,
                RecipientId = 2,
                SenderId = 1
            });

            return addMessage;
        }

        public void GetByIdMessage(long sessionId, long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<ChatMessage>> GetMessageAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayChatEndpoint, $"{_apiUrlBase}/session/1/messages");

            var messages = await _requestProvider.GetAsync<IEnumerable<ChatMessage>>(uri);

            if (messages != null)
                return messages?.ToObservableCollection();
            else
                return new ObservableCollection<ChatMessage>();
        }

        public async Task GetMessagesAsync(long sessionId)
        {
            throw new NotImplementedException();
        }

        public async Task<ChatSession> GetSessionAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayChatEndpoint, $"{_apiUrlBase}/session/1");

            var chatSession = await _requestProvider.GetAsync<ChatSession>(uri);

            if (chatSession != null)
                return chatSession;
            else
                return new ChatSession();
            //throw new NotImplementedException();
        }

        public Task<ObservableCollection<ChatSession>> GetSessionsAsync()
        {
            throw new NotImplementedException();
        }

        public void Sessions(long sessionId)
        {
            throw new NotImplementedException();
        }

        void IChatService.GetMessagesAsync(long sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
