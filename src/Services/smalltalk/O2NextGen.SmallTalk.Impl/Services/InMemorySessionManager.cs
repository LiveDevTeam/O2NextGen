using O2NextGen.SmallTalk.Business.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Api.Services
{
    public class InMemorySessionManager : ISessionManager
    {
        #region Fields

        private static readonly List<ChatSessionModel> Sessions = new List<ChatSessionModel>()
        {
            new ChatSessionModel()
            {
                Id = 1,
                Messages = new List<ChatMessageModel>()
                {
                    new ChatMessageModel()
                    {
                        Id=1,
                        SenderId=1,
                        RecipientId=2,
                        Message = "Test message"
                    },
                    new ChatMessageModel()
                    {
                        Id=2,
                        SenderId=1,
                        RecipientId=2,
                        Message = "Test message 2"
                    },
                    new ChatMessageModel()
                    {
                        Id=3,
                        SenderId=2,
                        RecipientId=1,
                        Message = "Back Test message 1"
                    },
                },
            },
                new ChatSessionModel()
            {        Id = 2,
                Messages = new List<ChatMessageModel>()
                {
                    new ChatMessageModel()
                    {
                        Id=1,
                        SenderId=1,
                        RecipientId=2,
                        Message = "s2 Test message"
                    },
                    new ChatMessageModel()
                    {
                        Id=2,
                        SenderId=1,
                        RecipientId=2,
                        Message = "s2 Test message 2"
                    },
                    new ChatMessageModel()
                    {
                        Id=3,
                        SenderId=2,
                        RecipientId=1,
                        Message = "s2 Back Test message 1"
                    },
                }
            }
        };
        private long _currentId;

        #endregion

        #region Ctors

        public InMemorySessionManager()
        {
            _currentId = Sessions.Count();
        }

        #endregion
        public async Task<IReadOnlyCollection<ChatSessionModel>> GetAllAsync(CancellationToken ct)
        {
            await Task.Delay(1, ct);
            return await Task.FromResult<IReadOnlyCollection<ChatSessionModel>>(Sessions.AsReadOnly());
        }

        public async Task<ChatSessionModel> AddSessionAsync(ChatSessionModel chatSession, CancellationToken ct)
        {
            await Task.Delay(1, ct);
            chatSession.Id = ++_currentId;
            Sessions.Add(chatSession);
            return await Task.FromResult(chatSession);
        }

        public async Task<bool> ExistSessionAsync(long sessionId, CancellationToken ct)
        {
            var result = Sessions.Any(_ => _.Id == sessionId);
            return await Task.FromResult<bool>(result);
        }

        public async Task<ChatSessionModel> GetSessionAsync(long sessionId, CancellationToken ct)
        {
            var result = Sessions.Single(_ => _.Id == sessionId);
            return await Task.FromResult(result);
        }

        public async Task<IReadOnlyCollection<ChatMessageModel>> GetMessages(long idSession, CancellationToken ct)
        {
            await Task.Delay(1, ct);
            var messages = Sessions.Single(_ => _.Id == idSession).Messages;
            return await Task.FromResult<IReadOnlyCollection<ChatMessageModel>>(messages.AsReadOnly());
        }

        public async Task<ChatMessageModel> GetMessageByIdAsync(long idSession, long id, CancellationToken ct)
        {
            await Task.Delay(1, ct);
            var message = Sessions.Single(_ => _.Id == idSession).Messages.Single(_ => _.Id == id);
            return await Task.FromResult(message);
        }
    }
}
