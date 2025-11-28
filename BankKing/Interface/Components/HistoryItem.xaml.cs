using BankKing.Data.Entry;
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
    /// Logique d'interaction pour HistoryItem.xaml
    /// </summary>
    public partial class HistoryItem : UserControl
    {
        public HistoryItem()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty HideBottomBorderProperty =
            DependencyProperty.Register(nameof(HideBottomBorder), typeof(bool), typeof(HistoryItem), new PropertyMetadata(false));

        public bool HideBottomBorder
        {
            get { return (bool)GetValue(HideBottomBorderProperty); }
            set { SetValue(HideBottomBorderProperty, value); }
        }
    }
}
