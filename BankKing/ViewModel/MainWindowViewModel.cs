using BankKing.Data.Account;
using BankKing.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace BankKing.ViewModel;

public class MainWindowViewModel(IAccountService accountService) : INotifyPropertyChanged
{
    private ObservableCollection<Account>? Accounts
    {
        get;
        set;
    }

    private IAccountService _accountService = accountService;

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
