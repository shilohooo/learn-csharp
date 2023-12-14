using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreDataQuery;

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

    private IConfiguration _configuration;

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
            // 日志输出到控制台
            .LogTo(Console.WriteLine);
    }
}