using BankKing.Data.Account;
using BankKing.Data.Entry;
using BankKing.ViewModel.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace BankKing.ViewModel;

public class AccountViewModel : BaseViewModel
{

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

    public double Balance
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


    public AccountViewModel(BankAccount account)
    {
        Account = account;

        Entries = [];
        foreach (AccountEntry entry in account.Entries)
        {
            Entries.Add(new HistoryEntryViewModel(entry));
        }

        GroupedEntries = CollectionViewSource.GetDefaultView(Entries);
        GroupedEntries.GroupDescriptions.Add(new PropertyGroupDescription("Date"));
    }

    // Mock constructor for design-time data
    public AccountViewModel() : this(MockAccount())
    {
    }

    private void AddTransaction(object param)
    {
        AccountEntry newEntry = new AccountEntry()
        {
            Amount = 0.0,
            Date = System.DateTime.Today,
            Category = new EntryCategory() { Name = "Nouvelle catégorie", Type = EntryType.Expense }
        };

        Account.Entries.Add(newEntry);
        Entries.Add(new HistoryEntryViewModel(newEntry));
    }

    private static BankAccount MockAccount()
    {
        var account = new BankAccount()
        {
            Name = "Compte courant",
            Balance = 1523.45,
            Entries = []
        };

        AccountEntry e1 = new AccountEntry()
        {
            Amount = -50.75,
            Date = System.DateTime.Today.AddDays(-2),
            Category = new EntryCategory() { Name = "Nourriture", Type = EntryType.Expense }
        };

        account.Entries.Add(e1);
        account.Entries.Add(new AccountEntry()
        {
            Amount = 2500.00,
            Date = System.DateTime.Today.AddDays(-2),
            Category = new EntryCategory() { Name = "Salaire", Type = EntryType.Income }
        });

        account.Entries.Add(new AccountEntry()
        {
            Amount = -150.00,
            Date = System.DateTime.Today.AddDays(-1),
            Category = new EntryCategory() { Name = "Impôts", Type = EntryType.Expense }
        });
        account.Entries.Add(new AccountEntry()
        {
            Amount = -23.40,
            Date = System.DateTime.Today.AddDays(-7),
            Category = new EntryCategory() { Name = "Nourriture", Type = EntryType.Expense }
        });


        return account;
    }
}
