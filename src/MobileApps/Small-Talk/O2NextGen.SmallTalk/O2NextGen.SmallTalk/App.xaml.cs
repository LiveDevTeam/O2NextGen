using O2NextGen.SmallTalk.Core.ViewModels.Base;
using O2NextGen.SmallTalk.Core.Views;
using Xamarin.Forms;

namespace O2NextGen.SmallTalk
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitApp();
            MainPage = new ChatDetailView();
        }
        private void InitApp()
        {
            //_settingsService = ViewModelLocator.Resolve<ISettingsService>();
            //if (!_settingsService.UseMocks)
                ViewModelLocator.UpdateDependencies(true);
        }
    }
}
