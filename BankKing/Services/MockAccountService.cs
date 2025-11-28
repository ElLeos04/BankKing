using BankKing.Data.Account;
using BankKing.Data.Entry;
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
        DateTime now = DateTime.Now;


        EntryCategory cat1 = new()
        {
            Name = "Nourriture",
            Type = EntryType.Expense
        };

        List<AccountEntry> entries = [];
        entries.Add(new AccountEntry()
        {
            Category = cat1,
            Amount = -50.75,
            Date = now.AddDays(-2)
        });
        entries.Add(new AccountEntry()
        {
            Category = cat1,
            Amount = -23.40,
            Date = now.AddDays(-7)
        });

        EntryCategory cat2 = new()
        {
            Name = "Salaire",
            Type = EntryType.Income
        };

        entries.Add(new AccountEntry()
        {
            Category = cat2,
            Amount = 2500.00,
            Date = now.AddDays(-2)
        });

        EntryCategory cat3 = new()
        {
            Name = "Impôts",
            Type = EntryType.Expense
        };

        entries.Add(new AccountEntry()
        {
            Category = cat3,
            Amount = -150.00,
            Date = now.AddDays(-1)
        });


        // In a real application, this method would retrieve data from a database
        return new ObservableCollection<Account>([
            new() { Name = "Compte1", Balance = 1000, Entries = entries },
            new() { Name = "Compte2", Balance = 3272.12 },
            new() { Name = "Compte3", Balance = 56.75 },
            new() { Name = "Compte4", Balance = 56.75 },
            new() { Name = "Compte5", Balance = 56.75 },
            new() { Name = "Compte6", Balance = 56.75 },
        ])
        ;

    }
}
