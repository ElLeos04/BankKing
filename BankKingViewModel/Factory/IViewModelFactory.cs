using BankKingService.Data;
using BankKingViewModel.Form;

namespace BankKingViewModel.Factory;

public interface IViewModelFactory
{
    AccountViewModel CreateAccountViewModel(BankAccountBO account, Action<AccountViewModel> action);

    AddTransactionViewModel CreateTransactionViewModel();
}
