namespace BankKingData.Entry;

public class AccountEntryData
{
    public required EntryCategoryData Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
