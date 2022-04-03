using O2NextGen.SmallTalk.Core.Services.Chat;
using O2NextGen.SmallTalk.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using O2NextGen.Sdk.NetCore.Models.smalltalk;

namespace O2NextGen.SmallTalk.Core.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {

        #region Fields
        private IChatService _chatService;
        private ObservableCollection<ChatSession> sessions;

        #endregion

        #region Props
        public ObservableCollection<ChatSession> Sessions
        {
            get => sessions;
            private set
            {
                sessions = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Ctors
        public ChatViewModel()
        {
            this.MultipleInitialization = true;
            Sessions = new ObservableCollection<ChatSession>();
            _chatService = DependencyService.Get<IChatService>();
        }


        #endregion

        #region Methods
        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            Sessions = await _chatService.GetSessionsAsync();
            IsBusy = false;
        }
        #endregion
    }
}
