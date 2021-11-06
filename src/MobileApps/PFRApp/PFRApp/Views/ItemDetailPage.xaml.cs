using System.ComponentModel;
using Xamarin.Forms;
using PFRApp.ViewModels;

namespace PFRApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
