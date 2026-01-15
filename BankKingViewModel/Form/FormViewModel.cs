using BankKingViewModel.Utils;
using System.Windows.Input;

namespace BankKingViewModel.Form;

public abstract class FormViewModel : BaseViewModel
{
    public Action<bool>? CloseRequested { get; set; }

    public bool DeleteTriggered { get; set; } = false;

    public ICommand AcceptCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand DeleteCommand { get; }

    public bool FormCanDelete { get; set; } = false;

    protected FormViewModel()
    {
        // TODO : Add validation logic before accepting (abstract method)
        AcceptCommand = new RelayCommand(p => CloseRequested?.Invoke(true));
        CancelCommand = new RelayCommand(p => CloseRequested?.Invoke(false));
        DeleteCommand = new RelayCommand(p =>
        {
            CloseRequested?.Invoke(false);
            DeleteTriggered = true;
        });
    }
}
