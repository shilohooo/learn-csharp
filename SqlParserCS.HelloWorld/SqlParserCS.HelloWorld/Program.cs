// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using Pluralize.NET;
using SqlParser;
using SqlParser.Ast;
using SqlParser.Dialects;

// 解析建表语句
const string sql = """
                   create table T_Users(
                       id bigint primary key,
                       username varchar(50) not null,
                       address nvarchar(255) not null,
                       gender char(1)
                   )
                   """;
var parser = new Parser();
const string dbType = "mysql";
const string tablePrefix = "T_";
Dialect dialect = dbType.ToUpper() switch
{
    "MYSQL" => new MySqlDialect(),
    _ => new MsSqlDialect()
};
var ast = parser.ParseSql(sql, dialect);
var createTable = ast.First() as Statement.CreateTable;
var pluralizer = new Pluralizer();
var entity = new Entity
{
    TableName = createTable?.Name.ToString(),
    Comment = createTable?.Comment,
    // 实体名称使用单数形式
    EntityName = pluralizer.Singularize(createTable?.Name.ToString().Replace(tablePrefix, ""))
};
// 获取字段列表
var columnDefs = createTable?.Columns.ToList();
if (columnDefs is null) return;
// key = 表字段类型，value = 表字段类型对应的语言数据类型
var typeMap = new Dictionary<Type, string>
{
    // 添加数据库类型与字段类型的映射
    { typeof(DataType.Varchar), nameof(String).ToLower() },
    { typeof(DataType.Char), nameof(String).ToLower() },
    { typeof(DataType.Nvarchar), nameof(String).ToLower() },
    { typeof(DataType.BigInt), "long" }
};
List<Field> fields = [];
foreach (var (columnName, dataType, _, columnDefOptions) in columnDefs)
{
    var field = new Field
    {
        Name = columnName.ToString(),
        Type = typeMap[dataType.GetType()]
    };
    if (columnDefOptions?.Count > 0)
        foreach (var columnDefOption in columnDefOptions)
            switch (columnDefOption.Option)
            {
                // 获取字段注释
                case ColumnOption.Comment comment:
                    field.Comment = comment.Value;
                    break;
                // 判断是否为主键
                case ColumnOption.Unique { IsPrimary: true }:
                    field.IsPrimaryKey = true;
                    break;
                // 判断是否设置为非空字段
                case ColumnOption.NotNull:
                    field.Mandatory = true;
                    break;
            }

    // 获取字段长度
    var match = RegexConstants.LengthPattern().Match(dataType.ToSql());
    field.Length = match.Groups[1].Value;

    fields.Add(field);
}

entity.Fields = fields;
entity.Display();


/// <summary>
///     实体信息
/// </summary>
internal class Entity
{
    /// <summary>
    ///     表名称
    /// </summary>
    public string? TableName { get; init; }

    /// <summary>
    ///     注释
    /// </summary>
    public string? Comment { get; init; }

    /// <summary>
    ///     实体名称
    /// </summary>
    public string? EntityName { get; init; }

    /// <summary>
    ///     字段列表
    /// </summary>
    public List<Field> Fields { get; set; } = [];

    /// <summary>
    ///     显示实体信息
    /// </summary>
    public void Display()
    {
        Console.WriteLine($"TableName: {TableName}\t| TableComment: {Comment}\t| EntityName: {EntityName}");
        Console.WriteLine("Fields:");
        foreach (var field in Fields)
            Console.WriteLine(field);
    }
}

/// <summary>
///     字段信息
/// </summary>
internal class Field
{
    /// <summary>
    ///     字段名称
    /// </summary>
    public string? Name { get; init; }

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

internal static partial class RegexConstants
{
    [GeneratedRegex(@"\((\d+)\)")]
    public static partial Regex LengthPattern();
}