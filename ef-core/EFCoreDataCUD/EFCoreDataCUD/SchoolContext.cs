using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreDataCUD;

/// <summary>
/// 学校数据上下文
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

    /// <summary>
    /// 应用配置信息
    /// </summary>
    private readonly IConfiguration _configuration;

    public SchoolContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// 配置数据库连接
    /// </summary>
    /// <param name="optionsBuilder">数据上下文配置项 builder</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("SchoolDbConnectionString");
        Console.WriteLine($"connectionString: {connectionString}");
        optionsBuilder.UseSqlServer(connectionString);
    }
}