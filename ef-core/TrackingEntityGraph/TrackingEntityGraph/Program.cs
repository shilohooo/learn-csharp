using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TrackingEntityGraph;

/// <summary>
/// Tracking Entity Graph
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var student = new Student
        {
            //Root entity (with key value)
            StudentId = 1,
            Name = "Bill",
            StudentAddress = new StudentAddress() //Child entity (with key value)
            {
                StudentAddressId = 1,
                City = "Seattle",
                Country = "USA"
            },
            StudentCourses = new List<StudentCourse>
            {
                new() { Course = new Course() { CourseName = "Machine Language" } }, //Child entity (empty key)
                new() { Course = new Course() { CourseId = 2 } } //Child entity (with key value)
            }
        };
        // 自定义设置实体状态的逻辑
        using var ctc = new TrackingEntityGraphContext();
        ctc.ChangeTracker.TrackGraph(student, node =>
        {
            // 如果实体设置了主键属性，那就将它的状态设置为 Unchanged，否则就将实体的状态设置为 Added
            node.Entry.State = node.Entry.IsKeySet ? EntityState.Unchanged : EntityState.Added;
        });
        DisplayState(ctc.ChangeTracker.Entries());
    }

    /// <summary>
    /// 打印实体状态
    /// </summary>
    /// <param name="entries">实体条目集</param>
    private static void DisplayState(IEnumerable<EntityEntry> entries)
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State.ToString()}");
        }
    }
}