using System.ComponentModel;

namespace XmlParse.Example.Enums;

/// <summary>
/// 集合元素枚举 
/// </summary>
internal enum CollectionElements
{
    /// <summary>
    /// 表父节点 
    /// </summary>
    [Description("Tables")] Tables,

    /// <summary>
    /// 列 
    /// </summary>
    [Description("Columns")] Columns,

    /// <summary>
    /// 键约束 
    /// </summary>
    [Description("Keys")] Keys,

    /// <summary>
    /// 键约束列
    /// </summary>
    [Description("Key.Columns")] KeyColumns,

    /// <summary>
    /// 主键约束
    /// </summary>
    [Description("PrimaryKey")] PrimaryKey
}