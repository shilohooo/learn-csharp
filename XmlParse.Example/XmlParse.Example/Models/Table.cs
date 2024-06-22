namespace XmlParse.Example.Models;

/// <summary>
/// 表信息 
/// </summary>
internal class Table
{
    /// <summary>
    /// 表名称 
    /// </summary>
    public string? Code { get; init; }

    /// <summary>
    /// 表注释 
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// 列信息列表 
    /// </summary>
    public IEnumerable<Column>? Columns { get; init; }

    public override string ToString()
    {
        return $"[表名称：{Code}，注释：{Name}]";
    }
}