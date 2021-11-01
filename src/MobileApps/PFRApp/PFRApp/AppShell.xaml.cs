using System;
using System.Collections.Generic;
using PFRApp.ViewModels;
using PFRApp.Views;
using Xamarin.Forms;

namespace PFRApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
