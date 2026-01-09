using BankKingViewModel.Utils;
using System.Windows.Input;

namespace BankKingViewModel.Form;

public abstract class FormViewModel : BaseViewModel
{
    public Action<bool>? CloseRequested { get; set; }

    public ICommand AcceptCommand { get; }
    public ICommand CancelCommand { get; }

    protected FormViewModel()
    {
        // TODO : Add validation logic before accepting (abstract method)
        AcceptCommand = new RelayCommand(p => CloseRequested?.Invoke(true));
        CancelCommand = new RelayCommand(p => CloseRequested?.Invoke(false));
    }
}
