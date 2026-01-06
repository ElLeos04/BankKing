using BankKingData.Account;
using BankKingService.Data;

namespace BankKingService.Converter;

public interface IBankAccountConverter
{
    BankAccountBO DataToBO(BankAccountData data);

    BankAccountData BOToData(BankAccountBO bo);

    List<BankAccountData> BOListToDataList(List<BankAccountBO> boList);

    List<BankAccountBO> DataListToBOList(List<BankAccountData> dataList);
}
