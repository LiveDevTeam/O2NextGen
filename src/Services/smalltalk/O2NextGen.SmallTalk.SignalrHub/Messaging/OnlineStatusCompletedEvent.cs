namespace O2NextGen.SmallTalk.SignalrHub.Messaging
{
    public class OnlineStatusCompletedEvent
    {
        private string UserId { get; }

        public OnlineStatusCompletedEvent(string userId)
        {
            UserId = userId;
        }
    }
}