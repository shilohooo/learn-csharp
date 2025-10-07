namespace Dapper.MySql.BulkInsert;

/// <summary>
/// </summary>
public class Column
{
    /// <summary>
    ///     TableSchema
    /// </summary>
    public string TableSchema { get; set; }

    /// <summary>
    ///     TableName
    /// </summary>
    public string TableName { get; set; }

    /// <summary>
    ///     ColumnName
    /// </summary>
    public string ColumnName { get; set; }

    /// <summary>
    ///     IsNullable
    /// </summary>
    public string IsNullable { get; set; }

    /// <summary>
    ///     DataType
    /// </summary>
    public string DataType { get; set; }

    /// <summary>
    ///     Length
    /// </summary>
    public int? Length { get; set; }

    /// <summary>
    ///     ColumnComment
    /// </summary>
    public string ColumnComment { get; set; }

    /// <summary>
    ///     ColumnKey
    /// </summary>
    public string ColumnKey { get; set; }

    /// <summary>
    ///     Extra
    /// </summary>
    public string Extra { get; set; }

    /// <summary>
    ///     OrdinalPosition
    /// </summary>
    public int OrdinalPosition { get; set; }

    public bool isIdentity => Extra.Contains("auto_increment", StringComparison.CurrentCultureIgnoreCase);

    public override string ToString()
    {
        return
            $"Columns: [TableSchema: {TableSchema}, TableName: {TableName}, ColumnName: {ColumnName}, IsNullable: {IsNullable}, DataType: {DataType}, Length: {Length}, ColumnComment: {ColumnComment}, ColumnKey: {ColumnKey}, Extra: {Extra}, OrdinalPosition: {OrdinalPosition}]";
    }
}