using BankKingService;
using BankKingService.Data;
using BankKingViewModel.Factory;
using BankKingViewModel.Form;
using BankKingViewModel.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BankKingViewModel;

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
            Accounts.Add(_vmFactory.CreateAccountViewModel(account, (vm) => Accounts.Remove(vm)));
        }
    }

    private void SaveData(object obj)
    {
        List<BankAccountBO> accounts = [];
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
            BankAccountBO newAccount = new()
            {
                Name = addAccountVM.AccountTitle,
                Balance = addAccountVM.InitialBalance,
                Entries = []
            };

            Accounts.Add(_vmFactory.CreateAccountViewModel(newAccount, (vm) => Accounts.Remove(vm)));
            OnPropertyChanged(nameof(Accounts));
        }
    }

    private void AddCategory(object obj)
    {
        AddCategoryViewModel addCategoryVM = new();
        bool result = _dialogService.ShowDialog(addCategoryVM);
        if (result)
        {
            EntryCategoryBO newCategory = new()
            {
                Name = addCategoryVM.CategoryName,
                Type = addCategoryVM.Type
            };

            _categoryService.AddCategory(newCategory);
        }
    }
}
