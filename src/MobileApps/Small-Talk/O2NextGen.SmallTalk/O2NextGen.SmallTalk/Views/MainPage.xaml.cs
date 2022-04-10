using O2NextGen.SmallTalk.Core.ViewModels;
using Xamarin.Forms;

namespace O2NextGen.SmallTalk.Core.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new ChatViewModel();
        }
    }
}
