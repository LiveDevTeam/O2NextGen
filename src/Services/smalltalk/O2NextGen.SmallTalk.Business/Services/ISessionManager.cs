using O2NextGen.SmallTalk.Business.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Api.Services
{
    public interface ISessionManager
    {
        Task<IReadOnlyCollection<ChatSessionModel>> GetAllAsync(CancellationToken ct);
        Task<ChatSessionModel> AddSessionAsync(ChatSessionModel chatSession, CancellationToken ct);
        Task<bool> ExistSessionAsync();
        Task<ChatSessionModel> GetSessionAsync();
        Task<IReadOnlyCollection<ChatMessageModel>> GetMessages(long idSession, CancellationToken ct);
        Task<ChatMessageModel> GetMessageByIdAsync(long idSession, long id, CancellationToken ct);
    }
}
