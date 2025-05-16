using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Avalonia.Basic.Mvvm.ValueConverterSample.Converters;

/// <summary>
/// </summary>
public static class FuncValueConverter
{
    /// <summary>
    ///     将用户输入的颜色字符串转换为画刷实例
    /// </summary>
    public static FuncValueConverter<string?, Brush?> StringToBrushConverter { get; } =
        new(s =>
        {
            if (Color.TryParse(s, out var color) || Color.TryParse($"#{s}", out color))
                return new SolidColorBrush(color);

            return null;
        });
}