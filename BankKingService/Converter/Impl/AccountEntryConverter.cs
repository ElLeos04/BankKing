using BankKingData.Entry;
using BankKingService.Data;

namespace BankKingService.Converter.Impl;

public class AccountEntryConverter : IAccountEntryConverter
{
    public List<AccountEntryData> BOListToDataList(List<AccountEntryBO> boList)
    {
        return boList.ConvertAll(BOToData);
    }

    public AccountEntryData BOToData(AccountEntryBO bo)
    {
        return new AccountEntryData
        {
            Category = new EntryCategoryData
            {
                Name = bo.Category.Name,
                Type = bo.Category.Type
            },
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
        return new AccountEntryBO
        {
            Category = new EntryCategoryBO
            {
                Name = data.Category.Name,
                Type = data.Category.Type
            },
            Amount = data.Amount,
            Date = data.Date
        };
    }
}
