using System.Collections.Generic;
using System.Windows;

namespace BankKing.Interface.Components.Form;

/// <summary>
/// Logique d'interaction pour InputComboBox.xaml
/// </summary>
public partial class InputComboBox : InputComponent
{
    public InputComboBox()
    {
        InitializeComponent();
    }


    public List<object> InputList
    {
        get { return (List<object>) GetValue(InputListProperty); }
        set { SetValue(InputListProperty, value); }
    }

    // Using a DependencyProperty as the backing store for InputList.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty InputListProperty =
        DependencyProperty.Register(nameof(InputList), typeof(List<object>), typeof(InputComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


}
