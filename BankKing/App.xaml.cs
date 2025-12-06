using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BankKing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new();

            // Register Services
            services.AddSingleton<Services.IAccountService, Services.AccountService>();

            // Register ViewModel
            services.AddTransient<ViewModel.MainWindowViewModel>();

            // Register Window
            services.AddSingleton<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow!.DataContext = _serviceProvider.GetService<ViewModel.MainWindowViewModel>();
            mainWindow!.Show();

            base.OnStartup(e);
        }
    }

}
