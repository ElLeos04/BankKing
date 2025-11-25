using BankKing.Services;
using BankKing.ViewModel.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace BankKing.ViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private ObservableCollection<AccountViewModel> Accounts
    {
        get;
        set;
    }

    public ICommand LoadDataCommand { get; set; }


    private readonly IAccountService _accountService;

    public MainWindowViewModel(IAccountService accountService)
    {
        _accountService = accountService;

        LoadDataCommand = new RelayCommand(LoadData);
        Accounts = [];
    }

    // For design-time data
    public MainWindowViewModel() : this(new MockAccountService())
    {
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


    private void LoadData(object obj)
    {
        var accounts = _accountService.GetAccounts();

        foreach (var account in accounts)
        {
            Accounts.Add(new(account));
        }
    }
}
