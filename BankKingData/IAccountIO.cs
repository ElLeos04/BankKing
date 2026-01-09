using BankKingData.Account;

namespace BankKingData;

public interface IAccountIO
{
    void SaveAccount(BankAccountData account);

    List<BankAccountData> GetAccounts();
}
