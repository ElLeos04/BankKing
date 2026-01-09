using System.Globalization;
using System.Windows.Data;

namespace BankKingWPF.UI.Utils;

public class NormalizeDecimalConverter : IValueConverter
{
    // VM -> View (Displaying the number)
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }

    // View -> VM (User typed something, now saving to property)
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string input = value as string;

        if (string.IsNullOrEmpty(input))
            return 0m;

        if (input.EndsWith(".") || input.EndsWith(","))
        {
            return Binding.DoNothing;
        }

        string separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        input = input.Replace(".", separator).Replace(",", separator);

        if (decimal.TryParse(input, out decimal result))
        {
            return result;
        }

        return value;
    }
}
