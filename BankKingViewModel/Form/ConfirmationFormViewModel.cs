namespace BankKingViewModel.Form;

public class ConfirmationFormViewModel : FormViewModel
{

    private string _message = "";
    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged(nameof(Message));
        }
    }
}
