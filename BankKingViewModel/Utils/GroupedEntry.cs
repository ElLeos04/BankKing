using System.Collections.ObjectModel;

namespace BankKingViewModel.Utils;

public class GroupedEntry<T>(DateTime key, IEnumerable<T> items) : ObservableCollection<T>(items)
{
    public DateTime Key { get; set; } = key;
}
