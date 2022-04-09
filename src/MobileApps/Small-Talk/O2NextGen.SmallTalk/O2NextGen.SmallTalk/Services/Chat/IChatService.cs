using O2NextGen.Sdk.NetCore.Models.smalltalk;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Core.Services.Chat
{
    public interface IChatService
    {
        void GetByIdMessage(long sessionId, long id);
        void GetMessagesAsync(long sessionId);
        void Sessions(long sessionId);
        Task<ObservableCollection<ChatSession>> GetSessionsAsync();
        Task<ChatSession> GetSessionAsync();
        Task<ObservableCollection<ChatMessage>> GetMessageAsync();
        Task<ChatMessage> AddMessageToSessionAsync(string message);
    }
}
