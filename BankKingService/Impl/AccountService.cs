using BankKingData;
using BankKingData.Account;

namespace BankKingService.Impl;

public class AccountService(IAccountIO accountIO) : IAccountService
{
    public async void SaveAccounts(List<BankAccountData> accounts)
    {
        foreach (BankAccountData account in accounts)
        {
            accountIO.SaveAccount(account);
        }
    }

    public async void RenameAccount(BankAccountData account, string newName)
    {
        // In a real application, this method would update data in a database
        await Task.Delay(500); // Simulate async work
        account.Name = newName;
    }

    public List<BankAccountData> GetAccounts()
    {
        return accountIO.GetAccounts();
    }
}
