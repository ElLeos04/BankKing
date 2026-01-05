using BankKingData.Entry;

namespace BankKingService;

public interface ICategoryService
{
    void Setup();

    List<EntryCategoryData> GetAllCategories();

    List<EntryCategoryData> GetExpenses();

    List<EntryCategoryData> GetIncomes();

    void AddCategory(EntryCategoryData category);
}
