﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using O2NextGen.SmallTalk.Business.Models;

namespace O2NextGen.SmallTalk.Business.Services
{
    public interface ISessionManager
    {
        Task<IReadOnlyCollection<ChatSessionModel>> GetAllAsync(CancellationToken ct);
        Task<ChatSessionModel> AddSessionAsync(ChatSessionModel chatSession, CancellationToken ct);
        Task<bool> ExistSessionAsync(long sessionId, CancellationToken ct);
        Task<ChatSessionModel> GetSessionAsync(long sessionId, CancellationToken ct);
        Task<IReadOnlyCollection<ChatMessageModel>> GetMessages(long idSession, CancellationToken ct);
        Task<ChatMessageModel> GetMessageByIdAsync(long idSession, long id, CancellationToken ct);
    }
}
