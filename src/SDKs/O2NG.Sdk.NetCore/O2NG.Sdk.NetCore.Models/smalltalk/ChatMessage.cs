﻿namespace O2NextGen.Sdk.NetCore.Models.SmallTalk
{
    public class ChatMessage
    {
        public long Id { get; set; }
        public long SenderId { get; set; }
        public long RecipientId { get; set; }
        public string Message { get; set; }
    }
}