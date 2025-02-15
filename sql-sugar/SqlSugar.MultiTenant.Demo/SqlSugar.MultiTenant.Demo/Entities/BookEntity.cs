namespace SqlSugar.MultiTenant.Demo.Entities;

/// <summary>
/// Book Entity
/// </summary>
[Tenant(Constants.TenantBConfigId)]
[SugarTable("T_Book", "Book")]
public class BookEntity
{
    /// <summary>
    /// Id
    /// </summary>
    [SugarColumn(ColumnName = "Id", IsPrimaryKey = true, ColumnDescription = "Id")]
    public long? Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [SugarColumn(ColumnName = "Name", IsNullable = false, ColumnDescription = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Author
    /// </summary>
    [SugarColumn(ColumnName = "Author", IsNullable = false, ColumnDescription = "Author")]
    public string Author { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"BookEntity {{ {nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Author)}: {Author} }}";
    }
}