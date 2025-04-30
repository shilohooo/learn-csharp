using System.ComponentModel;

namespace AvaloniaPdmFileViewer.Enums;

/// <summary>
/// 属性元素枚举 
/// </summary>
internal enum AttributeElements
{
    /// <summary>
    /// Code - 英文名称
    /// </summary>
    [Description("Code")] Code,

    /// <summary>
    /// 注释 
    /// </summary>
    [Description("Name")] Name,

    /// <summary>
    /// 数据类型 
    /// </summary>
    [Description("DataType")] DataType,

    /// <summary>
    /// 数据长度 
    /// </summary>
    [Description("Length")] Length,

    /// <summary>
    /// 是否必填，值为 1 = 必填 
    /// </summary>
    [Description("Column.Mandatory")] Mandatory,

    /// <summary>
    ///     默认值
    /// </summary>
    [Description("DefaultValue")] DefaultValue
}