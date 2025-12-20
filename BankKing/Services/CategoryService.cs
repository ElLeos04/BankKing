using BankKing.Data.Entry;
using System.Linq;

namespace BankKing.Services;

public class CategoryService : ICategoryService
{
    private List<EntryCategory> _categories;

    public CategoryService()
    {
        _categories = [];
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
}
