using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreLogging;

/// <summary>
/// 数据上下文
/// </summary>
public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connStr = @"Server=(localdb)\MSSQLLocalDB;Database=EFCoreLoggingDemo;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connStr)
            // 日志输出到控制台，并设置日志级别为 Information
            .LogTo(Console.WriteLine, LogLevel.Information)
            // 日志记录敏感数据，建议只在开发环境启动
            .EnableSensitiveDataLogging()
            // 日志记录更详细的错误信息
            .EnableDetailedErrors();
    }
}