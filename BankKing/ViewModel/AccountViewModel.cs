using BankKing.Data.Account;
using BankKing.Data.Entry;
using System.ComponentModel;

namespace BankKing.ViewModel;

public class AccountViewModel(Account account) : INotifyPropertyChanged
{

    private Account _account = account;

    public string Name
    {
        get => _account.Name;
        set
        {
            _account.Name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public double Balance
    {
        get => _account.Balance;
        set
        {
            _account.Balance = value;
            OnPropertyChanged(nameof(BalanceText));
        }
    }

    public string BalanceText => Balance.ToString("C2");

    public List<AccountEntry> Entries
    {
        get => _account.Entries;
        set
        {
            _account.Entries = value;
            OnPropertyChanged(nameof(Entries));
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    // Mock constructor for design-time data
    public AccountViewModel() : this(new Account() { Name = "Mock Account", Balance = 0.0, Entries = new List<AccountEntry>() })
    {
    }
}
