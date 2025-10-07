using System.Data;
using System.Diagnostics;
using Bogus;
using Dapper;
using Dapper.SqlServer.BulkCopy;
using Microsoft.Data.SqlClient;

const string connectionString =
    "Server=127.0.0.1,1433;Initial Catalog=DapperTest;User ID=sa;Password=<YOUR_PASSWORD_FROM_ENV>;TrustServerCertificate=true;";
await using var connection = new SqlConnection(connectionString);

#region Get column metadata

const string sql = """
                   SELECT
                       c.column_id as ColumnId,
                       c.name AS ColumnName,
                       t.name AS DataType,
                       c.max_length AS MaxLength,
                       c.is_nullable AS IsNullable,
                       c.is_identity AS IsIdentity
                   FROM
                       sys.columns c
                           INNER JOIN
                       sys.types t ON c.user_type_id = t.user_type_id
                   WHERE
                       object_id = OBJECT_ID(@TableName, 'U')
                   ORDER BY
                       column_id;
                   """;

var columns = (await connection.QueryAsync<Column>(sql, new { TableName = "T_User" })).ToList();

#endregion

#region Generate test data

var stopwatch = Stopwatch.StartNew();
var colNames = columns.Where(column => !column.IsIdentity)
    .Select(column => column.ColumnName)
    .ToList();
var faker = new Faker<Dictionary<string, object?>>()
    .CustomInstantiator(f =>
    {
        var data = new Dictionary<string, object?>();
        foreach (var colName in colNames)
        {
            if (colName.Contains("name", StringComparison.CurrentCultureIgnoreCase))
            {
                data.Add(colName, f.Internet.UserName());
                continue;
            }
        
            if (colName.Contains("age", StringComparison.CurrentCultureIgnoreCase))
            {
                data.Add(colName, f.Random.Int(1, 100));
                continue;
            }
        
            if (!colName.Contains("birth", StringComparison.CurrentCultureIgnoreCase)) continue;
        
            // DO NOT USE f.Person.*, IS VERY SLOW!
            data.Add(colName, f.Date.Past(80).ToString("yyyy-MM-dd"));
        }

        return data;
    });

var users = faker.Generate(100_0000);
stopwatch.Stop();
// 生成百万测试数据大约需要 48 秒
Console.WriteLine($"生成一百万条测试数据耗时：{stopwatch.ElapsedMilliseconds} ms");

#endregion

#region Bulk copy

stopwatch.Restart();
await connection.OpenAsync();
using var sqlBulkCopy = new SqlBulkCopy(connection);
sqlBulkCopy.DestinationTableName = "T_User";
sqlBulkCopy.BatchSize = 10000;
sqlBulkCopy.BulkCopyTimeout = 30;


var dataTable = new DataTable();
foreach (var colName in colNames)
{
    sqlBulkCopy.ColumnMappings.Add(colName, colName);
    dataTable.Columns.Add(colName);
}

foreach (var user in users)
{
    var dataRow = dataTable.NewRow();
    foreach (var colName in colNames)
    {
        dataRow[colName] = user[colName];
    }
    dataTable.Rows.Add(dataRow);
}
await sqlBulkCopy.WriteToServerAsync(dataTable);
stopwatch.Stop();
// 批量插入百万数据大约需要 7 ~ 8 秒
Console.WriteLine($"批量插入一百万条测试数据耗时：{stopwatch.ElapsedMilliseconds} ms");

#endregion