namespace BankKingService.Data;

public class BankAccountBO
{
    public required string Name { get; set; }
    public decimal Balance { get; set; }

    public List<AccountEntryBO> Entries { get; set; }

    public BankAccountBO()
    {
        Entries = [];
    }
}
