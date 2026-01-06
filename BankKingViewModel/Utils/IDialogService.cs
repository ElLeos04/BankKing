namespace BankKingViewModel.Utils;

public interface IDialogService<T>
{
    bool ShowDialog(T viewAspect);
}
