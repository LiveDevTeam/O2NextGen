using O2NextGen.SmallTalk.Business.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Api.Services
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
