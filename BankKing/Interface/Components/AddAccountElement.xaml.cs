using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankKing.Interface.Components
{
    /// <summary>
    /// Logique d'interaction pour AddAccountElement.xaml
    /// </summary>
    public partial class AddAccountElement : UserControl
    {
        public AddAccountElement()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(AddAccountElement), new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    }
}
