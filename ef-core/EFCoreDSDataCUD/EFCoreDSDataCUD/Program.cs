using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreDSDataCUD;

/// <summary>
/// C# EF Core 在断开连接的场景（Disconnected Scenario）增删改数据，数据上下文对象无法在断开连接的场景跟踪实体变更。
/// 因此，需要开发者手动为实体设置正确的状态
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // 定义 Disconnected Entity
        var grade = new Grade { GradeId = 19, GradeName = "二年级" };
        var student = new Student { FirstName = "Shiloh", LastName = "Lee", Grade = grade };
        var students = new List<Student>
        {
            new() { StudentId = 13, FirstName = "Bruce", LastName = "Lee", Grade = grade },
            new() { StudentId = 14, FirstName = "Hanks", LastName = "Tom", Grade = grade }
        };

        var dsGrade = new Grade { GradeId = 18, GradeName = "二年级" };
        var dsStudent = new Student
        {
            StudentId = 15, FirstName = "Shiloh", LastName = "Lee", GradeId = 18, Grade = dsGrade
        };
        dsStudent.FirstName = "Updated4";


        using var context = new SchoolContext(GetAppConfig());
        // 插入单条数据
        // AddStudentInfo(context, student);
        // 插入多条数据
        // AddStudents(context, students);
        // 使用实体集合插入单条数据
        // AddStudentUsingDbSet(context, student);

        // 更新 Disconnected Entity 的数据
        // UpdateStudentInfo(context, dsStudent);
        // 更新多条数据
        // UpdateStudents(context, students);

        // 删除单条数据
        // DeleteStudent(context, new Student { StudentId = 44 });
        // 删除多条数据
        var delStudents = new List<Student>
        {
            new() { StudentId = 6 },
            new() { StudentId = 7 },
            new() { StudentId = 8 }
        };
        // DeleteStudents(context, delStudents);
        // 删除关联数据
        DeleteRelatedData(context, new Grade { GradeId = 19 });

        // 查询学生信息，并同时加载出学生所属的年级信息
        QueryStudents(context);
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

    /// <summary>
    /// 插入学生信息
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="student">学生实体</param>
    private static void AddStudentInfo(DbContext context, Student student)
    {
        // 1. 将实体添加到数据上下文，此时它的状态将会被设置为 "Added"
        // context.Add(student);

        // 2. 也可以用下面这种方式
        // context.Students.Add(student);
        // 手动设置实体的状态
        // context.Entry(student).State = EntityState.Added;

        // 3. 还可以将实体附加到数据上下文中，Attach() 会根据实体是否设置了主键属性的值来设置实体的状态
        // 如果实体未设置主键属性的值，则它的状态会被标记为 "Added"
        // 如果实体的主键属性已有值，则它的状态会被标记为 "Unchanged"
        context.Attach(student);

        Console.WriteLine($"Student Entity State = {context.Entry(student).State}");
        Console.WriteLine($"Grade Entity State = {context.Entry(student.Grade).State}");

        context.SaveChanges();
    }

    /// <summary>
    /// 添加多个学生信息
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="students">学生列表</param>
    private static void AddStudents(DbContext context, IEnumerable<Student> students)
    {
        context.AddRange(students);
        context.SaveChanges();
    }

    /// <summary>
    /// 使用实体集合添加学生信息
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="student">学生信息</param>
    private static void AddStudentUsingDbSet(SchoolContext context, Student student)
    {
        // 将实体附加到数据上下文，并标记为 "Added" 状态
        context.Students.Add(student);
        context.SaveChanges();
    }

    /// <summary>
    /// 查询学生信息
    /// </summary>
    /// <param name="context">数据上下文</param>
    private static void QueryStudents(SchoolContext context)
    {
        var list = context.Students
            .Include(item => item.Grade)
            .ToList();
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    /// <summary>
    /// 更新学生信息
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="student">学生信息</param>
    private static void UpdateStudentInfo(SchoolContext context, Student student)
    {
        var trackedStudent = context.Students.First(item => item.StudentId == student.StudentId);
        // 调用数据上下文的 Update() 方法，会将实体的状态标记为 "Modified"
        // 如果传入 Update() 方法的实体的主键没有值，或者值是其数据类型的默认值
        // 那么实体的状态会被标记为 "Added"
        // 如果数据上下文已跟踪了一个 ID 与参数实体相同的实体
        // 那么在将参数实体附加到数据上下文时将会抛出：InvalidOperationException 
        // UpdateRange() 方法也具有同样的约束
        context.Update(student);
        // 或者使用下面这种方式
        // context.Students.Update(student);

        // 还可以使用 Attach() 方法将实体的状态修改为 "Modified"
        // context.Attach(student).State = EntityState.Modified;

        // 还可以使用 Entry() 方法将实体的状态修改为 "Modified"，使用 Entry() 方法修改实体的状态为 "Modified" 后，
        // 如果该实体有关联属性，那么它的关联属性（外键）不能为空，否则执行 Update 操作时会报错
        // context.Entry(student).State = EntityState.Modified;

        Console.WriteLine($"将要更新的学生实体的状态为：{context.Entry(student).State}");
        context.SaveChanges();
    }

    /// <summary>
    /// 更新多个学生信息
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="students">学生列表</param>
    private static void UpdateStudents(SchoolContext context, IEnumerable<Student> students)
    {
        // 调用数据上下文的 UpdateRange() 方法将指定集合内的实体的状态修改为 "Modified"
        context.UpdateRange(students);
        // 或者调用实体集合的 UpdateRange() 也是一样的效果
        // context.Students.UpdateRange(students);
        context.SaveChanges();
    }

    /// <summary>
    /// 删除学生信息
    /// <remarks>
    /// 注意：如果指定的学生实体的主键在数据库表中不存在，删除操作将会抛出 <see cref="DbUpdateConcurrencyException"/> 异常
    /// </remarks>
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="student">学生信息</param>
    private static void DeleteStudent(SchoolContext context, Student student)
    {
        try
        {
            // 调用数据上下文的 Remove() 来将实体的状态标记为 "Deleted"
            // context.Remove(student);

            // 或者使用以下几种方法也能达到同样的效果
            // 1.RemoveRange()
            context.RemoveRange(student);

            // 2.使用实体集合的 Remove() 方法
            // context.Students.Remove(student);

            // 3.使用实体集合的 RemoveRange() 方法
            // context.Students.RemoveRange(student);

            // 4.使用 Attach() 方法将实体的状态修改为 "Deleted"
            // context.Attach(student).State = EntityState.Deleted;

            // 5.使用 Entry() 方法将实体的状态修改为 "Deleted"
            // context.Entry(student).State = EntityState.Deleted;

            Console.WriteLine($"即将要被删除的学生实体的状态为：{context.Entry(student).State}");
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException e)
        {
            throw new Exception($"ID 为：{student.StudentId} 的学生信息在数据库表中不存在", e);
        }
    }

    /// <summary>
    /// 删除多个学生信息
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="students">学生列表</param>
    private static void DeleteStudents(DbContext context, IEnumerable<Student> students)
    {
        context.RemoveRange(students);
        context.SaveChanges();
    }

    /// <summary>
    /// 删除年级信息，以及关联的学生列表
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="grade">年级信息</param>
    private static void DeleteRelatedData(SchoolContext context, Grade grade)
    {
        // 如果在删除一个关联了其他数据的实体时，EF Core 会报错（因为外键约束），除非设置了级联操作
        // 比如级联删除
        
        context.Remove(grade);
        context.SaveChanges();
    }
}