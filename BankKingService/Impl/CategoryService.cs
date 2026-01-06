using BankKingData;
using BankKingData.Entry;
using BankKingService.Data;

namespace BankKingService.Impl;

public class CategoryService(ICategoryIO categoryIO) : ICategoryService
{
    private List<EntryCategoryBO> _categories = [];

    public void Setup()
    {
        List<EntryCategoryData> categoriesData = categoryIO.GetCategories();

    }

    public List<EntryCategoryBO> GetAllCategories()
    {
        return _categories;
    }

    public List<EntryCategoryBO> GetExpenses()
    {
        var expenses = from category in _categories
                       where category.Type == EntryType.Expense || category.Type == EntryType.ExpenseAndIncome
                       select category;

        return [.. expenses];
    }

    public List<EntryCategoryBO> GetIncomes()
    {
        var incomes = from category in _categories
                      where category.Type == EntryType.Income || category.Type == EntryType.ExpenseAndIncome
                      select category;

        return [.. incomes];
    }

    public void AddCategory(EntryCategoryBO category)
    {
        _categories.Add(category);

        categoryIO.SaveCategories(_categories);
    }
}
