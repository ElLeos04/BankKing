
using BankKing.ViewModel.Utils;
using System.Windows.Input;

namespace BankKing.ViewModel.Form
{
    public abstract class FormViewModel : BaseViewModel
    {
        public Action<bool>? CloseRequested { get; set; }

        public ICommand AcceptCommand { get; }
        public ICommand CancelCommand { get; }

        protected FormViewModel()
        {
            AcceptCommand = new RelayCommand(p => CloseRequested?.Invoke(true));
            CancelCommand = new RelayCommand(p => CloseRequested?.Invoke(false));
        }
    }


}
