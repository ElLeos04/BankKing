using BankKingData.Entry;

namespace BankKingService.Data;

public class EntryCategoryBO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public EntryType Type { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
