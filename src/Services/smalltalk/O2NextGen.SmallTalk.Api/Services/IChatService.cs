using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Api.Services
{
    public interface IChatService
    {
        Task<IReadOnlyCollection<ChatSession>> GetAllAsync(CancellationToken ct);
        Task<ChatSession> GetByIdAsync(long id, CancellationToken ct);
        Task<ChatSession> UpdateAsync(ChatSession certificate, CancellationToken ct);
        Task<ChatSession> AddAsync(ChatSession certificate, CancellationToken ct);
        Task RemoveAsync(long id, CancellationToken ct);
    }
}
