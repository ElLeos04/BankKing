using BankKingViewModel.Form;
using BankKingViewModel.Utils;
using BankKingWPF.UI;
using System.Windows;

namespace BankKingWPF.Utils;

public class WPFDialogService : IDialogService<FormViewModel>
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

    public bool ShowDialog(object viewAspect)
    {
        if (viewAspect is FormViewModel formViewModel)
        {
            return ShowDialog(formViewModel);
        }

        throw new ArgumentException("Unsupported view aspect type", nameof(viewAspect));
    }

    public bool ShowDialogWithDelete(object viewAspect)
    {
        if (viewAspect is FormViewModel formViewModel)
        {
            formViewModel.FormCanDelete = true;
            return ShowDialog(formViewModel);
        }

        throw new ArgumentException("Unsupported view aspect type", nameof(viewAspect));
    }
}
