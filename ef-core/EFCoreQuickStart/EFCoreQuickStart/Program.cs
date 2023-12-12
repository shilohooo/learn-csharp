using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace EFCoreQuickStart;

/// <summary>
/// .NET Entity Framework Core 入门
/// <remarks>
/// 参考教程：https://www.entityframeworktutorial.net/efcore
/// </remarks>
/// </summary>
class Program
{
    /// <summary>
    /// 使用数据库上下文类的 EnsureCreated() 方法创建数据库，以及使用数据库上下文实例保存学生和年级数据到数据库中
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // var grade = new Grade { GradeName = "一年级" };
        // var disconnectedEntity = new Student { FirstName = "三三", LastName = "张", Grade = grade };
        // 实例化数据库上下文对象，传入应用配置
        // 使用 using 关键字自动释放资源，类似 Java 中的 try-with-resources
        using var context = new SchoolContext(GetAppConfig());
        // 任何在数据上下文作用域之外创建或读取的实体，它们的状态都会被标记为 "Detached"，
        // 状态为 "Detached" 的实体通常称为 "Disconnected Entity"，数据上下文不会跟踪这些实体的变更。
        // Console.WriteLine(context.Entry(disconnectedEntity).State.ToString());
        // 如果数据库不存在，则创建
        // context.Database.EnsureCreated();
        //
        // // 创建实体对象
        // var grade = new Grade { GradeName = "一年级" };
        // var student = new Student { FirstName = "三三", LastName = "张", Grade = grade };
        //
        // // 将实体添加到数据库上下文
        // context.Students.Add(student);
        //
        // // 打印实体状态
        // // 对于新创建的没有主键的实体，使用数据上下文对象的 Add() 或 Update() 方法将实体添加到数据上下文后
        // // 实体的状态将被标记为 "Added"
        // DisplayEntityState(context.ChangeTracker.Entries());
        //
        // // 保存数据到数据库表中
        // context.SaveChanges();
        //
        // 从数据库中查询所有学生信息
        foreach (var item in context.Students)
        {
            Console.WriteLine(item);
        }
        //
        // // 打印实体状态
        // // 目前没有对实体执行任何操作，所以查询出来的实体的状态应该是 "Unchanged"，
        // // 此时如果调用数据上下文对象的 SaveChanges() 方法，不会执行任何操作。
        // DisplayEntityState(context.ChangeTracker.Entries());

        // 查询实体
        // var student = context.Students.FirstOrDefault();
        // if (student is null)
        // {
        //     Console.WriteLine("Students表中还没有数据，请先添加:(");
        //     return;
        // }

        // 修改属性值
        // student.FirstName = "图图";
        // // 打印实体状态
        // // 在数据上下文作用域中，对实体的任何属性进行了修改，那么实体的状态将会被标记为 "Modified"
        // DisplayEntityState(context.ChangeTracker.Entries());
        // // 保存变更
        // context.SaveChanges();

        // 删除某个实体
        // context.Remove(student);
        // context.Students.Remove(student);
        // 打印实体状态
        // 当调用数据上下文对象的 Remove() 方法或实体集合对象 DbSet 的 Remove() 方法删除实体时，
        // 被删除的实体的状态将会被标记为 "Deleted"
        // DisplayEntityState(context.ChangeTracker.Entries());
        // 保存变更
        // context.SaveChanges();
        
        // 从环境变量中获取数据库连接字符串
        const string envKey = "MSSQLSERVER_CONNECTION_STING";
        // 第一个参数为环境变量的名称，第二个参数指定：
        // 从当前进程或者从当前用户或本地计算机的 Windows 操作系统注册表项检索环境变量的值。
        var connStr = Environment.GetEnvironmentVariable(envKey, EnvironmentVariableTarget.User);
        Console.WriteLine($"数据库连接字符串：{connStr}");
    }

    /// <summary>
    /// 获取应用配置
    /// </summary>
    /// <returns>应用配置实例</returns>
    private static IConfiguration GetAppConfig()
    {
        Console.WriteLine($"BaseDirectory: {AppDomain.CurrentDomain.BaseDirectory}");
        return new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", true, true)
            .Build();
    }

    /// <summary>
    /// 打印实体状态
    /// </summary>
    /// <param name="entries">实体变更跟踪对象集合</param>
    private static void DisplayEntityState(IEnumerable<EntityEntry> entries)
    {
        // context.ChangeTracker.Entries() 返回数据上下文对象跟踪的每个实体的 EntityEntry 集合
        foreach (var entry in entries)
        {
            // 打印实体类型的名称和实体状态
            Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State.ToString()}");
        }
    }
}