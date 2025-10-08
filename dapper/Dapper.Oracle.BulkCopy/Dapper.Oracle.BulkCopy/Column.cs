namespace Dapper.Oracle.BulkCopy;

/// <summary>
/// 
/// </summary>
public class Column
{

    /// <summary>
    /// TableName
    /// </summary>
    public string TableName { get; set; }

    /// <summary>
    /// ColumnName
    /// </summary>
    public string ColumnName { get; set; }

    /// <summary>
    /// DataType
    /// </summary>
    public string DataType { get; set; }

    /// <summary>
    /// Length
    /// </summary>
    public int Length { get; set; }

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
        return $"Column: [TableName: {TableName}, ColumnName: {ColumnName}, DataType: {DataType}, Length: {Length}, IsNullable: {IsNullable}, IsIdentity: {IsIdentity}]";
    }

}