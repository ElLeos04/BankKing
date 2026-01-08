using BankKing.ViewModel.Form;

namespace BankKing.ViewModel.Utils;

public interface IDialogService
{
    bool ShowDialog(FormViewModel viewModel);
}
