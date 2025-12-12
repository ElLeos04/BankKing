using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankKing.Interface.Components.Form
{
    /// <summary>
    /// Logique d'interaction pour InputNumberComponent.xaml
    /// </summary>
    public partial class InputNumberComponent : InputComponent
    {

        public InputNumberComponent()
        {
            InitializeComponent();
        }

        public decimal InputNumber
        {
            get { return (decimal) GetValue(InputNumberProperty); }
            set { SetValue(InputNumberProperty, value); }
        }

        public static readonly DependencyProperty InputNumberProperty =
            DependencyProperty.Register(nameof(InputNumber), typeof(decimal), typeof(InputNumberComponent), new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            string currentText = textBox!.Text;
            string futureText = currentText.Insert(textBox.CaretIndex, e.Text);

            Regex regex = new Regex(@"^-?\d*[.,]?\d{0,2}$");

            if (!regex.IsMatch(futureText))
            {
                e.Handled = true;
            }
        }


    }
}
