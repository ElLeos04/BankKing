using BankKing.Interface;
using BankKing.ViewModel.Form;
using System.Windows;

namespace BankKing.Services;

public class DialogService : IDialogService
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
