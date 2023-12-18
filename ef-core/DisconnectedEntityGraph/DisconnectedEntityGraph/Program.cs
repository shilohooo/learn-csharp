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
            StudentId = 1,
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
        // UsingAttach(context, student);
        // UsingEntry(context, student);
        // UsingAdd(context, student);
        // UsingUpdate(context, student);
        UsingRemove(context, student);
    }

    /// <summary>
    /// 使用 Attach() 方法将实体附加到数据上下文
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="student">学生实体</param>
    private static void UsingAttach(DbContext context, Student student)
    {
        // Attach() 直接修改实体的状态
        // 此时：根实体的状态为 Added，而子实体的状态则会根据主键属性的值来设置状态
        // 如果子实体的主键属性值为空，或值是其数据类型的默认值，那么子实体的状态将会被标记为 Added
        // 如果子实体的主键属性值不为空，且值不是其数据类型的默认值，那么子实体的状态将会被标记为 Unchanged 
        // context.Attach(student).State = EntityState.Added;

        // 将实体的状态修改为 Modified，此时如果根实体的主键属性值为空，或者值是其数据类型的默认值，就会抛出 InvalidOperationException 异常
        // 如果根实体的主键属性值不为空，且值不是其数据类型的默认值，那么根实体状态就是 Modified
        // 对于子实体，如果主键属性值为空或者值是其数据类型的默认值，那么子实体的状态将会被标记为 Added
        // 如果子实体的主键属性值不为空，且值不是其数据类型的默认值，那么子实体的状态将会被标记为 Unchanged
        // context.Attach(student).State = EntityState.Modified;

        // 将实体的状态修改为 Deleted，此时如果根实体的主键属性值为空，或者值是其数据类型的默认值，就会抛出 InvalidOperationException 异常
        // 如果根实体的主键属性值不为空，且值不是其数据类型的默认值，那么根实体状态就是 Deleted

        // 对于子实体，如果主键属性值为空或者值是其数据类型的默认值，且关联关系为一对一，那么子实体不会附加到数据上下文
        // 如果关联关系为多对多，那么子实体的状态会被设置为 Added

        // 如果子实体的主键属性值不为空，且值不是其数据类型的默认值，且关联关系为一对一，那么子实体的状态将会被标记为 Deleted
        // 如果关联关系为多对多，那么子实体的状态会被设置为 Unchanged
        context.Attach(student).State = EntityState.Deleted;
        DisplayStates(context.ChangeTracker.Entries());
    }

    /// <summary>
    /// 使用数据上下文的 Entry() 方法修改实体状态
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="student">学生实体</param>
    private static void UsingEntry(DbContext context, Student student)
    {
        // Entry() 方法会将实体的状态改为指定的状态，不管实体的主键属性是否有值
        // 且只会设置根实体的状态，子实体将被忽略
        // context.Entry(student).State = EntityState.Added;
        // context.Entry(student).State = EntityState.Modified;
        context.Entry(student).State = EntityState.Deleted;
        DisplayStates(context.ChangeTracker.Entries());
    }

    /// <summary>
    /// 使用数据上下文的 Add() 方法将实体附加到数据上下文中
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="student">学生实体</param>
    private static void UsingAdd(DisconnectedEntityGraphContext context, Student student)
    {
        // Add() 方法会将根实体和子实体的状态都设置为 Added，不管这些实体的主键属性是否有值
        // context.Add(student);
        context.Students.Add(student);
        DisplayStates(context.ChangeTracker.Entries());
    }

    /// <summary>
    /// 使用 Update() 方法将实体附加到数据上下文中
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="student">学生实体</param>
    private static void UsingUpdate(DisconnectedEntityGraphContext context, Student student)
    {
        // Update() 方法根据实体的主键属性来设置它们的状态
        // 如果实体的主键属性值为空，或值是其数据类型的默认值，那么实体的状态将被设置为 Added
        // 如果实体的主键属性值不为空，且值不是其数据类型的默认值，那么实体的状态将被设置为 Modified
        // context.Update(student);
        context.Students.Update(student);
        DisplayStates(context.ChangeTracker.Entries());
    }

    /// <summary>
    /// 使用 Remove() 方法修改实体的状态
    /// </summary>
    /// <param name="context">数据上下文</param>
    /// <param name="student">学生实体</param>
    private static void UsingRemove(DisconnectedEntityGraphContext context, Student student)
    {
        // Remove() 会将根实体的状态修改为 Deleted，如果根实体的主键属性值为空，或值是其数据类型的默认值
        // 那就会抛出 InvalidOperationException 异常

        // 而对于子实体，区分一对一和多对多的情况
        // 一对一：根据子实体的主键属性值来处理
        // 假设子实体的主键属性值为空，或值是其数据类型的默认值，那么子实体将被忽略，不予处理
        // 假设子实体的主键属性值不为空，且值不是其数据类型的默认值，那么子实体的状态也会被标记为 Deleted

        // 多对多：也是根据子实体的主键属性值来处理，但处理方式和一对一不同
        // 假设子实体的主键属性值为空，或值是其数据类型的默认值，那么子实体的状态也会被标记为 Added
        // 假设子实体的主键属性值不为空，且值不是其数据类型的默认值，那么子实体的状态也会被标记为 Unchanged
        // context.Remove(student);
        context.Students.Remove(student);
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