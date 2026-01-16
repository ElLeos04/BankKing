using BankKingData.Entry;
using BankKingService.Data;
using BankKingViewModel.Factory;
using BankKingViewModel.Form;
using BankKingViewModel.Utils;
using System.Windows.Input;

namespace BankKingViewModel
{
    public class HistoryEntryViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;

        private readonly IViewModelFactory _viewModelFactory;

        private readonly Action<HistoryEntryViewModel> _onEntryRemove;
        private readonly Action<HistoryEntryViewModel, decimal> _onEntryModified;

        private AccountEntryBO _accountEntry;
        public AccountEntryBO AccountEntry
        {
            get { return _accountEntry; }
            set { _accountEntry = value; }
        }

        public DateTime Date
        {
            get { return _accountEntry.Date.Date; }
            set
            {
                _accountEntry.Date = value;
                OnPropertyChanged(nameof(DateText));
            }
        }

        public EntryCategoryBO Category
        {
            get { return _accountEntry.Category; }
            set
            {
                _accountEntry.Category = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        public decimal Amount
        {
            get => _accountEntry.Amount;
            set
            {
                _accountEntry.Amount = value;
                OnPropertyChanged(nameof(AmountText));
                OnPropertyChanged(nameof(IsPositive));
            }
        }


        public string DateText => _accountEntry.Date.ToShortDateString();

        public string CategoryName => Category.Name;

        public string AmountText => Amount.ToString("C2");

        public bool IsPositive => _accountEntry.Amount >= 0;

        public ICommand OnClickCommand => new RelayCommand(OnClick, null);

        public HistoryEntryViewModel(AccountEntryBO accountEntry, IViewModelFactory viewModelFactory, IDialogService dialogService,
            Action<HistoryEntryViewModel> onEntryRemove, Action<HistoryEntryViewModel, decimal> onEntryModified)
        {
            _accountEntry = accountEntry;
            _viewModelFactory = viewModelFactory;
            _dialogService = dialogService;
            _onEntryRemove = onEntryRemove;
            _onEntryModified = onEntryModified;
        }

        // Mock constructor for design-time data
        public HistoryEntryViewModel()
        {
            _accountEntry = MockAccount();
        }

        private void OnClick(object parameters)
        {
            AddTransactionViewModel addTransactionViewModel = _viewModelFactory.CreateTransactionViewModel();
            addTransactionViewModel.Amount = _accountEntry.Amount;
            addTransactionViewModel.Date = _accountEntry.Date;
            addTransactionViewModel.TransactionType = _accountEntry.Category.Type;
            addTransactionViewModel.Category = _accountEntry.Category;

            if (_dialogService.ShowDialogWithDelete(addTransactionViewModel))
            {
                _onEntryModified.Invoke(this, addTransactionViewModel.Amount);

                Amount = addTransactionViewModel.Amount;
                Date = addTransactionViewModel.Date ?? DateTime.Today;
                Category = addTransactionViewModel.Category;
            }
            else if (addTransactionViewModel.DeleteTriggered)
            {
                _onEntryRemove?.Invoke(this);
            }
        }


        private static AccountEntryBO MockAccount()
        {
            return new AccountEntryBO() { Category = new() { Name = "Category", Type = EntryType.None }, Amount = 12345, Date = DateTime.Today };
        }
    }
}
