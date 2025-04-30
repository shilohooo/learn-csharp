using System.Collections.Generic;
using System.Linq;

namespace AvaloniaPdmFileViewer.Models;

/// <summary>
///     表信息
/// </summary>
public class Table
{
    /// <summary>
    ///     表名称
    /// </summary>
    public string? Code { get; init; }

    /// <summary>
    ///     表注释
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    ///     列信息列表
    /// </summary>
    public IEnumerable<Column>? Columns { get; init; }

    /// <summary>
    ///     总列数
    /// </summary>
    public int TotalColumns => Columns?.Count() ?? 0;

    public override string ToString()
    {
        return $"[表名称：{Code}，注释：{Name}]";
    }
}