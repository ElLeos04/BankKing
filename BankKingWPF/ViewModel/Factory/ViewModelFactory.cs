using BankKingData.Account;
using BankKing.ViewModel.Utils;

namespace BankKing.ViewModel.Factory;

public class ViewModelFactory(IDialogService dialogService) : IViewModelFactory
{

    public AccountViewModel CreateAccountViewModel(BankAccountData account)
    {
        return new AccountViewModel(dialogService, account);
    }
}
