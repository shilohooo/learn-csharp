using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
    /// <remarks>
    /// 最常见的数据库连接字符串格式为：<br/>
    /// Server={server_address};Database={database_name};UserId={username};Password={password};<br/>
    /// 如果启用了 Windows 身份验证，可以将 UserId={username};Password={password}; 替换为 Trusted_Connection=True;
    /// 如下所示：<br/>
    /// Server={server_address};Database={database_name}; Trusted_Connection={true or false};<br/>
    /// 另外一种数据库连接字符串格式为：<br/>
    /// "Data Source=={server_address};Initial Catalog={database_name};Integrated Security=True;"
    /// 上面这种格式使用 Windows 身份验证进行登录，无需提供帐号密码，连接将会使用 Windows 用户凭证进行身份验证。<br/>
    /// </remarks>
    /// </summary>
    private const string ConnectionString =
        @"Server=(localdb)\MSSQLLocalDB;Database=SchoolDb;Trusted_Connection=True;";

    /// <summary>
    /// 学生实体集
    /// </summary>
    public DbSet<Student> Students { get; set; }

    /// <summary>
    /// 年级实体集
    /// </summary>
    public DbSet<Grade> Grades { get; set; }

    /// <summary>
    /// 应用配置信息
    /// </summary>
    private IConfiguration _appConfig;

    public SchoolContext(IConfiguration appConfig)
    {
        _appConfig = appConfig;
    }

    /// <summary>
    /// 重写该方法，用于配置数据库连接
    /// <remarks>
    /// 创建上下文实例时，会调用该方法<br/>
    /// EF Core 有几种管理数据库连接字符串的方式：<br/>
    /// 1. 硬编码：Server=(localdb)\MSSQLLocalDB;Database=SchoolDb;Trusted_Connection=True;<br/>
    /// 2.使用 Microsoft.Extensions.Configuration 的 appsettings.json 文件配置数据库连接字符串，灵活性高，如果
    /// 项目中没有 appsettings.json 文件，则需要通过 NuGet 安装 Microsoft.Extensions.Configuration 包
    /// </remarks>
    /// </summary>
    /// <param name="optionsBuilder">选项构建对象</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // 指定数据库连接字符串，使用 SQL Server 作为数据库提供程序
        // 如果要连接的数据库不存在，EF API 会自动创建该数据库
        // optionsBuilder.UseSqlServer(ConnectionString);
        
        // 从应用配置信息中获取数据库连接字符串
        var connectionString = _appConfig.GetConnectionString("SchoolDBLocalConnection");
        Console.WriteLine($"connectionString: {connectionString}");
        optionsBuilder.UseSqlServer(connectionString);
    }
}