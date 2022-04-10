using Microsoft.AspNetCore.SignalR.Client;
using O2NextGen.Sdk.NetCore.Models.smalltalk;
using O2NextGen.SmallTalk.Core.Services.Chat;
using O2NextGen.SmallTalk.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace O2NextGen.SmallTalk.Core.ViewModels
{
    public class ChatDetailViewModel : ViewModelBase
    {
        #region Fields
        private IChatService _chatService;
        private ChatSession session;
        private ObservableCollection<ChatMessage> messages;
        private string message;

        #endregion

        #region Commands
        public ICommand SendMsgCommand { get; private set; }

        private readonly HubConnection hubConnection;
        #endregion

        #region Props

        #endregion


        #region Ctors
        public ChatDetailViewModel()
        {
            this.MultipleInitialization = true;
            _chatService = DependencyService.Get<IChatService>();
            SendMsgCommand = new Command(async (item) => await SendMsgAsync());

            hubConnection = new HubConnectionBuilder()
                 .WithUrl(GlobalSetting.Instance.HubConnectionURL)
                 .Build();

            hubConnection.On("OnUpdateMessage", async () =>
            {
                Console.WriteLine("TestMessage");
                await RelaodData();
            });


        }

        public ChatSession Session
        {
            get => session;
            private set
            {
                session = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ChatMessage> Messages
        {
            get => messages; private set
            {
                messages = value;
                RaisePropertyChanged();
            }
        }
        public string Message
        {
            get => message; set
            {
                message = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region Methods
        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
           
           
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("NewUserAsync","Denis");

        }

        private async Task SendMsgAsync()
        {
            await AddMessageAsync();
            Message = string.Empty;
            RaisePropertyChanged(() => Messages);
            await RelaodData();
        }

        private async Task RelaodData()
        {
            IsBusy = true;
            //Session = await _chatService.GetSessionAsync();
            Messages = await _chatService.GetMessageAsync();
            IsBusy = false;
        }

        private async Task AddMessageAsync()
        {
            await _chatService.AddMessageToSessionAsync(Message);
        }
        #endregion
    }
}
