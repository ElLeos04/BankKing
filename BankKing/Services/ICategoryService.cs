using BankKing.Data.Entry;

namespace BankKing.Services;

public interface ICategoryService
{
    List<EntryCategory> GetAllCategories();

    List<EntryCategory> GetExpenses();

    List<EntryCategory> GetIncomes();

    void AddCategory(EntryCategory category);
}
