using System.ComponentModel;

namespace SqlParserCS.HelloWorld;

internal static class EnumExtensions
{
    /// <summary>
    ///     获取枚举的描述信息
    /// </summary>
    /// <param name="enumInstance">枚举实例</param>
    /// <returns>枚举的描述信息</returns>
    public static string GetDescription(this Enum enumInstance)
    {
        var field = enumInstance.GetType().GetField(enumInstance.ToString());
        if (field == null) return enumInstance.ToString();
        var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
        return attribute == null ? enumInstance.ToString() : ((DescriptionAttribute)attribute).Description;
    }
}