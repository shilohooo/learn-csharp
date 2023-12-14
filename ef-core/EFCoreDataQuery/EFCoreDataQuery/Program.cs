using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreDataQuery;

/// <summary>
/// C# EF Core 数据查询
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        using var context = new SchoolContext(GetAppConfig());
        // 查询学生信息
        var students = context.Students
            // FromSql 方法用于手写 SQL，该接收的参数是模板字符串
            // Include() 方法还可以跟在 FromSql() 方法后面
            .FromSql($"SELECT * FROM Students WHERE LastName = N'张'")
            // .Where(student => student.LastName == "张")
            // 立即加载学生关联的年级信息，使用 lambda 表达式指定关联的属性
            // 关联的属性将会和学生数据在一条 SQL 内加载（关联查询）
            .Include(student => student.Grade)
            // 也可以直接指定关联的属性名称，但不推荐这么做
            // 假设属性名称拼写错误，或者该属性不存在，运行的时候会报错
            // 使用 lambda 表达式返回关联属性，错误可以在编译器就被发现
            // .Include("Grade")
            // 加载更多的关联属性
            // .Include(student => student.StudentCourses)
            // ThenInclude() 方法可以加载关联属性的关联属性，该方法必须在 Include() 方法后面调用
            // .ThenInclude(grade => grade.Teachers)
            .ToList();
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }

        // 投影查询
        var studentProjection = context.Students
            .Where(student => student.LastName == "张")
            // 使用 Select() 方法将学生实体和年级实体包含在查询结果中
            // 该方式执行的 SQL 与用 Include() 方法设置要加载的关联属性是一样的
            .Select(student => new
            {
                Student = student, student.Grade
            })
            .FirstOrDefault();
        if (studentProjection is null)
        {
            return;
        }

        Console.WriteLine($"student: {studentProjection.Student}");
        Console.WriteLine($"grade: {studentProjection.Grade}");
    }

    /// <summary>
    /// 获取应用配置信息
    /// </summary>
    /// <returns>配置对象</returns>
    private static IConfiguration GetAppConfig()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            // 将 Json 配置文件添加到应用配置中
            .AddJsonFile("appsettings.json", true, true)
            .Build();
    }
}