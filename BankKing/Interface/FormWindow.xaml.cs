using System.Windows;

namespace BankKing.Interface;

/// <summary>
/// Logique d'interaction pour FormWindow.xaml
/// </summary>
public partial class FormWindow : Window
{
    public FormWindow()
    {
        InitializeComponent();

        MouseLeftButtonDown += (s, e) => DragMove();
    }
}
