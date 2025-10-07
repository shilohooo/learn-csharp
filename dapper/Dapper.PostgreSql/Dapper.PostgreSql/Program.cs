using System.Collections.Immutable;
using System.Diagnostics;
using Bogus;
using Dapper;
using Dapper.PostgreSql;
using Humanizer;
using Npgsql;

var stopwatch = Stopwatch.StartNew();
const string connectionString = "Server=127.0.0.1;Port=5432;Database=dapper_db;User Id=root;Password=123456;";
// 字段命名：下划线转驼峰
DefaultTypeMap.MatchNamesWithUnderscores = true;
await using var connection = new NpgsqlConnection(connectionString);
// 获取指定表的列元数据
const string colMetaDataSql =
    "select * from information_schema.columns where table_catalog = @TableCatalog and table_schema = @TableSchema and table_name = @TableName;";
var columns = (await connection.QueryAsync<Column>(colMetaDataSql,
    new { TableCatalog = "dapper_db", TableSchema = "public", TableName = "t_user" })).ToList();
// 生成测试数据
var faker = new Faker();
var generators = ImmutableDictionary.Create<string, Func<int?, object>>()
    .Add("bigint", _ => faker.Random.Long())
    .Add("character varying",
        contentLength => faker.Random.String2(1, contentLength ?? int.MaxValue));
var config = new Faker<Dictionary<string, object?>>()
    .CustomInstantiator(f =>
    {
        var dict = new Dictionary<string, object?>();
        foreach (var column in columns)
        {
            if ("YES".Equals(column.IsIdentity))
            {
                dict.Add(column.ColumnName.Pascalize(), null);
                continue;
            }

            if (column.ColumnName.Contains("first_name"))
            {
                dict.Add(column.ColumnName.Pascalize(), f.Name.FirstName());
                continue;
            }

            if (column.ColumnName.Contains("last_name"))
            {
                dict.Add(column.ColumnName.Pascalize(), f.Name.LastName());
                continue;
            }
            if (column.ColumnName.Contains("age"))
            {
                dict.Add(column.ColumnName.Pascalize(), faker.Random.Int(1, 100));
                continue;
            }

            dict.Add(column.ColumnName.Pascalize(), generators[column.DataType](column.CharacterMaximumLength));
        }

        return dict;
    });

var dataList = config.Generate(100_0000);
stopwatch.Stop();
// 3列数据约 8 ~ 9 秒
Console.WriteLine($"百万数据生成耗时：{stopwatch.ElapsedMilliseconds}ms");
// 批量插入测试数据
stopwatch.Restart();
await connection.OpenAsync();
const string copySql = "copy t_user (first_name, last_name, age) from stdin (format binary)";
await using var writer = await connection.BeginBinaryImportAsync(copySql);
foreach (var dict in dataList)
{
    await writer.StartRowAsync();
    foreach (var column in columns)
    {
        var value = dict[column.ColumnName.Pascalize()];
        if (value is null)
        {
            continue;
        }

        await writer.WriteAsync(value, column.DataType);
    }
}

await writer.CompleteAsync();
stopwatch.Stop();
// 3列数据约 5 ~ 6 秒
Console.WriteLine($"百万数据批量插入耗时：{stopwatch.ElapsedMilliseconds}ms");
