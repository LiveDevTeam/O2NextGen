using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using O2NextGen.SmallTalk.Business.Models;

namespace O2NextGen.SmallTalk.Business.Services
{
    public interface IChatService
    {
        Task<IReadOnlyCollection<ChatSessionModel>> GetAllAsync(CancellationToken ct);
        Task<ChatSessionModel> GetByIdAsync(long id, CancellationToken ct);
        Task<ChatSessionModel> UpdateAsync(ChatSessionModel certificate, CancellationToken ct);
        Task<ChatSessionModel> AddAsync(ChatSessionModel certificate, CancellationToken ct);
        Task RemoveAsync(long id, CancellationToken ct);
    }
}
