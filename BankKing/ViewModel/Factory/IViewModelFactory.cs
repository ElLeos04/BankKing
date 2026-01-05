using BankKingData.Account;

namespace BankKing.ViewModel.Factory;

public interface IViewModelFactory
{
    AccountViewModel CreateAccountViewModel(BankAccountData account);
}
