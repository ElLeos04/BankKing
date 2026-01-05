using BankKingData.Account;

namespace BankKingData;

public interface IAccountIO
{
    void SaveAccount(BankAccount account);

    List<BankAccount> GetAccounts();
}
