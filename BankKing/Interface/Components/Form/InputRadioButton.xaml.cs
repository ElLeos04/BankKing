using System.Windows;
using System.Windows.Controls;

namespace BankKing.Interface.Components.Form;

/// <summary>
/// Logique d'interaction pour InputRadioButton.xaml
/// </summary>
public partial class InputRadioButton : InputComponent
{
    public InputRadioButton()
    {
        InitializeComponent();
    }

    public object SelectedValue
    {
        get { return (object) GetValue(SelectedValueProperty); }
        set { SetValue(SelectedValueProperty, value); }
    }

    public object LeftButton
    {
        get { return (object) GetValue(LeftButtonProperty); }
        set { SetValue(LeftButtonProperty, value); }
    }

    public string LeftButtonText
    {
        get { return (string) GetValue(LeftButtonTextProperty); }
        set { SetValue(LeftButtonTextProperty, value); }
    }

    public object RightButton
    {
        get { return (object) GetValue(RightButtonProperty); }
        set { SetValue(RightButtonProperty, value); }
    }

    public string RightButtonText
    {
        get { return (string) GetValue(RightButtonTextProperty); }
        set { SetValue(RightButtonTextProperty, value); }
    }


    public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register(nameof(SelectedValue), typeof(object), typeof(InputRadioButton), new PropertyMetadata(null));

    public static readonly DependencyProperty LeftButtonProperty =
        DependencyProperty.Register(nameof(LeftButton), typeof(object), typeof(InputRadioButton), new PropertyMetadata(null));

    public static readonly DependencyProperty LeftButtonTextProperty =
        DependencyProperty.Register(nameof(LeftButtonText), typeof(string), typeof(InputRadioButton), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty RightButtonProperty =
        DependencyProperty.Register(nameof(RightButton), typeof(object), typeof(InputRadioButton), new PropertyMetadata(null));

    public static readonly DependencyProperty RightButtonTextProperty =
        DependencyProperty.Register(nameof(RightButtonText), typeof(string), typeof(InputRadioButton), new PropertyMetadata(string.Empty));


    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
        if (sender is RadioButton rb && rb.Tag != null)
        {
            SelectedValue = rb.Tag;
        }
    }
}
