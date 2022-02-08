using PFRApp.Application;

namespace PFRApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel();
        }
    }
}
