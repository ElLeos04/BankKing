using BankKingData;
using BankKingData.Entry;

namespace BankKingService.Impl;

public class CategoryService(ICategoryIO categoryIO) : ICategoryService
{
    private List<EntryCategoryData> _categories = [];

    public void Setup()
    {
        _categories = categoryIO.GetCategories();
    }

    public List<EntryCategoryData> GetAllCategories()
    {
        return _categories;
    }

    public List<EntryCategoryData> GetExpenses()
    {
        var expenses = from category in _categories
                       where category.Type == EntryType.Expense || category.Type == EntryType.ExpenseAndIncome
                       select category;

        return [.. expenses];
    }

    public List<EntryCategoryData> GetIncomes()
    {
        var incomes = from category in _categories
                      where category.Type == EntryType.Income || category.Type == EntryType.ExpenseAndIncome
                      select category;

        return [.. incomes];
    }

    public void AddCategory(EntryCategoryData category)
    {
        _categories.Add(category);

        categoryIO.SaveCategories(_categories);
    }
}
