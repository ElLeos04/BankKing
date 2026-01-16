using BankKingService;
using BankKingService.Data;
using BankKingViewModel.Form;
using BankKingViewModel.Utils;

namespace BankKingViewModel.Factory.Impl;

public class ViewModelFactory(IDialogService dialogService, ICategoryService categoryService, IAccountService accountService) : IViewModelFactory
{

    public AccountViewModel CreateAccountViewModel(BankAccountBO account, Action<AccountViewModel> action)
    {
        return new AccountViewModel(dialogService, this, accountService, account, action);
    }

    public HistoryEntryViewModel CreateHistoryEntryViewModel(AccountEntryBO entry, Action<HistoryEntryViewModel> deleteAction, Action<HistoryEntryViewModel, decimal> updateAction)
    {
        return new(entry, this, dialogService, deleteAction, updateAction);
    }

    public AddTransactionViewModel CreateTransactionViewModel()
    {
        return new AddTransactionViewModel(categoryService);
    }
}
