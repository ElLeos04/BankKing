using BankKingData.Entry;
using BankKingService;

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

    private EntryCategoryData? _category;
    public EntryCategoryData? Category
    {
        get => _category;
        set
        {
            _category = value;
            OnPropertyChanged(nameof(Category));
        }
    }

    public List<EntryCategoryData> DisplayedCategories => GetDisplayedCategories();


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

    private DateTime? _date = DateTime.Today;
    public DateTime? Date
    {
        get => _date;
        set
        {
            _date = value;
            OnPropertyChanged(nameof(Date));
        }
    }

    private List<EntryCategoryData> GetDisplayedCategories()
    {
        return TransactionType switch
        {
            EntryType.Expense => categoryService.GetExpenses(),
            EntryType.Income => categoryService.GetIncomes(),
            _ => categoryService.GetAllCategories(),
        };
    }
}
