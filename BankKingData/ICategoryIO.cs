using BankKingData.Entry;

namespace BankKingData;

public  interface ICategoryIO
{
    void SaveCategories(List<EntryCategoryData> categories);

    List<EntryCategoryData> GetCategories();
}
