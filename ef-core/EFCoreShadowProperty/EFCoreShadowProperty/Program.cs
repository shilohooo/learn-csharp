using Microsoft.EntityFrameworkCore;

namespace EFCoreShadowProperty;

/// <summary>
/// EF Core 中的阴影属性（shadow property），没有在实体定义，而是通过 modelBuilder 定义的，阴影属性也会映射为数据库表中的字段
/// <remarks>
/// 阴影属性存在于实体数据模型中，这些属性的值和状态是在 ChangeTracker 中维护的，即变更跟踪器中。
/// <para>阴影属性的应用场景：给每个实体设置创建时间和修改时间</para>
/// <para>什么时候才需要使用阴影属性？</para>
/// <para>1. 当不想暴露数据库表的字段到对应的实体中时</para>
/// <para>
/// 2. 当不想暴露外键属性以及只想使用一个引用导航属性来管理关联关系时，在这种情况下，EF Core 会为实体自动创建一个外键阴影属性
/// </para>
/// </remarks>
/// </summary>
public class Program
{
    /// <summary>
    /// 访问阴影属性
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        using var ctx = new ShadowPropertyContext();
        AccessShadowProperties(ctx);
        AddStudentInfo(ctx);
        QueryStudents(ctx);
    }

    /// <summary>
    /// 访问阴影属性
    /// </summary>
    /// <param name="ctx">数据上下文</param>
    private static void AccessShadowProperties(DbContext ctx)
    {
        var student = new Student { Name = "Shiloh" };
        // 通过 Entry() 方法可以访问阴影属性
        // 设置阴影属性的值
        var shadowProperty = ctx.Entry(student).Property(ShadowPropertyContext.CreatedTime);
        shadowProperty.CurrentValue = DateTime.Now;
        // 获取阴影属性的值
        var createdTime = ctx.Entry(student).Property(ShadowPropertyContext.CreatedTime).CurrentValue;
        Console.WriteLine($"createdTime: {createdTime}");
    }

    /// <summary>
    /// 新增学生信息
    /// </summary>
    /// <param name="ctx">数据上下文</param>
    private static void AddStudentInfo(DbContext ctx)
    {
        var student = new Student { Name = "Shiloh" };
        ctx.Add(student);
        ctx.SaveChanges();
    }

    /// <summary>
    /// 查询学生信息
    /// </summary>
    /// <param name="ctx">数据上下文</param>
    private static void QueryStudents(ShadowPropertyContext ctx)
    {
        foreach (var student in ctx.Students)
        {
            Console.WriteLine(student);
        }
    }
}