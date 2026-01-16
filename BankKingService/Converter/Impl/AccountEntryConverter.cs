using BankKingData.Entry;
using BankKingService.Data;

namespace BankKingService.Converter.Impl;

public class AccountEntryConverter(ICategoryService _categoryService) : IAccountEntryConverter
{
    public List<AccountEntryData> BOListToDataList(List<AccountEntryBO> boList)
    {
        return boList.ConvertAll(BOToData);
    }

    public AccountEntryData BOToData(AccountEntryBO bo)
    {
        return new AccountEntryData
        {
            CategoryId = bo.Category.Id,
            Amount = bo.Amount,
            Date = bo.Date
        };
    }

    public List<AccountEntryBO> DataListToBOList(List<AccountEntryData> dataList)
    {
        return dataList.ConvertAll(DataToBO);
    }

    public AccountEntryBO DataToBO(AccountEntryData data)
    {
        EntryCategoryBO category = _categoryService.GetCategory(data.CategoryId);

        return new AccountEntryBO
        {
            Category = category,
            Amount = data.Amount,
            Date = data.Date
        };
    }
}
