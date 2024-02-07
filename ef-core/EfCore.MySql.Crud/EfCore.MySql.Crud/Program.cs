using System.Linq.Expressions;

namespace EfCore.MySql.Crud;

/// <summary>
/// EF Core MySql 增删改查示例
/// </summary>
internal abstract class Program
{
    public static void Main(string[] args)
    {
        // var config = BuildConfigFromJsonFile();
        // // 读取当前配置的数据库连接字符串
        // Console.WriteLine($"数据库连接字符串：{config.GetConnectionString("Dev")}");
        // // 读取当前配置的默认日志等级
        // Console.WriteLine($"默认日志等级：{config.GetSection("Logging:LogLevel")["Default"]}");

        // using var context = new SchoolContext(ConfigurationFactory.BuildConfigFromJsonFile());
        // context.Database.EnsureCreated();
        // Console.WriteLine($"当前共有{context.Student?.LongCount()}条学生信息");

        Expression<Func<int, int, int>> sum = (numA, numB) => numA + numB;
        var sumDelegate = sum.Compile();
        Console.WriteLine(sumDelegate(10, 15));

        Expression<Action<string>> myConsoleWriteLine = msg => Console.WriteLine($"msg: {msg}");
        var myConsoleWriteLineDelegate = myConsoleWriteLine.Compile();
        myConsoleWriteLineDelegate("Hello C# Expression Tree:)");
    }
}