
using BankKingData.Entry;
using BankKingService.Data;

namespace BankKingService.Converter.Impl;

public class EntryCategoryConverter : IEntryCategoryConverter
{
    public List<EntryCategoryData> BOListToDataList(List<EntryCategoryBO> boList)
    {
        return boList.ConvertAll(BOToData);
    }

    public EntryCategoryData BOToData(EntryCategoryBO bo)
    {
        return new EntryCategoryData
        {
            CategoryId = bo.Id,
            Name = bo.Name,
            Type = bo.Type
        };
    }

    public List<EntryCategoryBO> DataListToBOList(List<EntryCategoryData> dataList)
    {
        return dataList.ConvertAll(DataToBO);
    }

    public EntryCategoryBO DataToBO(EntryCategoryData data)
    {
        return new EntryCategoryBO
        {
            Id = data.CategoryId,
            Name = data.Name,
            Type = data.Type
        };
    }
}
