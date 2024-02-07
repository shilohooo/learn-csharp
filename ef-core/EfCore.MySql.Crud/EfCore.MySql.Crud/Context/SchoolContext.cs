using EfCore.MySql.Crud.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EfCore.MySql.Crud.Context;

///  <summary>
/// 学校数据库上下文
/// </summary>
public class SchoolContext(IConfiguration configuration) : DbContext
{
    #region Private Fields

    private readonly IConfiguration _configuration = configuration;

    #endregion

    #region EntityProperties

    public DbSet<Student>? Student { get; set; }

    public DbSet<StudentFace>? StudentFace { get; set; }

    #endregion

    #region Methods

    /// <summary>
    /// 数据库连接配置
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(GetDbConnStr())
            .LogTo(Console.WriteLine, GetLogLevel());
    }

    /// <summary>
    /// 获取数据库连接字符串
    /// </summary>
    /// <returns>数据库连接字符串</returns>
    private string GetDbConnStr()
    {
        return _configuration
            .GetSection("ConnectionStrings")
            ["Dev"]!;
    }

    /// <summary>
    /// 获取日志等级配置
    /// </summary>
    /// <returns>日志等级</returns>
    private LogLevel GetLogLevel()
    {
        return _configuration.GetSection("Logging:LogLevel")["Default"] switch
        {
            "Debug" => LogLevel.Debug,
            "Information" => LogLevel.Information,
            "Warning" => LogLevel.Warning,
            "Error" => LogLevel.Error,
            _ => LogLevel.Information
        };
    }

    #endregion
}