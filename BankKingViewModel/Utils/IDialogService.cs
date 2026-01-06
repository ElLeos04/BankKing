namespace BankKingViewModel.Utils;

/// <summary>
/// Defines a service for displaying a modal dialog using a specified view aspect.
/// </summary>
/// <remarks>Implementations of this interface allow applications to present dialogs in a decoupled manner,
/// typically for user interaction or confirmation. The dialog is shown modally, blocking interaction with other windows
/// until it is closed.</remarks>
/// <typeparam name="T">The type that represents the view aspect or content to be displayed in the dialog. Specific to each display app.</typeparam>
public interface IDialogService<T>
{
    bool ShowDialog(T viewAspect);
}
