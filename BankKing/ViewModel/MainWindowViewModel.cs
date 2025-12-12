using BankKing.Data.Account;
using BankKing.Services;
using BankKing.ViewModel.Form;
using BankKing.ViewModel.Utils;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace BankKing.ViewModel;

public class MainWindowViewModel(IAccountService _accountService, IDialogService _dialogService) : BaseViewModel
{
    public ObservableCollection<AccountViewModel> Accounts
    {
        get;
        private set;
    } = [];

    public ICommand LoadDataCommand => new RelayCommand(LoadData);

    public ICommand SaveDataCommand => new RelayCommand(SaveData);

    public ICommand AddAccountCommand => new RelayCommand(AddAccount);

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
        AddAccountViewModel addAccountVM = new();

        bool result = _dialogService.ShowDialog(addAccountVM);

        if (result)
        {
            BankAccount newAccount = new()
            {
                Name = addAccountVM.AccountTitle,
                Balance = addAccountVM.InitialBalance,
                Entries = []
            };

            Accounts.Add(new AccountViewModel(newAccount));
            OnPropertyChanged(nameof(Accounts));
        }
    }
}
