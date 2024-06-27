namespace JsonParse.Example.Models;

/// <summary>
/// 实体
/// </summary>
public class Entity
{
    /// <summary>
    /// 实体名称
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// 字段列表
    /// </summary>
    public List<Field> Fields { get; } = [];

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Entity: [Name: {Name}, Fields: {string.Join(", ", Fields)}]";
    }
}