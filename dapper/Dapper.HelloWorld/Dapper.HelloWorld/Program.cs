// Dapper exapmle

using Dapper;
using Dapper.HelloWorld.Entities;
using Dapper.HelloWorld.Handlers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true)
    .Build();
// connection string
var connStr = string.Format(config.GetConnectionString("Default")!, Environment.GetEnvironmentVariable("DB_PWD"));

await using SqlConnection connection = new(connStr);

#region insert

// await connection.ExecuteAsync("insert into T_Users(Name, Age, Birth) values (@Name, @Age, @Birth)",
// new { Name = "Shiloh", Age = 18, Birth = DateOnly.FromDateTime(DateTime.Now).ToDateTime(new TimeOnly(0, 0, 0)) });

#endregion

#region bulk insert

// IEnumerable<UserEntity> users = Enumerable.Range(0, 10).Select(i =>
//     new UserEntity { Name = $"TestUser-{i}", Age = i, Birth = new DateOnly(1990 + i, 1 + i, 1 + i) });
// await connection.ExecuteAsync("insert into T_Users(Name, Age, Birth) values (@Name, @Age, @Birth)", users);

#endregion

#region delete

await connection.ExecuteAsync("delete from T_Users where Id = @Id", new { Id = 2 });

#endregion

#region update

await connection.ExecuteAsync("update T_Users set Enabled = 0 where Id = @Id", new { Id = 1 });

#endregion

#region query

// find all users
var res = await connection.QueryAsync<UserEntity>("select * from T_Users");
res.ToList().ForEach(Console.WriteLine);

Console.WriteLine("======================================================");

// find all users by ids in
res = await connection.QueryAsync<UserEntity>("select * from T_Users where Id in @Ids", new { Ids = (int[]) [1, 2, 3] });
res.ToList().ForEach(Console.WriteLine);

#endregion