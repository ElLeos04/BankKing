namespace BankKingData.Entry;

public class AccountEntry
{
    public required EntryCategory Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
