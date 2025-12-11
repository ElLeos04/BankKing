using BankKing.ViewModel.Form;

namespace BankKing.Services;

public interface IDialogService
{
    bool ShowDialog(FormViewModel viewModel);
}
