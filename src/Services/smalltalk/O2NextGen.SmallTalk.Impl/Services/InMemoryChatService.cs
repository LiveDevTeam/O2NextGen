using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using O2NextGen.SmallTalk.Business.Models;
using O2NextGen.SmallTalk.Business.Services;

namespace O2NextGen.SmallTalk.Impl.Services
{

    public class InMemoryChatService : IChatService
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
                        Message = "First massage",
                        SenderId = 1,
                        RecipientId = 2,
                    }
                }
            }
        };
        private long _currentId;

        #endregion


        #region Ctors

        public InMemoryChatService()
        {
            _currentId = Sessions.Count();
        }

        #endregion


        #region Methods
        public async Task<IReadOnlyCollection<ChatSessionModel>> GetAllAsync(CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult<IReadOnlyCollection<ChatSessionModel>>(Sessions.AsReadOnly());
        }

        public async Task<ChatSessionModel> GetByIdAsync(long id, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult(Sessions.SingleOrDefault(g => g.Id == id));
        }

        public async Task<ChatSessionModel> UpdateAsync(ChatSessionModel certificate, CancellationToken ct)
        {
            await Task.Delay(5000, ct);
            var toUpdate = Sessions.SingleOrDefault(g => g.Id == certificate.Id);
            if (toUpdate == null)
                return null;

            toUpdate.Messages = certificate.Messages;

            return await Task.FromResult(toUpdate);
        }

        public async Task<ChatSessionModel> AddAsync(ChatSessionModel certificate, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            certificate.Id = ++_currentId;
            Sessions.Add(certificate);
            return await Task.FromResult(certificate);
        }

        public Task RemoveAsync(long id, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
