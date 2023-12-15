using Microsoft.EntityFrameworkCore;

namespace EFCoreFluentApi;

/// <summary>
/// 数据上下文
/// </summary>
public class FluentApiConfigContext : DbContext
{
    /// <summary>
    /// 学生实体集合
    /// </summary>
    public DbSet<Student> Students { get; set; }

    /// <summary>
    /// 配置数据库连接字符串
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=FluentApiConfig;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connStr);
    }

    /// <summary>
    /// 修改实体创建默认配置
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .Property(student => student.Id)
            // 设置字段名称
            .HasColumnName("StuId")
            // 设置字段默认值
            .HasDefaultValue(0)
            // 设置字段注释信息
            .HasComment("主键")
            // 设置不能为 null，传入 false代表可以为 null
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(student => student.Name)
            // 配置字段数据类型
            .HasColumnType("nvarchar")
            // 配置字段长度
            .HasMaxLength(50)
            .HasComment("学生姓名");

        modelBuilder.Entity<Student>()
            .Property(student => student.Sex)
            .HasMaxLength(50)
            // 非必填
            .IsRequired(false);
    }
}