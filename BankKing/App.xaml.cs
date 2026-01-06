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
        private readonly IServiceProvider _serviceProvider;
        public IServiceProvider Services
        {
            get => _serviceProvider;
        }

        public App()
        {
            ServiceCollection services = new();

            // Register Services
            services.AddSingleton<BankKingData.ICategoryIO, BankKingData.Impl.CategoryIO>();
            services.AddSingleton<BankKingData.IAccountIO, BankKingData.Impl.XMLAccountIO>();

            services.AddSingleton<BankKingService.IAccountService, BankKingService.Impl.AccountService>();
            services.AddSingleton<BankKingService.ICategoryService, BankKingService.Impl.CategoryService>();
            services.AddSingleton<ViewModel.Utils.IDialogService, ViewModel.Utils.DialogService>();

            // Register Factory
            services.AddSingleton<ViewModel.Factory.IViewModelFactory, ViewModel.Factory.ViewModelFactory>();

            // Register Converters
            services.AddSingleton<BankKingService.Converter.IEntryCategoryConverter, BankKingService.Converter.Impl.EntryCategoryConverter>();
            services.AddSingleton<BankKingService.Converter.IAccountEntryConverter, BankKingService.Converter.Impl.AccountEntryConverter>();
            services.AddSingleton<BankKingService.Converter.IBankAccountConverter, BankKingService.Converter.Impl.BankAccountConverter>();

            // Register ViewModel
            services.AddTransient<ViewModel.MainWindowViewModel>();
            services.AddTransient<ViewModel.Form.AddTransactionViewModel>();

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
            _serviceProvider.GetService<BankKingService.ICategoryService>()!.Setup();

            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow!.DataContext = _serviceProvider.GetService<ViewModel.MainWindowViewModel>();
            mainWindow!.Show();

            base.OnStartup(e);
        }

        public new static App Current => (App) Application.Current;
    }

}
