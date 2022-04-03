using O2NextGen.SmallTalk.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace O2NextGen.SmallTalk.Core.Views
{
    public partial class ChatView : ContentPageBase
    {
        public ChatView()
        {
            InitializeComponent();
            //this.BindingContext = new ChatViewModel();
        }
    }
}