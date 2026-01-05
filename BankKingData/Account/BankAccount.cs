using BankKingData.Entry;

namespace BankKingData.Account;

public class BankAccount
{
    public required string Name { get; set; }
    public decimal Balance { get; set; }
    public List<AccountEntry> Entries { get; set; }

    public BankAccount()
    {
        Entries = [];
    }
}
