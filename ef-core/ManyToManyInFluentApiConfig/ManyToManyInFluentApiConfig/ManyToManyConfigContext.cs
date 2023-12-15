using Microsoft.EntityFrameworkCore;

namespace ManyToManyInFluentApiConfig;

/// <summary>
/// 数据上下文
/// </summary>
public class ManyToManyConfigContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connStr = @"Server=(localdb)\MSSQLLocalDB;Database=ManyToManyConfig;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connStr);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 多对多关联关系，需要将两个实体在中间表的外键配置为复合主键
        modelBuilder.Entity<StudentCourse>()
            // 在中间表里面，两个关联实体的外键组合成一个复合主键
            .HasKey(sc => new { sc.StudentId, sc.CourseId });
        // 假设两个关联实体的主键命名不想遵循 EF Core 的约定，可以在此处使用 modelBuilder 手动定义两个关联实体的一对多关联关系
        // modelBuilder.Entity<StudentCourse>()
        //     .HasOne<Student>(sc => sc.Student)
        //     .WithMany(student => student.StudentCourses)
        //     .HasForeignKey(sc => sc.StudentId);
        //
        // modelBuilder.Entity<StudentCourse>()
        //     .HasOne<Course>(sc => sc.Course)
        //     .WithMany(c => c.StudentCourses)
        //     .HasForeignKey(sc => sc.CourseId);
    }
}