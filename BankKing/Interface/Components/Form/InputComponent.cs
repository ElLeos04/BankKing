using System.Windows;
using System.Windows.Controls;

namespace BankKing.Interface.Components.Form;

public class InputComponent : UserControl
{
    public string InputName
    {
        get { return (string) GetValue(InputNameProperty); }
        set { SetValue(InputNameProperty, value); }
    }

    public static readonly DependencyProperty InputNameProperty =
        DependencyProperty.Register(nameof(InputName), typeof(string), typeof(InputComponent), new PropertyMetadata("Field Name"));

}
