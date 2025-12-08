using BankKing.Data.Account;
using BankKing.Services;
using BankKing.ViewModel.Utils;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace BankKing.ViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public ObservableCollection<AccountViewModel> Accounts
    {
        get;
        private set;
    }

    public ICommand LoadDataCommand => new RelayCommand(LoadData);

    public ICommand SaveDataCommand => new RelayCommand(SaveData);

    public ICommand AddAccountCommand => new RelayCommand(AddAccount);

    private readonly IAccountService _accountService;

    public MainWindowViewModel(IAccountService accountService)
    {
        _accountService = accountService;

        Accounts = [];
    }

    // For design-time data
    public MainWindowViewModel() : this(new AccountService())
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

    private void SaveData(object obj)
    {
        List<BankAccount> accounts = [];
        foreach (var accountVM in Accounts)
        {
            accounts.Add(accountVM.Account);
        }
        _accountService.SaveAccounts(accounts);
    }

    private void AddAccount(object obj)
    {
        // For demo purposes, we create a mock account
        BankAccount newAccount = new() { Name = "Compte" + Random.Shared.Next(), Balance = 50 };

        Accounts.Add(new AccountViewModel(newAccount));
        OnPropertyChanged(nameof(Accounts));
    }
}
