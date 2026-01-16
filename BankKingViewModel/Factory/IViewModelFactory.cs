using BankKingService.Data;
using BankKingViewModel.Form;

namespace BankKingViewModel.Factory;

public interface IViewModelFactory
{
    AccountViewModel CreateAccountViewModel(BankAccountBO account, Action<AccountViewModel> action);

    HistoryEntryViewModel CreateHistoryEntryViewModel(AccountEntryBO entry, Action<HistoryEntryViewModel> deleteAction, Action<HistoryEntryViewModel, decimal> updateAction);

    AddTransactionViewModel CreateTransactionViewModel();
}
