namespace EFCoreLogging;

/// <summary>
/// EF Core 日志配置
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        using var context = new SchoolContext();
        // 新增
        // var student = new Student { FirstName = "Bruce", LastName = "Lee" };
        // context.Add(student);
        // context.SaveChanges();

        // 查询所有学生信息
        // var students = context.Students.ToList();
        // foreach (var item in students)
        // {
        //     Console.WriteLine(item);
        // }

        // 根据 ID 查询学生信息
        const int id = 1;
        var student = context.Students.FirstOrDefault(s => id == s.Id);
        Console.WriteLine(student);

        if (student is null)
        {
            return;
        }

        // 修改学生信息
        // student.LastName = "Tom";
        // context.Update(student);
        // context.SaveChanges();

        // 删除学生信息
        context.Remove(student);
        context.SaveChanges();
    }
}