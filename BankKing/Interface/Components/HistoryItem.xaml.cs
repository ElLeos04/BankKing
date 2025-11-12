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

        public static readonly DependencyProperty CategoryProperty =
            DependencyProperty.Register("EntryCategory", typeof(EntryCategory), typeof(HistoryItem), null);

        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register("EntryAmount", typeof(string), typeof(HistoryItem), null);

        public static readonly DependencyProperty IsLastItemProperty =
            DependencyProperty.Register("IsLastItem", typeof(bool), typeof(HistoryItem), new PropertyMetadata(false));

        public EntryCategory EntryCategory
        {
            get { return (EntryCategory)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }

        public string EntryAmount
        {
            get { return (string)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        public bool IsLastItem
        {
            get { return (bool)GetValue(IsLastItemProperty); }
            set { SetValue(IsLastItemProperty, value); }
        }
    }
}
