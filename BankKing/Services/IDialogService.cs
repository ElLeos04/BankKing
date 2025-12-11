using BankKing.ViewModel;

namespace BankKing.Services;

public interface IDialogService
{
    bool ShowDialog(FormViewModel viewModel);
}
