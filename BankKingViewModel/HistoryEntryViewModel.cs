using BankKingData.Entry;
using BankKingService.Data;

namespace BankKingViewModel
{
    public class HistoryEntryViewModel(AccountEntryBO _accountEntry) : BaseViewModel
    {

        public DateTime Date => _accountEntry.Date.Date;
        public string DateText => _accountEntry.Date.ToShortDateString();


        public string CategoryName => _accountEntry.Category.Name;

        public string AmountText => _accountEntry.Amount.ToString("C2");

        public bool IsPositive => _accountEntry.Amount >= 0;

        // Mock constructor for design-time data
        public HistoryEntryViewModel() : this(new AccountEntryBO() { Category = new() { Name = "Category", Type = EntryType.None }, Amount = 12345, Date = DateTime.Today })
        {
        }
    }
}
