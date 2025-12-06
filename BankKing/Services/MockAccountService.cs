using BankKing.Data;
using BankKing.Data.Account;
using BankKing.Data.Entry;

namespace BankKing.Services;

public class MockAccountService : IAccountService
{
    private readonly IAccountIO _accountIO;

    public MockAccountService()
    {
        _accountIO = new XMLAccountIO();
    }


    public async void SaveAccounts(List<BankAccount> accounts)
    {
        foreach (BankAccount account in accounts)
        {
            _accountIO.SaveAccount(account);
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
        return _accountIO.GetAccounts();
    }
}
