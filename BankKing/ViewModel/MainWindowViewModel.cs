using BankKingData.Account;
using BankKingData.Entry;
using BankKingService;
using BankKing.ViewModel.Factory;
using BankKing.ViewModel.Form;
using BankKing.ViewModel.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BankKing.ViewModel;

public class MainWindowViewModel(IAccountService _accountService, IDialogService _dialogService, ICategoryService _categoryService, IViewModelFactory _vmFactory) : BaseViewModel
{
    public ObservableCollection<AccountViewModel> Accounts
    {
        get;
        private set;
    } = [];

    public ICommand LoadDataCommand => new RelayCommand(LoadData);

    public ICommand SaveDataCommand => new RelayCommand(SaveData);

    public ICommand AddAccountCommand => new RelayCommand(AddAccount);

    public ICommand AddCategoryCommand => new RelayCommand(AddCategory);

    private void LoadData(object obj)
    {
        var accounts = _accountService.GetAccounts();

        foreach (var account in accounts)
        {
            Accounts.Add(_vmFactory.CreateAccountViewModel(account));
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

            Accounts.Add(_vmFactory.CreateAccountViewModel(newAccount));
            OnPropertyChanged(nameof(Accounts));
        }
    }

    private void AddCategory(object obj)
    {
        AddCategoryViewModel addCategoryVM = new();
        bool result = _dialogService.ShowDialog(addCategoryVM);
        if (result)
        {
            EntryCategory newCategory = new()
            {
                Name = addCategoryVM.CategoryName,
                Type = addCategoryVM.Type
            };

            _categoryService.AddCategory(newCategory);
        }
    }
}
