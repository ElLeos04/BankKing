using BankKingData.Entry;

namespace BankKingData.Account;

public class BankAccountData
{
    public required string Name { get; set; }
    public decimal Balance { get; set; }
    public required List<AccountEntryData> Entries { get; set; }

}
