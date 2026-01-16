namespace BankKingData.Entry;

public class AccountEntryData
{
    public required int CategoryId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
