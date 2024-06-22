namespace XmlParse.Example.Models;

/// <summary>
/// 列信息 
/// </summary>
public class Column
{
    /// <summary>
    /// ID，用于确实是否为主键/唯一键 
    /// </summary>
    public string? Id { get; init; }

    /// <summary>
    /// 列名称 
    /// </summary>
    public string? Code { get; init; }

    /// <summary>
    /// 列注释 
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// 数据类型 
    /// </summary>
    public string? DataType { get; init; }

    /// <summary>
    /// 是否必填 
    /// </summary>
    public bool Mandatory { get; init; }

    /// <summary>
    /// 数据长度 
    /// </summary>
    public int? Length { get; init; }

    /// <summary>
    /// 是否为主键，默认为：<c>false</c> 
    /// </summary>
    public bool IsPrimaryKey { get; init; }
    
    /// <summary>
    ///  Ref，指向 <see cref="Column.Id"/>
    /// </summary>
    public string? Ref { get; init; }

    public override string ToString()
    {
        return $"[ID：{Id}，列名称：{Code}，注释：{Name}，数据类型：{DataType}，是否必填：{Mandatory}，数据长度：{Length}，是否为主键：{IsPrimaryKey}]";
    }
}