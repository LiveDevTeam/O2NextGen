using O2NextGen.Sdk.NetCore.Models.smalltalk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace O2NextGen.SmallTalk.Core.Services.Chat
{
    public class ChatServiceMock : IChatService
    {
        public void GetByIdMessage(long sessionId, long id)
        {
            throw new NotImplementedException();
        }

        public void GetMessages(long sessionId)
        {
            throw new NotImplementedException();
        }

        private ObservableCollection<ChatSession> MockSessions = new ObservableCollection<ChatSession>
        {
            new ChatSession() {
                Id = 1,
                Messages=new List<ChatMessage>()
                {
                    new ChatMessage()
                    {
                            Id = 1,
                            Message = "Tests",
                            SenderId = 1,
                            RecipientId = 2
                    },
                        new ChatMessage()
                    {
                            Id = 2,
                            Message = "Tests 2",
                            SenderId = 1,
                            RecipientId = 2
                    },
                        new ChatMessage()
                    {
                            Id = 2,
                            Message = "Tests 2 sender",
                            SenderId = 2,
                            RecipientId = 1
                    }
                }
            },
            new ChatSession() {
                Id = 2,
                Messages=new List<ChatMessage>()
                {
                    new ChatMessage()
                    {
                            Id = 1,
                            Message = "Tests",
                            SenderId = 1,
                            RecipientId = 2
                    },
                        new ChatMessage()
                    {
                            Id = 2,
                            Message = "Tests 2",
                            SenderId = 1,
                            RecipientId = 2
                    },
                        new ChatMessage()
                    {
                            Id = 2,
                            Message = "Tests 2 sender",
                            SenderId = 2,
                            RecipientId = 1
                    }
                }
            }
        };

        public async Task<ObservableCollection<ChatSession>> GetSessionsAsync()
        {
            await Task.Delay(10);

            return MockSessions;
        }

        public void Sessions(long sessionId)
        {
            throw new NotImplementedException();
        }

        public async Task<ChatSession> GetSessionAsync()
        {
            await Task.Delay(10);

            return MockSessions[0];
        }
        public async Task<ObservableCollection<ChatMessage>> GetMessageAsync()
        {
            await Task.Delay(10);

            return new ObservableCollection<ChatMessage>(MockSessions[0].Messages);
        }

        public async Task AddMessageToSessionAsync(string message)
        {
            await Task.Delay(10);
            long index = MockSessions.Count+1;
            MockSessions[0].Messages.Add(new ChatMessage() { Id = index,Message=message,SenderId=1,RecipientId=2 });
        }
    }
}
