using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Api.Services
{
    public class InMemoryChatService : IChatService
    {
        #region Fields

        private static readonly List<ChatSession> Sessions = new List<ChatSession>()
        {
            new ChatSession()
            {
                Id = 1, Name = "First"
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
        public async Task<IReadOnlyCollection<ChatSession>> GetAllAsync(CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult<IReadOnlyCollection<ChatSession>>(Sessions.AsReadOnly());
        }

        public async Task<ChatSession> GetByIdAsync(long id, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult(Sessions.SingleOrDefault(g => g.Id == id));
        }

        public async Task<ChatSession> UpdateAsync(ChatSession certificate, CancellationToken ct)
        {
            await Task.Delay(5000, ct);
            var toUpdate = Sessions.SingleOrDefault(g => g.Id == certificate.Id);
            if (toUpdate == null)
                return null;

            toUpdate.Name = certificate.Name;

            return await Task.FromResult(toUpdate);
        }

        public async Task<ChatSession> AddAsync(ChatSession certificate, CancellationToken ct)
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
