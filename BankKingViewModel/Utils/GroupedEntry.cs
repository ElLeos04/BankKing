using System.Collections.ObjectModel;

namespace BankKingViewModel.Utils;

public class GroupedEntry<T>(string key, IEnumerable<T> items) : ObservableCollection<T>(items)
{
    public string Key { get; set; } = key;
}
