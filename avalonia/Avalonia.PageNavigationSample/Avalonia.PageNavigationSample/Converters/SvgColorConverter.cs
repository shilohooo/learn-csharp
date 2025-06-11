using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.PageNavigationSample.Converters;

/// <summary>
///     Svg图标颜色转换器
/// </summary>
public class SvgColorConverter : IValueConverter
{
    /// <inheritdoc />
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not bool isDarkMode) return "path { fill: #000000 }";

        return isDarkMode ? "path { fill: #ffffff }" : "path { fill: #000000 }";
    }

    /// <inheritdoc />
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}