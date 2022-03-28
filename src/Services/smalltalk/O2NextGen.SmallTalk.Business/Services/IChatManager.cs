using O2NextGen.SmallTalk.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Business.Services
{
    public interface IChatManager
    {
        Task<ChatMessageModel> AddMessage(ChatMessageModel chatMessageModel);
        Task<IReadOnlyCollection<ChatMessageModel>> GetMessages();
    }
}
