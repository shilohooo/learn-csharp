// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using SqlParser;
using SqlParser.Ast;
using SqlParser.Dialects;

Console.WriteLine("Hello, World!");
// 解析建表语句
// language=mysql
const string sql = """
                   create table T_Users(
                       id bigint primary key comment 'ID',
                       username varchar(255) not null comment 'Username'
                   ) comment 'UserInfo Table'
                   """;
var parser = new Parser();
const string dbType = "mysql";
Dialect dialect = dbType.ToUpper() switch
{
    "MYSQL" => new MySqlDialect(),
    _ => new MsSqlDialect()
};
var ast = parser.ParseSql(sql, dialect);
Console.WriteLine(ast.ToSql());
var createTable = ast.First() as Statement.CreateTable;
// 获取表名称
Console.WriteLine($"Table name：{createTable?.Name}");
// 获取表注释
Console.WriteLine($"Table comment：{createTable?.Comment}");
// 获取字段列表
var columnDefs = createTable?.Columns.ToList();
if (columnDefs is null) return;
foreach (var (columnName, dataType, _, columnDefOptions) in columnDefs)
{
    if (dataType is DataType.CharacterLengthDataType characterLengthDataType)
    {
        Console.WriteLine("CharacterLengthDataType");
    }
    Console.WriteLine($"Column name：{columnName}");
    // 获取字段数据类型
    var columnDataType = dataType.ToSql();
    Console.WriteLine($"Column data type：{columnDataType}");
    // 获取字段长度
    var matches = ColumnDataLengthPattern().Match(columnDataType);
    if (matches.Length > 0) Console.WriteLine($"Column length：{matches.Groups[1].Value}");

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
}

internal partial class Program
{
    [GeneratedRegex(@"\((\d+)\)")]
    private static partial Regex ColumnDataLengthPattern();
}