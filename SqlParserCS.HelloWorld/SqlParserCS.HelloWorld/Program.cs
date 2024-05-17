// See https://aka.ms/new-console-template for more information

using SqlParser;
using SqlParser.Ast;
using SqlParser.Dialects;

// 解析建表语句
// 
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
Dialect dialect = dbType.ToUpper() switch
{
    "MYSQL" => new MySqlDialect(),
    _ => new MsSqlDialect()
};
var ast = parser.ParseSql(sql, dialect);
var createTable = ast.First() as Statement.CreateTable;
// 获取表名称
Console.WriteLine($"Table name：{createTable?.Name}");
// 获取表注释
Console.WriteLine($"Table comment：{createTable?.Comment}");
Console.WriteLine("============================================================");
// 获取字段列表
var columnDefs = createTable?.Columns.ToList();
if (columnDefs is null) return;
// key = 表字段类型，value = 表字段类型对应的语言数据类型
var typeMap = new Dictionary<Type, string> {
    // 添加数据库类型与字段类型的映射
    { typeof(DataType.Varchar), nameof(String).ToLower() },
    { typeof(DataType.Char), nameof(String).ToLower() },
    { typeof(DataType.Nvarchar), nameof(String).ToLower() },
    { typeof(DataType.BigInt), "long" }
};
foreach (var (columnName, dataType, _, columnDefOptions) in columnDefs)
{
    Console.WriteLine($"Column name：{columnName}");
    // 获取字段数据类型
    Console.WriteLine($"Column data type：{dataType.GetType().Name}");
    if (columnDefOptions?.Count > 0)
        foreach (var columnDefOption in columnDefOptions)
        {
            switch (columnDefOption.Option)
            {
                // 获取字段注释
                case ColumnOption.Comment comment:
                    Console.WriteLine($"Column comment：{comment.Value}");
                    break;
                // 判断是否为主键
                case ColumnOption.Unique { IsPrimary: true }:
                    Console.WriteLine($"{columnName} is primary key");
                    break;
            }
        }

    Console.WriteLine($"Column field type：{typeMap[dataType.GetType()]}");
    Console.WriteLine("============================================================");
}