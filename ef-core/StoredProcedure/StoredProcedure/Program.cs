using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace StoredProcedure;

/// <summary>
/// 在 EF Core 中调用存储过程 ~ EF Core 提供了以下两种方法来调用数据库存储过程：<br/>
/// 1. DbSet.FromSql() <br/>
/// 2. DbContext.Database.ExecuteSqlCommand() <br/>
/// 上面两种方式调用数据库存储过程存在一些限制：<br/>
/// 1.结果必须是实体类型，这意味着存储过程必须返回实体对应的表的所有字段 <br/>
/// 2.结果不能包含关联数据，这意味着存储过程不能执行关联查询 <br/>
/// 3.增删改操作的存储过程无法与实体映射，因此数据上下文的 SaveChanges() 方法不能为增删改操作调用存储过程。
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        using var ctx = new SchoolContext();
        // var student = new Student { FirstName = "Bruce", LastName = "Lee" };
        // ctx.Add(student);
        // ctx.SaveChanges();

        // UsingFromSql(ctx);

        UsingExecuteSql(ctx);
    }

    /// <summary>
    /// 使用实体集的 FromSql() 调用数据库存储过程
    /// </summary>
    /// <param name="ctx">数据上下文</param>
    /// <exception cref="NotImplementedException"></exception>
    private static void UsingFromSql(SchoolContext ctx)
    {
        const string firstName = "Bruce";
        // 还可以使用 SqlParameter 指定输入（IN）参数或输出（OUT）参数
        var sqlParameter = new SqlParameter("@FirstName", firstName);
        var students = ctx.Students
            // .FromSqlRaw("GetStudents 'Bruce'")
            // 参数化查询：使用字符串插值语法完成
            // .FromSqlInterpolated($"exec GetStudents {firstName}")
            // 或者使用参数占位符
            // .FromSqlRaw("exec GetStudents {0}", firstName)
            // .FromSqlRaw("GetStudents @FirstName", sqlParameter)
            // 还可以使用 @pn 的方式指定第 n 个参数，第一个参数从 0 开始
            .FromSqlRaw("GetStudents @p0", firstName)
            .ToList();
        DisplayStudents(students);
    }

    /// <summary>
    /// 使用数据上下文中 Database 属性的 ExecuteSqlXxx 来执行数据库命令，该方法返回 SQL 执行受影响的行数
    /// </summary>
    /// <param name="context"></param>
    private static void UsingExecuteSql(DbContext context)
    {
        const string firstName = "Rose";
        const string lastName = "Chen";
        // var rowsAffected = context.Database.ExecuteSqlRaw("Update Students set FirstName = 'Shiloh' where Id = 1");
        // 调用存储过程
        var rowsAffected = context.Database.ExecuteSqlRaw("CreateStudent @p0, @p1", firstName, lastName);
        Console.WriteLine($"执行 SQL 后受影响的行数为：{rowsAffected}");
    }

    /// <summary>
    /// 打印学生信息
    /// </summary>
    /// <param name="students">学生列表</param>
    private static void DisplayStudents(IEnumerable<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
}