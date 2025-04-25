using System;
using System.ComponentModel;
using System.Reflection;

namespace AvaloniaPdmFileViewer.Enums;

/// <summary>
///     通过扩展方法获取枚举的描述信息
/// </summary>
internal static class EnumExtensions
{
    /// <summary>
    ///     获取枚举的描述信息
    ///     <param name="value">调用该方法的枚举实例</param>
    ///     <returns>枚举的描述信息</returns>
    /// </summary>
    public static string GetDescription(this Enum value)
    {
        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());
        if (memberInfo.Length <= 0) return string.Empty;

        var attribute = memberInfo[0].GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? string.Empty;
    }
}