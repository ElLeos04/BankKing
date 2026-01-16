using BankKingService.Data;

namespace BankKingService;

public interface ICategoryService
{
    void Setup();

    List<EntryCategoryBO> GetAllCategories();

    List<EntryCategoryBO> GetExpenses();

    List<EntryCategoryBO> GetIncomes();

    void AddCategory(EntryCategoryBO category);

    EntryCategoryBO GetCategory(int id);
}
