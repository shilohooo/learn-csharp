namespace XmlParse.Example.Models;

/// <summary>
/// 键约束信息
/// </summary>
public class Key
{
    /// <summary>
    /// Id 
    /// </summary>
    public string Id { get; init; }

    /// <summary>
    /// 名称 
    /// </summary>
    public string? Code { get; init; }

    /// <summary>
    /// 注释
    /// </summary>
    public string? Name { get; init; }
    
    /// <summary>
    ///  Ref，指向 <see cref="Key.Id"/>
    /// </summary>
    public string? Ref { get; init; }

    /// <summary>
    /// 键约束列信息列表
    /// </summary>
    public IEnumerable<Column>? KeyColumns { get; init; }
}