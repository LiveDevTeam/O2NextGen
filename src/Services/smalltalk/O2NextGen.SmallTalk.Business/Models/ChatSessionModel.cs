using System.Collections.Generic;

namespace O2NextGen.SmallTalk.Business.Models
{
    public class ChatSessionModel
    {
        public long Id { get; set; }
        public List<ChatEventModel> Events { get; set; }
        public List<ChatMessageModel> Messages { get; set; }
        public List<ChatSessionInviteModel> Invites { get; set; }
    }
}
