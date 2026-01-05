using BankKingData.Entry;

namespace BankKing.Services;

public interface ICategoryService
{
    void Setup();

    List<EntryCategory> GetAllCategories();

    List<EntryCategory> GetExpenses();

    List<EntryCategory> GetIncomes();

    void AddCategory(EntryCategory category);
}
