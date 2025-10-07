namespace Dapper.SqlServer.BulkCopy;

/// <summary>
/// </summary>
public class Column
{

    /// <summary>
    /// ColumnId
    /// </summary>
    public int ColumnId { get; set; }

    /// <summary>
    /// ColumnName
    /// </summary>
    public required string ColumnName { get; set; }

    /// <summary>
    /// DataType
    /// </summary>
    public required string DataType { get; set; }

    /// <summary>
    /// MaxLength
    /// </summary>
    public int MaxLength { get; set; }

    /// <summary>
    /// IsNullable
    /// </summary>
    public bool IsNullable { get; set; }

    /// <summary>
    /// IsIdentity
    /// </summary>
    public bool IsIdentity { get; set; }

    public override string ToString()
    {
        return $"Column: [ColumnId: {ColumnId}, ColumnName: {ColumnName}, DataType: {DataType}, MaxLength: {MaxLength}, IsNullable: {IsNullable}, IsIdentity: {IsIdentity}]";
    }
}