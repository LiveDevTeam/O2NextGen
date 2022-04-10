namespace O2NextGen.SmallTalk.Business.Models
{
    public class ChatMessageModel
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public long SenderId { get; set; }
        public long RecipientId { get; set; }
    }
}
