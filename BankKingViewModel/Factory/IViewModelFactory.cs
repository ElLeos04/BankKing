using BankKingService.Data;

namespace BankKingViewModel.Factory;

public interface IViewModelFactory
{
    AccountViewModel CreateAccountViewModel(BankAccountBO account);
}
