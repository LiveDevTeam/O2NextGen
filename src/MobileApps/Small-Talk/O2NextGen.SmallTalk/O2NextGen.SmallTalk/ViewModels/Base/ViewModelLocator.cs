using O2NextGen.SmallTalk.Core.Services.Chat;
using O2NextGen.SmallTalk.Core.Services.RequestProvider;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace O2NextGen.SmallTalk.Core.ViewModels.Base
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; } = false;
        static ViewModelLocator()
        {
            //var settingsService = new SettingsService();
            var requestProvider = new RequestProvider();

            // Services - by default, TinyIoC will register interface registrations as singletons.
            // Xamarin.Forms.DependencyService.RegisterSingleton<IDependencyService>(new Services.Dependency.DependencyService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IRequestProvider>(requestProvider); 
            Xamarin.Forms.DependencyService.RegisterSingleton<IChatService>(new ChatServiceMock());

            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            Xamarin.Forms.DependencyService.Register<ChatViewModel>();
            Xamarin.Forms.DependencyService.Register<ChatDetailViewModel>();
            UseMockService = false;

        }

        public static void UpdateDependencies(bool useMockServices)
        {
            var requestProvider = DependencyService.Get<IRequestProvider>();
            // Change injected dependencies
            if (useMockServices)
            {
                
                Xamarin.Forms.DependencyService.RegisterSingleton<IChatService>(new ChatServiceMock());
                UseMockService = true;
            }
            else
            {
               
                Xamarin.Forms.DependencyService.RegisterSingleton<IChatService>(new ChatService(requestProvider));
                UseMockService = false;
            }
        }

        public static T Resolve<T>() where T : class
        {
            return Xamarin.Forms.DependencyService.Get<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }

            var viewModel = Activator.CreateInstance(viewModelType);

            view.BindingContext = viewModel;
        }
    }
}
