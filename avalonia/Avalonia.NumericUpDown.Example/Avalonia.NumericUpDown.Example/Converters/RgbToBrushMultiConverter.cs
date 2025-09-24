using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Avalonia.NumericUpDown.Example.Converters;

/// <summary>
/// 
/// </summary>
public class RgbToBrushMultiConverter : IMultiValueConverter
{
    /// <inheritdoc />
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count != 3)
        {
            throw new ArgumentException("Invalid number of arguments");
        }

        var r = System.Convert.ToByte(values[0]);
        var g = System.Convert.ToByte(values[1]);
        var b = System.Convert.ToByte(values[2]);
        return new SolidColorBrush(Color.FromRgb(r, g, b));
    }
}