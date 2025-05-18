using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Basic.Mvvm.ValueConverterSample.Converters;

/// <summary>
/// </summary>
public class MathAddConverter : IValueConverter
{
    /// <inheritdoc />
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (decimal?)value + (decimal?)parameter;
    }

    /// <inheritdoc />
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (decimal?)value - (decimal?)parameter;
    }
}