using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace BankKingWPF;

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
        Trace.WriteLine("Application Constructor");
        ServiceCollection services = new();

        // Register Services
        services.AddKeyedSingleton<BankKingData.IDataIO, BankKingData.Impl.XMLAccountIO>("BankAccount");
        services.AddKeyedSingleton<BankKingData.IDataIO, BankKingData.Impl.XMLCategoryIO>("Category");

        services.AddSingleton<BankKingService.IAccountService, BankKingService.Impl.AccountService>();
        services.AddSingleton<BankKingService.ICategoryService, BankKingService.Impl.CategoryService>();
        services.AddSingleton<BankKingViewModel.Utils.IDialogService, Utils.WPFDialogService>();

        // Register Factory
        services.AddSingleton<BankKingViewModel.Factory.IViewModelFactory, BankKingViewModel.Factory.Impl.ViewModelFactory>();

        // Register Converters
        services.AddSingleton<BankKingService.Converter.IEntryCategoryConverter, BankKingService.Converter.Impl.EntryCategoryConverter>();
        services.AddSingleton<BankKingService.Converter.IAccountEntryConverter, BankKingService.Converter.Impl.AccountEntryConverter>();
        services.AddSingleton<BankKingService.Converter.IBankAccountConverter, BankKingService.Converter.Impl.BankAccountConverter>();

        // Register ViewModel
        services.AddTransient<BankKingViewModel.MainWindowViewModel>();
        services.AddTransient<BankKingViewModel.Form.AddTransactionViewModel>();

        // Register Window
        services.AddSingleton<UI.MainWindow>();

        _serviceProvider = services.BuildServiceProvider();

        FrameworkElement.LanguageProperty.OverrideMetadata(
        typeof(FrameworkElement),
        new FrameworkPropertyMetadata(
            XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        Trace.WriteLine("Application Starting");

        _serviceProvider.GetService<BankKingService.ICategoryService>()!.Setup();

        var mainWindow = _serviceProvider.GetService<UI.MainWindow>();
        mainWindow!.DataContext = _serviceProvider.GetService<BankKingViewModel.MainWindowViewModel>();
        mainWindow!.Show();

        Trace.WriteLine("Application Started");

        base.OnStartup(e);
    }

    public new static App Current => (App) Application.Current;
}
