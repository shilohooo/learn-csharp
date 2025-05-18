using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace Avalonia.Basic.Mvvm.ValueConverterSample.Converters;

/// <summary>
/// </summary>
public class MathMultiConverter : IMultiValueConverter
{
    /// <inheritdoc />
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count != 3)
        {
            Debug.WriteLine("Exactly three values expected");
            return BindingOperations.DoNothing;
        }

        var operation = values[0] as string ?? "+";
        var val1 = values[1] as decimal? ?? 0;
        var val2 = values[2] as decimal? ?? 0;

        return operation switch
        {
            "+" => val1 + val2,
            "-" => val1 - val2,
            "*" => val1 * val2,
            "/" => val1 / val2,
            _ => new BindingNotification(new InvalidOperationException("Something went wrong"), BindingErrorType.Error)
        };
    }
}