using System.Windows;

namespace BankKingWPF.UI.Components.Form;

/// <summary>
/// Logique d'interaction pour InputComponent.xaml
/// </summary>
public partial class InputTextComponent : InputComponent
{
    public InputTextComponent()
    {
        InitializeComponent();
    }


    public string InputText
    {
        get { return (string) GetValue(InputTextProperty); }
        set { SetValue(InputTextProperty, value); }
    }

    public static readonly DependencyProperty InputTextProperty =
        DependencyProperty.Register(nameof(InputText), typeof(string), typeof(InputTextComponent), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


}
