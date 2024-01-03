using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MultiValueConverter.ValueConverter;

public class AgeToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!int.TryParse(value.ToString(), out var age))
        {
            return Brushes.Black;
        }

        return age switch
        {
            < 20 => Brushes.Green,
            < 40 => Brushes.Blue,
            < 60 => Brushes.Orange,
            < 80 => Brushes.Red,
            < 90 => Brushes.Purple,
            _ => Brushes.Gray
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}