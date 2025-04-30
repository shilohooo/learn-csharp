using System.ComponentModel;

namespace AvaloniaPdmFileViewer.Enums;

/// <summary>
/// 命名空间枚举 
/// </summary>
internal enum Namespace
{
    /// <summary>
    /// 属性 
    /// </summary>
    [Description("attribute")] A,

    /// <summary>
    /// 集合 
    /// </summary>
    [Description("collection")] C,

    /// <summary>
    /// 对象 
    /// </summary>
    [Description("object")] O
}