using BankKing.Data.Account;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BankKing.Services;

public class MockAccountService : IAccountService
{

    public async void SaveAccounts(List<Account> accounts)
    {
        // In a real application, this method would save data to a database
        await Task.Delay(1000); // Simulate async work
    }

    public async void RenameAccount(Account account, string newName)
    {
        // In a real application, this method would update data in a database
        await Task.Delay(500); // Simulate async work
        account.Name = newName;
    }

    public ObservableCollection<Account> GetAccounts()
    {
        // In a real application, this method would retrieve data from a database
        return new ObservableCollection<Account>([
            new() { Name = "Compte1", Balance = 1000 },
            new() { Name = "Compte2", Balance = 3272.12 },
            new() { Name = "Compte3", Balance = 56.75 },
        ])
        ;

    }
}
