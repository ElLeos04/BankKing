using System.Diagnostics;

namespace BankKing.ViewModel.Form;

public class AddAccountViewModel : FormViewModel
{
    private string _accountTitle = "";
    public string AccountTitle
    {
        get => _accountTitle;
        set
        {
            _accountTitle = value;
            OnPropertyChanged(nameof(AccountTitle));
        }
    }

    private decimal _initialBalance = 0m;
    public decimal InitialBalance
    {
        get => _initialBalance;
        set
        {
            _initialBalance = value;
            OnPropertyChanged(nameof(InitialBalance));
        }
    }
}
