using BankKingData.Entry;

namespace BankKingData;

public  interface ICategoryIO
{
    void SaveCategories(List<EntryCategory> categories);

    List<EntryCategory> GetCategories();
}
