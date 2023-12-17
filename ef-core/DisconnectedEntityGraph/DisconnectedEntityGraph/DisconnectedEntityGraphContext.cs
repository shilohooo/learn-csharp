using Microsoft.EntityFrameworkCore;

namespace DisconnectedEntityGraph;

/// <summary>
/// 数据上下文
/// </summary>
public class DisconnectedEntityGraphContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connStr = @"Server=(localdb)\MSSQLLocalDB;Database=DisconnectedEntityGraph;Trusted_Connection=True;";
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
        
        // 配置实体之间的一对一关联关系
        modelBuilder.Entity<Student>()
            // 一个学生只能有一个地址
            .HasOne<StudentAddress>(s => s.StudentAddress)
            // 一个地址只能属于一个学生
            .WithOne(a => a.Student)
            // 外键交给学生地址实体管理
            .HasForeignKey<StudentAddress>(a => a.AddressOfStudentId);
    }
}