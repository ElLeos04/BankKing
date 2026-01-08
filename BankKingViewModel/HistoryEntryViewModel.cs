using BankKingData.Entry;

namespace BankKingViewModel
{
    public class HistoryEntryViewModel(AccountEntryData _accountEntry) : BaseViewModel
    {

        public DateTime Date => _accountEntry.Date;
        public string DateText => _accountEntry.Date.ToShortDateString();


        public string CategoryName => _accountEntry.Category.Name;

        public string AmountText => _accountEntry.Amount.ToString("C2");

        public bool IsPositive => _accountEntry.Amount >= 0;

        // Mock constructor for design-time data
        public HistoryEntryViewModel() : this(new AccountEntryData() { Category = new() { Name = "Category", Type = EntryType.None }, Amount = 12345, Date = DateTime.Today })
        {
        }
    }
}
