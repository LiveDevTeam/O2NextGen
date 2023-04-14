using System.Collections.Generic;

namespace O2NextGen.Sdk.NetCore.Models.SmallTalk
{
    public class ChatSession
    {
        public long Id { get; set; }
        public int Agents { get; set; }
        public List<ChatMessage> Messages { get; set; }
        public List<ChatEvent> Events { get; set; }
        public List<ChatSessionInvite> Invites { get; set; }
        public string Name { get; set; }
    }
}