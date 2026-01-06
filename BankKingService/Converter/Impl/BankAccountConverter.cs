using BankKingData.Account;
using BankKingService.Data;

namespace BankKingService.Converter.Impl;

public class BankAccountConverter(IAccountEntryConverter accountEntryConverter) : IBankAccountConverter
{
    public List<BankAccountData> BOListToDataList(List<BankAccountBO> boList)
    {
        return boList.ConvertAll(BOToData);
    }

    public BankAccountData BOToData(BankAccountBO bo)
    {
        return new BankAccountData
        {
            Name = bo.Name,
            Balance = bo.Balance,
            Entries = bo.Entries != null ? accountEntryConverter.BOListToDataList(bo.Entries) : []
        };
    }

    public List<BankAccountBO> DataListToBOList(List<BankAccountData> dataList)
    {
        return dataList.ConvertAll(DataToBO);
    }

    public BankAccountBO DataToBO(BankAccountData data)
    {
        return new BankAccountBO
        {
            Name = data.Name,
            Balance = data.Balance,
            Entries = data.Entries != null ? accountEntryConverter.DataListToBOList(data.Entries) : []
        };
    }
}
