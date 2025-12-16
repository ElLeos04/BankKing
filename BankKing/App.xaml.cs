using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace BankKing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new();

            // Register Services
            services.AddSingleton<Services.IAccountService, Services.AccountService>();
            services.AddSingleton<Services.IDialogService, Services.DialogService>();

            // Register Factory
            services.AddSingleton<ViewModel.Factory.IViewModelFactory, ViewModel.Factory.ViewModelFactory>();

            // Register ViewModel
            services.AddTransient<ViewModel.MainWindowViewModel>();

            // Register Window
            services.AddSingleton<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();

            FrameworkElement.LanguageProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(
                XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
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
