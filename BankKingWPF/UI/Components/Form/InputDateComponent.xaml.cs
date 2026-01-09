using System.Windows;

namespace BankKingWPF.UI.Components.Form;

/// <summary>
/// Logique d'interaction pour InputDate.xaml
/// </summary>
public partial class InputDateComponent : InputComponent
{
    public InputDateComponent()
    {
        InitializeComponent();
    }


    public DateTime InputDate
    {
        get { return (DateTime) GetValue(InputDateProperty); }
        set { SetValue(InputDateProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Date.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty InputDateProperty =
        DependencyProperty.Register(nameof(InputDate), typeof(DateTime), typeof(InputDateComponent), new FrameworkPropertyMetadata(DateTime.Today, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


}
