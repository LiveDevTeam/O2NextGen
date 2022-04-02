using O2NextGen.SmallTalk.Business.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Business.Services
{
    public interface IChatManager
    {
        Task<ChatMessageModel> AddMessage(ChatMessageModel chatMessageModel, CancellationToken ct);
        Task<IReadOnlyCollection<ChatMessageModel>> GetMessages(long idSession, CancellationToken ct);
        Task RemoveMessageAsync(long id, CancellationToken ct);
        Task<ChatMessageModel> UpdateMessageAsync(ChatMessageModel chatMessageModel, CancellationToken ct);
        Task<ChatMessageModel> GetMessageByIdAsync(long id, long id1, CancellationToken ct);
    }
}
