using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DisconnectedEntityGraph;

/// <summary>
/// 断开连接场景（Disconnected Scenario）下，实体状态的变更方式
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var student = new Student
        {
            //Root entity (empty key)
            Name = "Bill",
            StudentAddress = new StudentAddress() //Child entity (with key value)
            {
                StudentAddressId = 1,
                City = "Seattle",
                Country = "USA"
            },
            StudentCourses = new List<StudentCourse>()
            {
                new() { Course = new Course { CourseName = "Machine Language" } }, //Child entity (empty key)
                new() { Course = new Course { CourseId = 2 } } //Child entity (with key value)
            }
        };
        var context = new DisconnectedEntityGraphContext();
        UsingAttach(context, student);
    }

    /// <summary>
    /// 使用 Attach() 方法将实体附加到数据上下文
    /// <table>
    /// <thead>
    /// 
    /// </thead>
    /// </table>
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="student">学生实体</param>
    private static void UsingAttach(DbContext context, Student student)
    {
        context.Attach(student).State = EntityState.Added;
        DisplayStates(context.ChangeTracker.Entries());
    }

    /// <summary>
    /// 打印实体状态
    /// </summary>
    /// <param name="entries">实体条目列表</param>
    private static void DisplayStates(IEnumerable<EntityEntry> entries)
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State.ToString()} ");
        }
    }
}