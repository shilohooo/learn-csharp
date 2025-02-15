namespace SqlSugar.MultiTenant.Demo.Entities;

/// <summary>
/// User Entity
/// </summary>
[Tenant(Constants.TenantAConfigId)]
[SugarTable("T_User", "User")]
public class UserEntity
{

    /// <summary>
    /// Id
    /// </summary>
    [SugarColumn(ColumnName = "Id", IsPrimaryKey = true, ColumnDescription = "Id")]
    public long? Id { get; set; }

    /// <summary>
    /// Nickname
    /// </summary>
    [SugarColumn(ColumnName = "Nickname", IsNullable = false, ColumnDescription = "Nickname")]
    public string Nickname { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"UserEntity {{ {nameof(Id)}: {Id}, {nameof(Nickname)}: {Nickname} }}";
    }
}