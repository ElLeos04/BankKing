using BankKingService.Data;

namespace BankKingService;

public interface IAccountService
{
    List<BankAccountBO> GetAccounts();

    void RenameAccount(BankAccountBO account, string newName);

    void SaveAccounts(List<BankAccountBO> accounts);

    void DeleteAccount(BankAccountBO account);
}
