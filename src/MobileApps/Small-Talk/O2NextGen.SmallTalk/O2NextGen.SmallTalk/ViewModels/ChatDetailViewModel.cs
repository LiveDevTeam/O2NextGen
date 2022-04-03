using O2NextGen.Sdk.NetCore.Models.smalltalk;
using O2NextGen.SmallTalk.Core.Services.Chat;
using O2NextGen.SmallTalk.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace O2NextGen.SmallTalk.Core.ViewModels
{
    public class ChatDetailViewModel : ViewModelBase
    {
        #region Fields
        private IChatService _chatService;
        private ChatSession session;
        private ObservableCollection<ChatMessage> messages;
        #endregion


        #region Props

        #endregion


        #region Ctors
        public ChatDetailViewModel()
        {
            this.MultipleInitialization = true;
            _chatService = DependencyService.Get<IChatService>();
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
        #endregion


        #region Methods
        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            Session = await _chatService.GetSessionAsync();
            Messages = await _chatService.GetMessageAsync();
            IsBusy = false;
        }
        #endregion
    }
}
