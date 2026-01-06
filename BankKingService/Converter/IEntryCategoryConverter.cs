using BankKingData.Entry;
using BankKingService.Data;

namespace BankKingService.Converter;

public interface IEntryCategoryConverter
{
    EntryCategoryBO DataToBO(EntryCategoryData data);

    EntryCategoryData BOToData(EntryCategoryBO bo);

    List<EntryCategoryData> BOListToDataList(List<EntryCategoryBO> boList);

    List<EntryCategoryBO> DataListToBOList(List<EntryCategoryData> dataList);
}
