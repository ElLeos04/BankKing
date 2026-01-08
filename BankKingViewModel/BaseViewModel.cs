using System.ComponentModel;

namespace BankKingViewModel;

public abstract class BaseViewModel : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
