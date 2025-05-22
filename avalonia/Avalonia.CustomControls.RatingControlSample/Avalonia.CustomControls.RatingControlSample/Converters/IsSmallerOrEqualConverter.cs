using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.CustomControls.RatingControlSample.Converters;

/// <summary>
/// </summary>
public class IsSmallerOrEqualConverter : IMultiValueConverter
{
    /// <inheritdoc />
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count != 2) throw new ArgumentException("该转换器只能接收两个参数");

        var firstNum = values[0] as int?;
        var secondNum = values[1] as int?;

        return firstNum <= secondNum;
    }
}