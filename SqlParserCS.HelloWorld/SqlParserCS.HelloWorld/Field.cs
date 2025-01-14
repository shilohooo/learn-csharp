namespace SqlParserCS.HelloWorld;

/// <summary>
///     字段信息
/// </summary>
internal class Field
{
    /// <summary>
    ///     字段名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     字段类型
    /// </summary>
    public string? Type { get; init; }

    /// <summary>
    ///     字段长度
    /// </summary>
    public string? Length { get; set; }

    /// <summary>
    ///     字段是否为主键
    /// </summary>
    public bool IsPrimaryKey { get; set; }

    /// <summary>
    ///     是否为非空字段
    /// </summary>
    public bool Mandatory { get; set; }

    /// <summary>
    ///     字段注释
    /// </summary>
    public string? Comment { get; set; }

    public override string ToString()
    {
        return
            $"Name: {Name}\t| Type: {Type}\t| Length: {Length}\t| IsPrimaryKey: {IsPrimaryKey}\t| " +
            $"Mandatory: {Mandatory}\t| Comment: {Comment}";
    }
}