namespace BankKingData.Entry;

public class EntryCategoryData
{
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public EntryType Type { get; set; }
}
