using BankKing.Data.Entry;

namespace BankKing.Data;

public  interface ICategoryIO
{
    void SaveCategories(List<EntryCategory> categories);

    List<EntryCategory> GetCategories();
}
