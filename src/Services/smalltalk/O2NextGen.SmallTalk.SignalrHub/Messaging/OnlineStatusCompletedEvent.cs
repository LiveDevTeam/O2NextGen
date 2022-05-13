namespace O2NextGen.Common
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