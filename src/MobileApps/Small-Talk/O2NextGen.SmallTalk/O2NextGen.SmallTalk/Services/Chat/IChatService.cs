namespace O2NextGen.SmallTalk.Core.Services.Chat
{
    interface IChatService
    {
        void GetByIdMessage(long sessionId, long id);
        void GetMessages(long sessionId);
        void Sessions(long sessionId);

    }
}
