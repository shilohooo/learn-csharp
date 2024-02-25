using System.Globalization;

namespace Maui.FileExplorer.Sample.Converters;

/// <summary>
/// 驱动器总空间和有效空间绑定值转换器
/// 
/// 将 Byte 转换为 Gigabyte
/// </summary>
internal class ByteToGigabyteConverter : IValueConverter
{
    /// <summary>
    /// 转换为 Gigabyte
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return null;
        }

        return (long)value / 1024 / 1024 / 1024;
    }

    /// <summary>
    /// 转换为 Byte
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return null;
        }

        return (long)value * 1024 * 1024 * 1024;
    }
}
