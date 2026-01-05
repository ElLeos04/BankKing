using BankKingData.Account;
using System.Collections.ObjectModel;

namespace BankKing.Services
{
    public interface IAccountService
    {
        List<BankAccount> GetAccounts();
        void RenameAccount(BankAccount account, string newName);
        void SaveAccounts(List<BankAccount> accounts);
    }
}