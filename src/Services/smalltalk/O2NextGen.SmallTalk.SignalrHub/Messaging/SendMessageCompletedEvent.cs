namespace O2NextGen.Common
{
    public class SendMessageCompletedEvent
    {
        private string SenderId { get; set; }
        public string RecipientId { get; set; }

        public SendMessageCompletedEvent(string userId, string recipientId)
        {
            SenderId = userId;
            RecipientId = recipientId;
        }
    }
}