using BankKingData.Account;
using BankKing.Services;

namespace BankKing.ViewModel.Factory;

public class ViewModelFactory(IDialogService dialogService) : IViewModelFactory
{

    public AccountViewModel CreateAccountViewModel(BankAccount account)
    {
        return new AccountViewModel(dialogService, account);
    }
}
