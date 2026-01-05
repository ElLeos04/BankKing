using BankKingData.Account;

namespace BankKingService;

public interface IAccountService
{
    List<BankAccountData> GetAccounts();
    void RenameAccount(BankAccountData account, string newName);
    void SaveAccounts(List<BankAccountData> accounts);
}