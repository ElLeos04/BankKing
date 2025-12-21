using BankKing.Data.Entry;
using BankKing.Services;
using System.Diagnostics;

namespace BankKing.ViewModel.Form;

public class AddTransactionViewModel(ICategoryService categoryService) : FormViewModel
{
    private EntryType _transactionType = EntryType.ExpenseAndIncome;
    public EntryType TransactionType
    {
        get => _transactionType;
        set
        {
            _transactionType = value;
            OnPropertyChanged(nameof(TransactionType));
            OnPropertyChanged(nameof(DisplayedCategories));
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

    public List<EntryCategory> DisplayedCategories => GetDisplayedCategories();


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

    private List<EntryCategory> GetDisplayedCategories()
    {
        return TransactionType switch
        {
            EntryType.Expense => categoryService.GetExpenses(),
            EntryType.Income => categoryService.GetIncomes(),
            _ => categoryService.GetAllCategories(),
        };
    }
}
