using System.Globalization;
using System.Windows.Data;

namespace BankKingWPF.UI.Utils;

public class DateToShortDateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        DateTime? date = (DateTime?)value;
        if (date.HasValue)
        {
            return date.Value.ToShortDateString();
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}