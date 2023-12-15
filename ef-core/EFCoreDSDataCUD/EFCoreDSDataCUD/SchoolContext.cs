using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EFCoreDSDataCUD;

/// <summary>
/// EF Core 数据上下文
/// </summary>
public class SchoolContext : DbContext
{
    /// <summary>
    /// 学生实体集合
    /// </summary>
    public DbSet<Student> Students { get; set; }

    /// <summary>
    /// 年级实体集合
    /// </summary>
    public DbSet<Grade> Grades { get; set; }

    private readonly IConfiguration _configuration;

    public SchoolContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// 数据库连接配置
    /// </summary>
    /// <param name="optionsBuilder">数据上下文配置项 builder</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("SchoolDbConnectionString");
        Console.WriteLine($"Database connection string is: {connectionString}");
        optionsBuilder.UseSqlServer(connectionString)
            // 设置日志级别，日志输出到控制台
            .LogTo((_, level) => level == LogLevel.Information, Console.WriteLine)
            // 在日志中打印敏感数据，如实体的主键值
            .EnableSensitiveDataLogging();
    }
}