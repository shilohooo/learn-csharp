namespace JsonParse.Example.Models;

/// <summary>
/// 字段
/// </summary>
public class Field
{
    /// <summary>
    /// 字段名称
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// 字段类型
    /// </summary>
    public string? Type { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Field: [Name: {Name}, Type: {Type}]";
    }
}