using BankKingService;
using BankKingService.Data;
using BankKingViewModel.Form;
using BankKingViewModel.Utils;

namespace BankKingViewModel.Factory.Impl;

public class ViewModelFactory(IDialogService dialogService, ICategoryService categoryService) : IViewModelFactory
{

    public AccountViewModel CreateAccountViewModel(BankAccountBO account)
    {
        return new AccountViewModel(dialogService, this, account);
    }

    public AddTransactionViewModel CreateTransactionViewModel()
    {
        return new AddTransactionViewModel(categoryService);
    }
}
