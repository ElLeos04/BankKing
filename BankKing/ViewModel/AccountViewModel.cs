using BankKing.Data.Account;
using BankKing.Data.Entry;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace BankKing.ViewModel;

public class AccountViewModel : INotifyPropertyChanged
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

    public ObservableCollection<HistoryEntryViewModel> Entries { get; private set; }

    public ICollectionView GroupedEntries { get; private set; }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

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
