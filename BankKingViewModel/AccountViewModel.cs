using BankKingData.Entry;
using BankKingService;
using BankKingService.Data;
using BankKingViewModel.Factory;
using BankKingViewModel.Form;
using BankKingViewModel.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BankKingViewModel;

public class AccountViewModel : BaseViewModel
{
    private readonly IDialogService _dialogService;

    private readonly IViewModelFactory _viewModelFactory;

    private readonly IAccountService _accountService;

    private readonly Action<AccountViewModel> _onAccountRemoved;

    public BankAccountBO Account
    {
        get;
        private set;
    }

    public string Name
    {
        get => Account.Name;
        set
        {
            Account.Name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public decimal Balance
    {
        get => Account.Balance;
        set
        {
            Account.Balance = value;
            OnPropertyChanged(nameof(BalanceText));
        }
    }

    public string BalanceText => Balance.ToString("C2");

    private readonly List<HistoryEntryViewModel> rawEntries = [];

    public ObservableCollection<GroupedEntry<HistoryEntryViewModel>> Entries { get; private set; } = [];

    public ICommand AddTransactionCommand => new RelayCommand(AddTransaction);

    public ICommand ModifyAccountCommand => new RelayCommand(ModifyAccount);

    public ICommand RemoveAccountCommand => new RelayCommand(RemoveAccount);


    public AccountViewModel(IDialogService dialogService, IViewModelFactory viewModelFactory, IAccountService accountService, BankAccountBO account, Action<AccountViewModel> onAccountRemoved)
    {
        _dialogService = dialogService;
        _viewModelFactory = viewModelFactory;
        _accountService = accountService;
        _onAccountRemoved = onAccountRemoved;
        Account = account;

        InitializeEntries();
    }

    // Mock constructor for design-time data
    public AccountViewModel()
    {
        Account = MockAccount();
        InitializeEntries();
    }

    private void AddTransaction(object param)
    {
        AddTransactionViewModel addTransactionVM = _viewModelFactory.CreateTransactionViewModel();

        bool result = _dialogService.ShowDialog(addTransactionVM!);

        if (result)
        {
            AccountEntryBO newEntry = new()
            {
                Amount = addTransactionVM!.Amount,
                Date = addTransactionVM.Date!.Value,
                Category = addTransactionVM.Category!
            };

            Account.Entries.Add(newEntry);
            HistoryEntryViewModel historyEntryVM = _viewModelFactory.CreateHistoryEntryViewModel(newEntry, DeleteEntry, OnEntryModified);
            rawEntries.Add(historyEntryVM);

            ComputeBalanceChange(newEntry);
            RefreshEntries();
        }
    }

    private void ModifyAccount(object param)
    {
        AddAccountViewModel modifyAccountVM = new()
        {
            AccountTitle = Account.Name,
            InitialBalance = Account.Balance
        };
        bool result = _dialogService.ShowDialog(modifyAccountVM!);

        if (result)
        {
            if (modifyAccountVM!.AccountTitle != Account.Name)
            {
                _accountService.RenameAccount(Account, modifyAccountVM.AccountTitle);
            }

            Account.Name = modifyAccountVM!.AccountTitle;
            Account.Balance = modifyAccountVM.InitialBalance;

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(BalanceText));
        }
    }

    private void RemoveAccount(object param)
    {
        string prompt = "Vous allez supprimer le compte. Êtes-vous sûr ?";

        ConfirmationFormViewModel confirmationVM = new()
        {
            Message = prompt
        };

        if (_dialogService.ShowDialog(confirmationVM))
        {
            _onAccountRemoved.Invoke(this);
            _accountService.DeleteAccount(Account);
        }
    }

    private void ComputeBalanceChange(AccountEntryBO entry)
    {
        Account.Balance += entry.Amount;

        OnPropertyChanged(nameof(BalanceText));
    }

    private void InitializeEntries()
    {
        foreach (AccountEntryBO entry in Account.Entries)
        {
            rawEntries.Add(_viewModelFactory.CreateHistoryEntryViewModel(entry, DeleteEntry, OnEntryModified));
        }

        RefreshEntries();
    }

    private void RefreshEntries()
    {
        var groups = rawEntries
        .GroupBy(x => x.Date)
        .Select(g => new GroupedEntry<HistoryEntryViewModel>(g.Key, g))
        .OrderByDescending(g => g.Key)
        .ToList();

        Entries = new(groups);

        OnPropertyChanged(nameof(Entries));
    }

    private void DeleteEntry(HistoryEntryViewModel entryVM)
    {
        ConfirmationFormViewModel confirmationVM = new()
        {
            Message = "Vous allez supprimer cette entrée. Êtes-vous sûr ?"
        };

        if (_dialogService.ShowDialog(confirmationVM))
        {
            Account.Entries.Remove(entryVM.AccountEntry);
            rawEntries.Remove(entryVM);

            Account.Balance -= entryVM.AccountEntry.Amount;
            OnPropertyChanged(nameof(BalanceText));
            RefreshEntries();
        }
    }

    // TODO : Callback à la modif d'une entrée pour Update Labels (et referesh ordre de la liste)
    private void OnEntryModified(HistoryEntryViewModel entryVM, decimal newAmount)
    {
        decimal amountDiff = newAmount - entryVM.AccountEntry.Amount;
        Account.Balance += amountDiff;
        OnPropertyChanged(nameof(BalanceText));
        RefreshEntries();
    }

    private static BankAccountBO MockAccount()
    {
        var account = new BankAccountBO()
        {
            Name = "Compte courant",
            Balance = 1523.45m,
            Entries = []
        };

        AccountEntryBO e1 = new AccountEntryBO()
        {
            Amount = -50.75m,
            Date = System.DateTime.Today.AddDays(-2),
            Category = new EntryCategoryBO() { Name = "Nourriture", Type = EntryType.Expense }
        };

        account.Entries.Add(e1);
        account.Entries.Add(new AccountEntryBO()
        {
            Amount = 2500.00m,
            Date = System.DateTime.Today.AddDays(-2),
            Category = new EntryCategoryBO() { Name = "Salaire", Type = EntryType.Income }
        });

        account.Entries.Add(new AccountEntryBO()
        {
            Amount = -150.00m,
            Date = System.DateTime.Today.AddDays(-1),
            Category = new EntryCategoryBO() { Name = "Impôts", Type = EntryType.Expense }
        });
        account.Entries.Add(new AccountEntryBO()
        {
            Amount = -23.40m,
            Date = System.DateTime.Today.AddDays(-7),
            Category = new EntryCategoryBO() { Name = "Nourriture", Type = EntryType.Expense }
        });


        return account;
    }
}
