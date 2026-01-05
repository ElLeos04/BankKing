using BankKingData;
using BankKingData.Entry;

namespace BankKingService;

public class CategoryService(ICategoryIO categoryIO) : ICategoryService
{
    private List<EntryCategory> _categories = [];

    public void Setup()
    {
        _categories = categoryIO.GetCategories();
    }

    public List<EntryCategory> GetAllCategories()
    {
        return _categories;
    }

    public List<EntryCategory> GetExpenses()
    {
        var expenses = from category in _categories
                       where category.Type == EntryType.Expense || category.Type == EntryType.ExpenseAndIncome
                       select category;

        return [.. expenses];
    }

    public List<EntryCategory> GetIncomes()
    {
        var incomes = from category in _categories
                      where category.Type == EntryType.Income || category.Type == EntryType.ExpenseAndIncome
                      select category;

        return [.. incomes];
    }

    public void AddCategory(EntryCategory category)
    {
        _categories.Add(category);

        categoryIO.SaveCategories(_categories);
    }
}
