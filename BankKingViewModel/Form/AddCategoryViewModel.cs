using BankKingData.Entry;

namespace BankKingViewModel.Form;

public class AddCategoryViewModel : FormViewModel
{

    private string _categoryName = "";
    public string CategoryName
    {
        get => _categoryName;
        set
        {
            _categoryName = value;
            OnPropertyChanged(nameof(CategoryName));
        }
    }

    private EntryType _type = EntryType.None;
    public EntryType Type
    {
        get => _type;
        set
        {
            _type = value;
            OnPropertyChanged(nameof(Type));
        }
    }

    public List<EntryType> EntryTypes => Enum.GetValues<EntryType>().Where(t => t != EntryType.None).ToList();

}
