using BankKingService.Data;
using BankKingViewModel.Utils;

namespace BankKingViewModel.Factory.Impl;

public class ViewModelFactory(IDialogService<BaseViewModel> dialogService) : IViewModelFactory
{

    public AccountViewModel CreateAccountViewModel(BankAccountBO account)
    {
        return new AccountViewModel(dialogService, account);
    }
}
