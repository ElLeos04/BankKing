using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BankKingWPF.UI.Components;

/// <summary>
/// Logique d'interaction pour UserControl1.xaml
/// </summary>
public partial class ImageButton : UserControl
{
    public ImageButton()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty ButtonTextProperty =
        DependencyProperty.Register("ButtonText", typeof(string), typeof(ImageButton), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ImageSourceProperty =
                    DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ImageButton), new PropertyMetadata(null));


    public string ButtonText
    {
        get { return (string) GetValue(ButtonTextProperty); }
        set { SetValue(ButtonTextProperty, value); }
    }

    public ImageSource ImageSource
    {
        get { return (ImageSource) GetValue(ImageSourceProperty); }
        set { SetValue(ImageSourceProperty, value); }
    }

    public ICommand Command
    {
        get { return (ICommand) GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }
}
