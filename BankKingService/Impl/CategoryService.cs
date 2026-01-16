using BankKingData;
using BankKingData.Entry;
using BankKingService.Converter;
using BankKingService.Data;

namespace BankKingService.Impl;

public class CategoryService(ICategoryIO categoryIO, IEntryCategoryConverter categoryConverter) : ICategoryService
{
    private List<EntryCategoryBO> _categories = [];

    private int nextId;

    public void Setup()
    {
        List<EntryCategoryData> categoriesData = categoryIO.GetCategories();
        _categories = categoryConverter.DataListToBOList(categoriesData);
        nextId = _categories.Count > 0 ? _categories.Max(category => category.Id) + 1 : 1;
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
        category.Id = nextId;
        nextId++;

        List<EntryCategoryData> categoriesData = categoryConverter.BOListToDataList(_categories);
        categoryIO.SaveCategories(categoriesData);
    }

    public EntryCategoryBO GetCategory(int id)
    {
        return _categories.First(category => category.Id == id);
    }
}
