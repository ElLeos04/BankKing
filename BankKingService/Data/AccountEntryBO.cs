namespace BankKingService.Data;

public class AccountEntryBO
{
    public required EntryCategoryBO Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
