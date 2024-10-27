using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Terminplaner.Service;
using Terminplaner.ViewModel;

namespace Terminplaner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// gets service provider for DI, allowing registered services
        /// and dbcontext to be accessed throughout the app
        /// </summary>
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            // Konfiguracja dostępu do danych
            ServiceLocator.ConfigureDataServices(services);

            services.AddTransient<TerminplanerVM>();

            // Rejestracja widoków i ViewModeli w głównym projekcie WPF
            services.AddSingleton<MainWindow>();
            

            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
