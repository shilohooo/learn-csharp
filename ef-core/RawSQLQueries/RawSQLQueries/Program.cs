using Microsoft.EntityFrameworkCore;

namespace RawSQLQueries;

/// <summary>
/// EF Core 中的原生 SQL 查询
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        using var ctx = new SchoolContext();
        // var newStudent = new Student { FirstName = "Bruce", LastName = "Lee" };
        // ctx.Add(newStudent);
        // ctx.SaveChanges();

        // ef core 数据集提供了执行原生 SQL 查询的方法 DbSet.FromSql()，用于在底层数据库执行原生 SQL 查询
        // 并将查询结果以实体对象返回
        const string firstName = "Bruce";
        var students = ctx.Students
            // .FromSql($"select * from Students where FirstName = 'Bruce'")
            // 参数化查询：使用插值字符串来动态设置参数
            // .FromSqlInterpolated($"select * from Students where FirstName = {firstName}")
            // 或者使用参数占位符
            .FromSqlRaw("select * from Students where FirstName = {0}", firstName)
            // 原生 SQL 查询后面还可以跟 LINQ 操作
            .OrderBy(s => s.Id)
            .ToList();
        // FromSql() 方法的一些限制：
        // 1.查询必须返回与指定数据集的实体类型相同的实体类型
        // 2.必须返回表中的所有字段
        // 3.不能查询关联数据，即无法使用 Join（可以在 FromSql() 方法后面使用 Include() 方法来查询关联数据）
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
}