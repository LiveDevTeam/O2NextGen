using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PFRApp.Application
{
    public class AppShellViewModel
    {
       public ICommand SignOutCommand { get => new Command(async () => await SignOut()); }

        private async Task SignOut()
        {
            await Shell.Current.DisplayAlert("todo","You have been logged out","ok");
        }
    }
}

