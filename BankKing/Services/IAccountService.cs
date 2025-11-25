using BankKing.Data.Account;
using System.Collections.ObjectModel;

namespace BankKing.Services
{
    public interface IAccountService
    {
        ObservableCollection<Account> GetAccounts();
        void RenameAccount(Account account, string newName);
        void SaveAccounts(List<Account> accounts);
    }
}