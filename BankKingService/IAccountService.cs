using BankKingData.Account;

namespace BankKingService;

public interface IAccountService
{
    List<BankAccount> GetAccounts();
    void RenameAccount(BankAccount account, string newName);
    void SaveAccounts(List<BankAccount> accounts);
}