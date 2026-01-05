using BankKingData.Entry;

namespace BankKingService;

public interface ICategoryService
{
    void Setup();

    List<EntryCategory> GetAllCategories();

    List<EntryCategory> GetExpenses();

    List<EntryCategory> GetIncomes();

    void AddCategory(EntryCategory category);
}
