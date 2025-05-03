// See https://aka.ms/new-console-template for more information

using SqlParser;
using SqlParser.Ast;
using SqlParser.Dialects;

const string dbType = "mssql";
const string tablePrefix = "T_";

// 解析建表语句
const string sql = """
                   create table T_Users(
                       id bigint primary key,
                       username varchar(50) not null,
                       address nvarchar(255) not null,
                       gender char(1),
                       enabled bit(1)
                   )
                   """;
var parser = new Parser();
Dialect dialect = dbType.ToUpper() switch
{
    "MYSQL" => new MySqlDialect(),
    _ => new MsSqlDialect()
};
var ast = parser.ParseSql(sql, dialect);

// 创建实体
var createTable = ast[0] as Statement.CreateTable;
// var pluralizer = new Pluralizer();
// var entity = new Entity
// {
//     TableName = createTable!.Name.ToString(),
//     Comment = createTable.Comment ?? createTable.Name.ToString(),
//     // 实体名称使用单数形式
//     EntityName = pluralizer.Singularize(createTable.Name.ToString().Replace(tablePrefix, ""))
// };
//
// // 获取字段列表
// var columnDefs = createTable.Columns.ToList();
// if (columnDefs.Count == 0) return;
// // key = 表字段类型，value = 表字段类型对应的语言数据类型
// var typeMap = new Dictionary<Type, string>
// {
//     // 添加数据库类型与字段类型的映射
//     { typeof(DataType.Varchar), nameof(String).ToLower() },
//     { typeof(DataType.Char), nameof(String).ToLower() },
//     { typeof(DataType.Nvarchar), nameof(String).ToLower() },
//     { typeof(DataType.BigInt), "long" },
// };
// List<Field> fields = [];
// foreach (var (columnName, dataType, _, columnDefOptions) in columnDefs)
// {
//     Console.WriteLine($"columnName: {columnName}, dataType: {dataType}");
//     var field = new Field
//     {
//         Name = columnName.ToString(),
//         Comment = columnName.ToString(),
//         Type = typeMap[dataType.GetType()]
//     };
//     if (columnDefOptions?.Count > 0)
//         foreach (var columnDefOption in columnDefOptions)
//             switch (columnDefOption.Option)
//             {
//                 // 获取字段注释
//                 case ColumnOption.Comment comment:
//                     field.Comment = comment.Value;
//                     break;
//                 // 判断是否为主键
//                 case ColumnOption.Unique { IsPrimary: true }:
//                     field.IsPrimaryKey = true;
//                     break;
//                 // 判断是否设置为非空字段
//                 case ColumnOption.NotNull:
//                     field.Mandatory = true;
//                     break;
//             }
//
//     // 获取字段长度
//     var match = RegexConstants.LengthPattern().Match(dataType.ToSql());
//     field.Length = match.Groups[1].Value;
//
//     fields.Add(field);
// }
//
// entity.Fields = fields;
// entity.Display();
//
// // scriban 模板引擎测试，https://github.com/scriban/scriban
// // 注意：在模板中，变量名称使用小写加下划线的形式
// // 如：Name 属性对应模板的变量 name，EntityName 属性对应模板中的变量 entity_name
// // var helloScriban = Template.Parse(await File.ReadAllTextAsync(@"Templates\test-template.txt"));
// // var hellResult = await helloScriban.RenderAsync(new { Name = "World:)" });
// // Console.WriteLine($"hello result: {hellResult}");
//
// // 生成实体类代码
// var templateText = await File.ReadAllTextAsync(@"Templates\CSharpEntity.txt");
// var template = Template.Parse(templateText);
// const SourceFileSuffix sourceFileSuffix = SourceFileSuffix.CSharp;
// // ReSharper disable once ConditionIsAlwaysTrueOrFalse
// if (SourceFileSuffix.CSharp.Equals(sourceFileSuffix))
//     // CSharp 要求属性命名首字母大写
//     entity.Fields.ForEach(field =>
//     {
//         var firstLetter = field.Name![0] - 32;
//         field.Name = (char)firstLetter + field.Name[1..];
//     });
// var result = await template.RenderAsync(new { Entity = entity });
// // 追加到文件中
// var entityFilepath = $"{entity.EntityName}.{sourceFileSuffix.GetDescription()}";
// await File.WriteAllTextAsync(entityFilepath, result);