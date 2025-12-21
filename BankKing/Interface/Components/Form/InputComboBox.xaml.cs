using System.Collections;
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


    public IEnumerable InputList
    {
        get { return (List<object>) GetValue(InputListProperty); }
        set { SetValue(InputListProperty, value); }
    }

    public object SelectedInput
    {
        get { return (object) GetValue(SelectedInputProperty); }
        set { SetValue(SelectedInputProperty, value); }
    }


    public static readonly DependencyProperty InputListProperty =
        DependencyProperty.Register(nameof(InputList), typeof(IEnumerable), typeof(InputComboBox), new FrameworkPropertyMetadata(null));

    public static readonly DependencyProperty SelectedInputProperty =
        DependencyProperty.Register(nameof(SelectedInput), typeof(object), typeof(InputComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



}
