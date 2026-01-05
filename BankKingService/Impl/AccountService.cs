using BankKingData;
using BankKingData.Account;

namespace BankKingService.Impl;

public class AccountService(IAccountIO accountIO) : IAccountService
{
    public async void SaveAccounts(List<BankAccount> accounts)
    {
        foreach (BankAccount account in accounts)
        {
            accountIO.SaveAccount(account);
        }
    }

    public async void RenameAccount(BankAccount account, string newName)
    {
        // In a real application, this method would update data in a database
        await Task.Delay(500); // Simulate async work
        account.Name = newName;
    }

    public List<BankAccount> GetAccounts()
    {
        return accountIO.GetAccounts();
    }
}
