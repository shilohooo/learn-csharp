using Microsoft.EntityFrameworkCore;

namespace EFCoreQuickStart;

/// <summary>
/// 代表数据库会话，可以查询数据和保存数据到数据库中
/// <remarks>
/// <para>DbContext的功能：</para>
/// <para>管理数据库连接</para>
/// <para>配置模型 & 关系</para>
/// <para>查询数据库</para>
/// <para>保存数据到数据库</para>
/// <para>配置变更跟踪</para>
/// <para>缓存</para>
/// <para>事务管理</para>
///
/// <para>在上下文中需要定义实体集，上下文会跟着这些实体的变更，并自动执行CRUD操作</para>
/// </remarks>
/// </summary>
public class SchoolContext : DbContext
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    private const string ConnectionString =
        @"Server=(localdb)\ProjectModels;Database=SchoolDb;Trusted_Connection=True;";

    /// <summary>
    /// 学生实体集
    /// </summary>
    public DbSet<Student> Students { get; set; }

    /// <summary>
    /// 年级实体集
    /// </summary>
    public DbSet<Grade> Grades { get; set; }

    /// <summary>
    /// 重写该方法，用于配置数据库连接
    /// <remarks>创建上下文实例时，会调用该方法</remarks>
    /// </summary>
    /// <param name="optionsBuilder">选项构建对象</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // 指定数据库连接字符串，使用 SQL Server 作为数据库提供程序
        // 如果要连接的数据库不存在，EF API 会自动创建该数据库
        optionsBuilder.UseSqlServer(ConnectionString);
    }
}