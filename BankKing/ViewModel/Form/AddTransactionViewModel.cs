using BankKing.Data.Entry;

namespace BankKing.ViewModel.Form;

public class AddTransactionViewModel : FormViewModel
{
    private EntryType _transactionType;
    public EntryType TransactionType
    {
        get => _transactionType;
        set
        {
            _transactionType = value;
            OnPropertyChanged(nameof(TransactionType));
        }
    }

    private EntryCategory? _category;
    public EntryCategory? Category
    {
        get => _category;
        set
        {
            _category = value;
            OnPropertyChanged(nameof(Category));
        }
    }

    private decimal _amount = 0m;
    public decimal Amount
    {
        get => _amount;
        set
        {
            _amount = value;
            OnPropertyChanged(nameof(Amount));
        }
    }

    private DateTime? _date;
    public DateTime? Date
    {
        get => _date;
        set
        {
            _date = value;
            OnPropertyChanged(nameof(Date));
        }
    }
}
