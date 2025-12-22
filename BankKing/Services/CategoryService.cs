using BankKing.Data.Entry;
using System.Linq;

namespace BankKing.Services;

public class CategoryService : ICategoryService
{
    private List<EntryCategory> _categories;

    public CategoryService()
    {
        _categories = [
            new () {
                Name = "Nourriture",
                Type = EntryType.Expense
            },
            new () {
                Name = "Salaire",
                Type = EntryType.Income
            },
            new(){
                Name = "Loisirs",
                Type = EntryType.Expense
            }

            ];
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

        // TODO : Persist to file
    }
}
