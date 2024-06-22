using System.ComponentModel;

namespace XmlParse.Example.Enums;

/// <summary>
/// 对象元素枚举 
/// </summary>
internal enum ObjectElements
{
    /// <summary>
    /// 表对象 
    /// </summary>
    [Description("Table")] Table,

    /// <summary>
    /// 列对象 
    /// </summary>
    [Description("Column")] Column,

    /// <summary>
    /// 键约束对象
    /// </summary>
    [Description("Key")] Key
}