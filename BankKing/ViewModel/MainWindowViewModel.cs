using BankKing.Data.Account;
using BankKing.Services;
using BankKing.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace BankKing.ViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Account>? Accounts
    {
        get;
        set;
    }

    public ICommand LoadDataCommand { get; set; }


    private readonly IAccountService _accountService;

    public MainWindowViewModel(IAccountService accountService)
    {
        _accountService = accountService;
        LoadDataCommand = new RelayCommand(LoadData);
    }

    // For design-time data
    public MainWindowViewModel()
    {
        _accountService = new MockAccountService();
        LoadDataCommand = new RelayCommand(LoadData);
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


    private void LoadData(object obj)
    {
        Accounts = _accountService.GetAccounts();
    }
}
