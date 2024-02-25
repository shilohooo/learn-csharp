using Crud.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.EFCore;

/// <summary>
/// 学生数据上下文
/// </summary>
public class StudentDbContext(DbContextOptions options) : DbContext(options)
{
    /// <summary>
    /// 学生实体集
    /// </summary>
    public DbSet<Student> Students { get; set; }

    /// <summary>
    /// 在改方法中指定实体的主键
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 将学生的 ID 属性指定为主键
        modelBuilder.Entity<Student>()
            .HasKey(student => student.Id);
    }
}