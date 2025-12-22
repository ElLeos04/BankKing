using BankKing.Data.Account;

namespace BankKing.ViewModel.Factory;

public interface IViewModelFactory
{
    AccountViewModel CreateAccountViewModel(BankAccount account);
}
