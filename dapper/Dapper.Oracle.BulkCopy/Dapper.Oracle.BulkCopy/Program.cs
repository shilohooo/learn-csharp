using System.Data;
using System.Diagnostics;
using Bogus;
using Bogus.DataSets;
using Dapper;
using Dapper.Oracle.BulkCopy;
using Oracle.ManagedDataAccess.Client;

const string connectionString =
    "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=11521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=FREEPDB1 )));User Id=dev;Password=123456;";
// Connect to the database 
await using var connection = new OracleConnection(connectionString);
const string sql = """
                   select TABLE_NAME as TableName,
                          COLUMN_NAME as ColumnName,
                          DATA_TYPE as DataType,
                          DATA_LENGTH as Length,
                          case when NULLABLE = 'Y' then true else false end as IsNullable,
                          case when IDENTITY_COLUMN = 'YES' then true else false end as IsIdentity
                   from USER_TAB_COLUMNS
                   where TABLE_NAME = :TableName
                   order by COLUMN_ID
                   """;
var columns = (await connection.QueryAsync<Column>(sql, new { TableName = "T_USER" })).ToList();
var colNames = columns.Where(column => !column.IsIdentity)
    .Select(x => x.ColumnName).ToList();
var stopwatch = Stopwatch.StartNew();
stopwatch.Start();
var faker = new Faker<Dictionary<string, object?>>()
    .CustomInstantiator(f =>
    {
        var data = new Dictionary<string, object?>()
        {
            // {"ID", null},
            { "NAME", f.Name.FullName(Name.Gender.Male) },
            { "AGE", f.Random.Int(1, 100) },
            { "EMAIL", f.Internet.Email() },
            { "ADDRESS", f.Address.FullAddress() },
        };
        return data;
    });
var users = faker.Generate(100_0000);
stopwatch.Stop();
// 约 12 秒
Console.WriteLine($"百万测试数据生成耗时：{stopwatch.ElapsedMilliseconds} ms");

stopwatch.Restart();
await connection.OpenAsync();
using var bulkCopy = new OracleBulkCopy(connection);
colNames.ForEach(colName => bulkCopy.ColumnMappings.Add(colName, colName));
bulkCopy.BatchSize = 1000;
bulkCopy.BulkCopyTimeout = 60;
bulkCopy.DestinationTableName = "T_USER";

var dataTable = new DataTable();
dataTable.Columns.AddRange(colNames.Select(colName => new DataColumn(colName)).ToArray());
users.ForEach(user =>
{
    var row = dataTable.NewRow();
    colNames.ForEach(colName => row[colName] = user[colName]);
    dataTable.Rows.Add(row);
});
bulkCopy.WriteToServer(dataTable);
stopwatch.Stop();
// Oracle 23 ai free - 约 9 秒
Console.WriteLine($"百万数据写入耗时：{stopwatch.ElapsedMilliseconds} ms");