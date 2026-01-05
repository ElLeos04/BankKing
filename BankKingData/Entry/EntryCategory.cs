namespace BankKingData.Entry;

public class EntryCategory
{
    public required string Name { get; set; }
    public EntryType Type { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
