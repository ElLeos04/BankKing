using BankKingViewModel.Form;
using BankKingViewModel.Utils;
using System.Windows;

namespace BankKingWpfUI.Utils;

/// <summary>
/// Provides functionality to display a modal dialog window for a specified form.
/// </summary>
public class DialogService : IDialogService<FormViewModel>
{
    public bool ShowDialog(FormViewModel viewModel)
    {
        Window window = new FormWindow()
        {
            DataContext = viewModel
        };

        viewModel.CloseRequested += (result) =>
        {
            window.DialogResult = result;
            window.Close();
        };

        return window.ShowDialog() ?? false;
    }
}
