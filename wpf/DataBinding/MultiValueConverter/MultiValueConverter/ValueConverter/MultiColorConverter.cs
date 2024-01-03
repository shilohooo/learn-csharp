using System.Globalization;
using System.Windows.Data;

namespace MultiValueConverter.ValueConverter;

public class MultiColorConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length != 2)
        {
            return string.Empty;
        }

        var ageResult = int.TryParse(values[0].ToString(), out var age);
        var moneyResult = int.TryParse(values[1].ToString(), out var money);
        if (!ageResult || !moneyResult)
        {
            return string.Empty;
        }

        return age switch
        {
            < 30 when money > 50000 => "什么富哥~",
            >= 30 and <= 60 when money < 5000 => "爬~",
            < 30 when money < 5000 => "死穷鬼赶紧爬~",
            >= 30 when money > 90000 => "富哥v我50:)",
            _ => "寄~"
        };
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}