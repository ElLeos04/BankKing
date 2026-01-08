namespace BankKingViewModel.Utils;

/// <summary>
/// Defines a service for displaying a modal dialog using a specified view aspect.
/// </summary>
/// <remarks>Implementations of this interface allow applications to present dialogs in a decoupled manner,
/// typically for user interaction or confirmation. The dialog is shown modally, blocking interaction with other windows
/// until it is closed.</remarks>
public interface IDialogService
{
    /// <summary>
    /// Displays a modal dialog for the specified view aspect and waits for the user to close it.
    /// </summary>
    /// <typeparam name="T">The type of the view aspect to display in the dialog.</typeparam>
    /// <param name="viewAspect">The view aspect to be shown in the dialog. Cannot be null.</param>
    /// <returns>true if the dialog was accepted by the user; otherwise, false.</returns>
    bool ShowDialog<T>(T viewAspect);
}
