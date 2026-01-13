using BankKingData;
using BankKingData.Account;
using BankKingService.Converter;
using BankKingService.Data;

namespace BankKingService.Impl;

public class AccountService(IAccountIO accountIO, IBankAccountConverter accountConverter) : IAccountService
{
    public void SaveAccounts(List<BankAccountBO> accounts)
    {
        List<BankAccountData> accountsData = accountConverter.BOListToDataList(accounts);

        foreach (BankAccountData account in accountsData)
        {
            accountIO.SaveAccount(account);
        }
    }

    public void RenameAccount(BankAccountBO account, string newName)
    {
        accountIO.RenameAccount(account.Name, newName);
    }

    public List<BankAccountBO> GetAccounts()
    {
        List<BankAccountData> accountsData = accountIO.GetAccounts();
        return accountConverter.DataListToBOList(accountsData);
    }

    public void DeleteAccount(BankAccountBO account)
    {
        accountIO.DeleteAccount(account.Name);
    }
}
