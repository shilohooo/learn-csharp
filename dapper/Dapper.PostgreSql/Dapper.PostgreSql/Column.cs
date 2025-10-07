namespace Dapper.PostgreSql;

/// <summary>
///     RootClass Class
/// </summary>
public class Column
{
    /// <summary>
    ///     TableCatalog
    /// </summary>
    public string TableCatalog { get; set; }

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
    ///     OrdinalPosition
    /// </summary>
    public int OrdinalPosition { get; set; }

    /// <summary>
    ///     ColumnDefault
    /// </summary>
    public object? ColumnDefault { get; set; }

    /// <summary>
    ///     IsNullable
    /// </summary>
    public string IsNullable { get; set; }

    /// <summary>
    ///     DataType
    /// </summary>
    public string DataType { get; set; }

    /// <summary>
    ///     CharacterMaximumLength
    /// </summary>
    public int? CharacterMaximumLength { get; set; }

    /// <summary>
    ///     CharacterOctetLength
    /// </summary>
    public object? CharacterOctetLength { get; set; }

    /// <summary>
    ///     NumericPrecision
    /// </summary>
    public int NumericPrecision { get; set; }

    /// <summary>
    ///     NumericPrecisionRadix
    /// </summary>
    public int NumericPrecisionRadix { get; set; }

    /// <summary>
    ///     NumericScale
    /// </summary>
    public int NumericScale { get; set; }

    /// <summary>
    ///     DatetimePrecision
    /// </summary>
    public object? DatetimePrecision { get; set; }

    /// <summary>
    ///     IntervalType
    /// </summary>
    public object? IntervalType { get; set; }

    /// <summary>
    ///     IntervalPrecision
    /// </summary>
    public object? IntervalPrecision { get; set; }

    /// <summary>
    ///     CharacterSetCatalog
    /// </summary>
    public object? CharacterSetCatalog { get; set; }

    /// <summary>
    ///     CharacterSetSchema
    /// </summary>
    public object? CharacterSetSchema { get; set; }

    /// <summary>
    ///     CharacterSetName
    /// </summary>
    public object? CharacterSetName { get; set; }

    /// <summary>
    ///     CollationCatalog
    /// </summary>
    public object? CollationCatalog { get; set; }

    /// <summary>
    ///     CollationSchema
    /// </summary>
    public object? CollationSchema { get; set; }

    /// <summary>
    ///     CollationName
    /// </summary>
    public object? CollationName { get; set; }

    /// <summary>
    ///     DomainCatalog
    /// </summary>
    public object? DomainCatalog { get; set; }

    /// <summary>
    ///     DomainSchema
    /// </summary>
    public object? DomainSchema { get; set; }

    /// <summary>
    ///     DomainName
    /// </summary>
    public object? DomainName { get; set; }

    /// <summary>
    ///     UdtCatalog
    /// </summary>
    public string UdtCatalog { get; set; }

    /// <summary>
    ///     UdtSchema
    /// </summary>
    public string UdtSchema { get; set; }

    /// <summary>
    ///     UdtName
    /// </summary>
    public string UdtName { get; set; }

    /// <summary>
    ///     ScopeCatalog
    /// </summary>
    public object? ScopeCatalog { get; set; }

    /// <summary>
    ///     ScopeSchema
    /// </summary>
    public object? ScopeSchema { get; set; }

    /// <summary>
    ///     ScopeName
    /// </summary>
    public object? ScopeName { get; set; }

    /// <summary>
    ///     MaximumCardinality
    /// </summary>
    public object? MaximumCardinality { get; set; }

    /// <summary>
    ///     DtdIdentifier
    /// </summary>
    public string DtdIdentifier { get; set; }

    /// <summary>
    ///     IsSelfReferencing
    /// </summary>
    public string IsSelfReferencing { get; set; }

    /// <summary>
    ///     IsIdentity
    /// </summary>
    public string IsIdentity { get; set; }

    /// <summary>
    ///     IdentityGeneration
    /// </summary>
    public string IdentityGeneration { get; set; }

    /// <summary>
    ///     IdentityStart
    /// </summary>
    public string IdentityStart { get; set; }

    /// <summary>
    ///     IdentityIncrement
    /// </summary>
    public string IdentityIncrement { get; set; }

    /// <summary>
    ///     IdentityMaximum
    /// </summary>
    public string IdentityMaximum { get; set; }

    /// <summary>
    ///     IdentityMinimum
    /// </summary>
    public string IdentityMinimum { get; set; }

    /// <summary>
    ///     IdentityCycle
    /// </summary>
    public string IdentityCycle { get; set; }

    /// <summary>
    ///     IsGenerated
    /// </summary>
    public string IsGenerated { get; set; }

    /// <summary>
    ///     GenerationExpression
    /// </summary>
    public object? GenerationExpression { get; set; }

    /// <summary>
    ///     IsUpdatable
    /// </summary>
    public string IsUpdatable { get; set; }
}