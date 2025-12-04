using BankKing.Data.Entry;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace BankKing.ViewModel
{
    public class HistoryEntryViewModel : INotifyPropertyChanged
    {
        private AccountEntry _accountEntry;

        public string Date => _accountEntry.Date.ToShortDateString();


        public string CategoryName => _accountEntry.Category.Name;

        public string AmountText => _accountEntry.Amount.ToString("C2");

        public SolidColorBrush AmountColor
        {
            get
            {
                SolidColorBrush? brush;
                if (_accountEntry.Amount >= 0)
                {
                    brush = Application.Current.TryFindResource("PositiveValueBrush")! as SolidColorBrush;
                }
                else
                {
                    brush = Application.Current.TryFindResource("NegativeValueBrush") as SolidColorBrush;
                }

                brush ??= new SolidColorBrush(Colors.Black);
                return brush;
            }
        }


        public HistoryEntryViewModel(AccountEntry accountEntry)
        {
            _accountEntry = accountEntry;
        }

        // Mock constructor for design-time data
        public HistoryEntryViewModel() : this(new AccountEntry() { Category = new() { Name = "Category", Type = EntryType.None }, Amount = 12345, Date = DateTime.Today })
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
