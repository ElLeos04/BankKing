using BankKingData.Entry;
using BankKingService.Data;

namespace BankKingService.Converter;

public interface IAccountEntryConverter
{
    AccountEntryBO DataToBO(AccountEntryData data);
 
    AccountEntryData BOToData(AccountEntryBO bo);
    
    List<AccountEntryData> BOListToDataList(List<AccountEntryBO> boList);
    
    List<AccountEntryBO> DataListToBOList(List<AccountEntryData> dataList);
}
