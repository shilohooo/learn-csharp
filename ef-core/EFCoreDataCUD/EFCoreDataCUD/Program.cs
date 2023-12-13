using Microsoft.Extensions.Configuration;

namespace EFCoreDataCUD;

/// <summary>
/// EFCore 数据增删改操作
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        using var context = new SchoolContext(GetAppConfig());
        // AddStudent(context);
        // UpdateStudentInfo(context);
        DeleteStudent(context);
    }

    /// <summary>
    /// 获取应用配置信息
    /// </summary>
    /// <returns>应用配置信息</returns>
    public static IConfiguration GetAppConfig()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", true, true)
            .Build();
    }

    /// <summary>
    /// 添加学生信息
    /// <param name="context">数据上下文对象</param>
    /// </summary>
    public static void AddStudent(SchoolContext context)
    {
        var grade = new Grade { GradeName = "二年级" };
        var student = new Student { FirstName = "shiloh", LastName = "lee", Grade = grade };
        // 将新建的实体添加到数据上下文的实体集合中
        context.Students.Add(student);
        // 这样子也能添加
        // context.Add(student);
        // 对于 key 属性没有值的实体，添加到数据上下文后，它的状态为 "Added"
        // 当调用数据上下文的 SaveChanges() 方法时，这些处于 "Added" 状态的实体将会被新增到数据库对于的表中
        context.SaveChanges();
    }

    /// <summary>
    /// 更新学生信息
    /// <param name="context">数据上下文对象</param>
    /// </summary>
    public static void UpdateStudentInfo(SchoolContext context)
    {
        // 从数据库中查询出的数据转换的实体处于 "Unchanged" 状态，EF Core 会自动跟踪这些实体的变更
        var student = context.Students.Find(4);
        if (student is null)
        {
            return;
        }

        // 当修改这些实体中的任一属性的值时， EF Core 会自动将这些实体的状态标记为 "Modified"
        student.LastName = "Lee";
        // 当调用数据上下文的 SaveChanges() 方法时，EF Core 会对这些处于 "Modified" 状态的实体对应的记录执行 Update 操作
        // 并且在 Update SQL 中只包含修改过的属性对应的字段，没修改的属性会被忽略
        context.SaveChanges();
    }

    /// <summary>
    /// 删除学生
    /// </summary>
    /// <param name="context">数据上下文对象</param>
    public static void DeleteStudent(SchoolContext context)
    {
        // 查询出要删除的数据
        var student = context.Students.Find(4);
        if (student is null)
        {
            return;
        }

        // 删除数据
        context.Students.Remove(student);
        // 这样也可以删除，当调用 Remove() 方法后，实体将会被标记为 "Deleted" 状态
        context.Remove(student);
        // 保存变更，真正到数据库删除表对应记录，EF Core 将会执行 SQL： Delete from Students where StudentId = ?
        // 根据主键来删除对应的表记录
        context.SaveChanges();
    }
}