using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using SqlSugar.MultiTenant.Demo;
using SqlSugar.MultiTenant.Demo.Entities;

// Build a config object, using JSON providers.
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.jsonc", true, true)
    .Build();

// Get db password from env
var pwd = Environment.GetEnvironmentVariable("DB_PWD");
// Get db connection string
var tenantAConnStr = string.Format(config.GetConnectionString(Constants.TenantAConfigId)!, pwd);
Console.WriteLine(tenantAConnStr);
var tenantBConnStr = string.Format(config.GetConnectionString(Constants.TenantBConfigId)!, pwd);
// create db client
List<ConnectionConfig> connConfigs =
[
    new()
    {
        ConfigId = Constants.TenantAConfigId,
        ConnectionString = tenantAConnStr,
        DbType = DbType.SqlServer,
        IsAutoCloseConnection = true
    },
    new()
    {
        ConfigId = Constants.TenantBConfigId,
        ConnectionString = tenantBConnStr,
        DbType = DbType.SqlServer,
        IsAutoCloseConnection = true
    }
];
// add db client to IOC
var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<ISqlSugarClient>(_ =>
{
    return new SqlSugarScope(connConfigs,
        db =>
        {
            connConfigs.ForEach(connConfig =>
            {
                db.GetConnectionScope(connConfig.ConfigId.ToString()).Aop.OnLogExecuting = (sql, @params) =>
                {
                    Console.WriteLine(
                        $"==================> SQL Log start - TenantConfigId: {connConfig.ConfigId} <==================");
                    Console.WriteLine(UtilMethods.GetNativeSql(sql, @params));
                    Console.WriteLine(
                        $"==================> SQL Log end - TenantConfigId: {connConfig.ConfigId} <==================");
                };
            });
        });
});
var serviceProvider = serviceCollection.BuildServiceProvider();
var dbClient = serviceProvider.GetService<ISqlSugarClient>()!;

// tenant a - do query
var users = await dbClient.Queryable<UserEntity>()
    .Where(u => u.Nickname.Equals("张三"))
    .ToListAsync();
foreach (var user in users) Console.WriteLine(user);

Console.WriteLine();

// tenant b - do query
var books = await dbClient.AsTenant().QueryableWithAttr<BookEntity>()
    .Where(b => b.Name.Contains("Book"))
    .ToListAsync();

foreach (var book in books) Console.WriteLine(book);