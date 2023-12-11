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
        // 实例化数据库上下文对象，使用 using 关键字自动释放资源，类似 Java 中的 try-with-resources
        using var context = new SchoolContext();
        // 如果数据库不存在，则创建
        context.Database.EnsureCreated();

        // 创建实体对象
        var grade = new Grade { GradeName = "一年级" };
        var student = new Student { FirstName = "三三", LastName = "张", Grade = grade };

        // 将实体添加到数据库上下文
        context.Students.Add(student);

        // 保存数据到数据库表中
        context.SaveChanges();

        // 从数据库中查询所有学生信息
        foreach (var item in context.Students)
        {
            Console.WriteLine(item);
        }
    }
}