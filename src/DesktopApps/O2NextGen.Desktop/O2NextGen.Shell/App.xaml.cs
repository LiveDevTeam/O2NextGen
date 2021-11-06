using System.Windows;
using O2NextGen.Shell.ViewModels;

namespace O2NextGen.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow window = new MainWindow()
            {
                DataContext = new CertificateViewModel()
            };
            
            window.ShowDialog();
        }
    }
}
