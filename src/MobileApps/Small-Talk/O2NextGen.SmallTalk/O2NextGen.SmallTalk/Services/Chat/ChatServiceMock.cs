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

        public void GetMessagesAsync(long sessionId)
        {
            throw new NotImplementedException();
        }

        private ObservableCollection<ChatSession> _mockSessions = new ObservableCollection<ChatSession>
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

            return _mockSessions;
        }

        public void Sessions(long sessionId)
        {
            throw new NotImplementedException();
        }

        public async Task<ChatSession> GetSessionAsync()
        {
            await Task.Delay(10);

            return _mockSessions[0];
        }
        public async Task<ObservableCollection<ChatMessage>> GetMessageAsync()
        {
            await Task.Delay(10);

            return new ObservableCollection<ChatMessage>(_mockSessions[0].Messages);
        }

        public async Task<ChatMessage> AddMessageToSessionAsync(string message)
        {
            await Task.Delay(10);
            long index = _mockSessions.Count + 1;
            var addMessage = new ChatMessage() { Id = index, Message = message, SenderId = 1, RecipientId = 2 };
            _mockSessions[0].Messages.Add(addMessage);
            return addMessage;
        }
    }
}
