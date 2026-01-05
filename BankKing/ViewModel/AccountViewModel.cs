using BankKingData.Account;
using BankKingData.Entry;
using BankKing.Services;
using BankKing.ViewModel.Form;
using BankKing.ViewModel.Utils;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace BankKing.ViewModel;

public class AccountViewModel : BaseViewModel
{
    private readonly IDialogService _dialogService;

    public BankAccount Account
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

    private ObservableCollection<HistoryEntryViewModel> Entries { get; set; }

    public ICollectionView GroupedEntries { get; private set; }

    public ICommand AddTransactionCommand => new RelayCommand(AddTransaction);


    public AccountViewModel(IDialogService dialog, BankAccount account)
    {
        _dialogService = dialog;
        Account = account;

        Entries = [];
        foreach (AccountEntry entry in account.Entries)
        {
            Entries.Add(new HistoryEntryViewModel(entry));
        }

        GroupedEntries = CollectionViewSource.GetDefaultView(Entries);
        GroupedEntries.GroupDescriptions.Add(new PropertyGroupDescription("DateText"));
        GroupedEntries.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));
    }

    // Mock constructor for design-time data
    public AccountViewModel() : this(null, MockAccount())
    {
    }

    private void AddTransaction(object param)
    {
        AddTransactionViewModel? addTransactionVM = App.Current.Services.GetService<AddTransactionViewModel>();
        bool result = _dialogService.ShowDialog(addTransactionVM!);

        if (result)
        {
            AccountEntry newEntry = new()
            {
                Amount = addTransactionVM!.Amount,
                Date = addTransactionVM.Date!.Value,
                Category = addTransactionVM.Category!
            };

            Account.Entries.Add(newEntry);
            Entries.Add(new HistoryEntryViewModel(newEntry));

            ComputeBalanceChange(newEntry);
        }
    }

    private void ComputeBalanceChange(AccountEntry entry)
    {
        Account.Balance += entry.Amount;


        OnPropertyChanged(nameof(BalanceText));
    }

    private static BankAccount MockAccount()
    {
        var account = new BankAccount()
        {
            Name = "Compte courant",
            Balance = 1523.45m,
            Entries = []
        };

        AccountEntry e1 = new AccountEntry()
        {
            Amount = -50.75m,
            Date = System.DateTime.Today.AddDays(-2),
            Category = new EntryCategory() { Name = "Nourriture", Type = EntryType.Expense }
        };

        account.Entries.Add(e1);
        account.Entries.Add(new AccountEntry()
        {
            Amount = 2500.00m,
            Date = System.DateTime.Today.AddDays(-2),
            Category = new EntryCategory() { Name = "Salaire", Type = EntryType.Income }
        });

        account.Entries.Add(new AccountEntry()
        {
            Amount = -150.00m,
            Date = System.DateTime.Today.AddDays(-1),
            Category = new EntryCategory() { Name = "Impôts", Type = EntryType.Expense }
        });
        account.Entries.Add(new AccountEntry()
        {
            Amount = -23.40m,
            Date = System.DateTime.Today.AddDays(-7),
            Category = new EntryCategory() { Name = "Nourriture", Type = EntryType.Expense }
        });


        return account;
    }
}
