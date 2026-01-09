namespace BankKingViewModel.Utils;

/// <summary>
/// Defines a service for displaying a modal dialog. Used for dependency injection.
/// </summary>
/// <remarks>Implementations of this interface allow applications to present dialogs in a decoupled manner,
/// typically for user interaction or confirmation. The dialog is shown modally, blocking interaction with other windows
/// until it is closed.</remarks>
public interface IDialogService
{
    /// <summary>
    /// Displays a modal dialog for the specified view aspect and waits for the user to close it.
    /// </summary>
    /// <param name="viewAspect">The object view aspect linked</param>
    /// <returns>true if the dialog was accepted by the user; otherwise, false.</returns>
    bool ShowDialog(object viewAspect);
}



/// <summary>
/// Typed version of IDialogService for a specific view type. Should hold the concrete implementation of ShowDialog.
/// </summary>
/// <typeparam name="TView">Type of the view used by the platform</typeparam>
public interface IDialogService<TView> : IDialogService
{
    // The specific method from your original question
    bool ShowDialog(TView view);
}