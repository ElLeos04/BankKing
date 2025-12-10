using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankKing.Interface.Components
{
    /// <summary>
    /// Logique d'interaction pour InputComponent.xaml
    /// </summary>
    public partial class InputTextComponent : UserControl
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
            DependencyProperty.Register(nameof(InputText), typeof(string), typeof(InputTextComponent), new PropertyMetadata(string.Empty));


    }
}
