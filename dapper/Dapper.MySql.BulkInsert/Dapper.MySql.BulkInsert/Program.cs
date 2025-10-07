using System.Diagnostics;
using System.Text;
using Bogus;
using Dapper;
using Dapper.MySql.BulkInsert;
using Humanizer;
using MySql.Data.MySqlClient;

const string connStr = "Server=127.0.0.1;database=dapper_test;Uid=root;Pwd=123456;Charset=utf8;Port=13306;SslMode=none;AllowLoadLocalInfile=true";
await using var connection = new MySqlConnection(connStr);
const string sql = """
                   select TABLE_SCHEMA as TableSchema,
                          TABLE_NAME as TableName,
                          COLUMN_NAME as ColumnName,
                          IS_NULLABLE as IsNullable,
                          DATA_TYPE as DataType,
                          CHARACTER_MAXIMUM_LENGTH as Length,
                          COLUMN_COMMENT as ColumnComment,
                          COLUMN_KEY as ColumnKey,
                          EXTRA as Extra,
                          ORDINAL_POSITION as OrdinalPosition
                   from information_schema.COLUMNS
                   where TABLE_SCHEMA = @TableSchema
                     and TABLE_NAME = @TableName
                   order by ORDINAL_POSITION;
                   """;
var columns = (await connection.QueryAsync<Column>(sql, new { TableSchema = "dapper_test", TableName = "t_user" }))
    .ToList();

var stopwatch = Stopwatch.StartNew();
var faker = new Faker<Dictionary<string, object?>>()
    .CustomInstantiator(f =>
    {
        var data = new Dictionary<string, object?>();
        foreach (var column in columns)
            switch (column.DataType)
            {
                case "bigint" or "int" when column.Extra.Contains("auto_increment"):
                    data.Add(column.ColumnName, null);
                    break;
                case "bigint":
                    data.Add(column.ColumnName, f.Random.Long());
                    break;
                case "int":
                    data.Add(column.ColumnName, f.Random.Int());
                    break;
                case "varchar":
                    data.Add(column.ColumnName, f.Random.String2(1, column.Length ?? int.MaxValue));
                    break;
                case "date":
                    data.Add(column.ColumnName, f.Date.Past(50));
                    break;
            }

        return data;
    });

var users = faker.Generate(100_0000);
stopwatch.Stop();
// 百万数据生成耗时大约 14 秒
Console.WriteLine($"百万测试数据生成耗时 {stopwatch.ElapsedMilliseconds} ms");
// output to csv file
stopwatch.Restart();
var tmpFilePath = Path.GetTempFileName();
Console.WriteLine(tmpFilePath);
await using var writer = new StreamWriter(tmpFilePath, false, Encoding.UTF8);
await writer.WriteLineAsync(string.Join(",", columns.Select(column => column.ColumnName)));
foreach (var user in users)
    await writer.WriteLineAsync(string.Join(",", columns.Select(column => user[column.ColumnName]).ToList()));
writer.Close();
stopwatch.Stop();
// 百万数据写入 csv 文件大于耗时 4 ~5 秒
Console.WriteLine($"百万测试数据写入文件耗时 {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Restart();
await connection.OpenAsync();
var bulkLoader = new MySqlBulkLoader(connection)
{
    TableName = "t_user",
    FileName = tmpFilePath,
    FieldTerminator = ",",
    LineTerminator = "\n",
    // Skip title line
    NumberOfLinesToSkip = 1,
    CharacterSet = "utf8mb4",
    Local = true
};

bulkLoader.Columns.AddRange(columns.Select(column => column.ColumnName.Underscore()));

await bulkLoader.LoadAsync();

if (File.Exists(tmpFilePath))
{
    File.Delete(tmpFilePath);
}

stopwatch.Stop();
// 百万数据写入数据库耗时 16 秒
Console.WriteLine($"百万测试数据写入数据库耗时 {stopwatch.ElapsedMilliseconds} ms");