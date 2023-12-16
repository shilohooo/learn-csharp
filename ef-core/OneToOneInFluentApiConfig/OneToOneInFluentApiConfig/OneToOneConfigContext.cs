using Microsoft.EntityFrameworkCore;

namespace OneToOneInFluentApiConfig;

/// <summary>
/// 数据上下文
/// </summary>
public class OneToOneConfigContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentAddress> StudentAddresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=OneToOneConfig;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connStr);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 配置实体之间的一对一关联关系
        modelBuilder.Entity<Student>()
            // 一个学生只能有一个地址
            .HasOne<StudentAddress>(s => s.StudentAddress)
            // 一个地址只能属于一个学生
            .WithOne(a => a.Student)
            // 外键交给学生地址实体管理
            .HasForeignKey<StudentAddress>(a => a.AddressOfStudentId);
        // 也可以通过配置学生地址实体来指定一对一关联关系
        // modelBuilder.Entity<StudentAddress>()
        //     .HasOne<Student>(a => a.Student)
        //     .WithOne(s => s.StudentAddress)
        //     .HasForeignKey<StudentAddress>(a => a.AddressOfStudentId);
    }
}