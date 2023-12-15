using Microsoft.EntityFrameworkCore;

namespace EFCoreFluentApiOnToManyConfig;

/// <summary>
/// 数据上下午
/// </summary>
public class OnToManyConfigContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Grade> Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=OnToManyConfig;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connStr);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            // 配置学生与年级的关联关系：一个年级下可以有多个学生
            .HasOne<Grade>(s => s.Grade)
            .WithMany(g => g.Students)
            // 指定外键属性
            .HasForeignKey(s => s.CurrentGradeId)
            // 配置级联删除操作：当删除一个年级实体时，如果它关联一个或多个学生实体，那么这些学生实体也会被删除
            // OnDelete() 接收一个类型为 DeleteBehavior 的枚举，该枚举有以下值：
            // 1.Cascade：级联删除，在删除实体时，同时删除关联了该实体的实体。如上述说明
            // 2.ClientSetNull：在客户端将关联了被删除实体的实体的外键设为 null，即程序中
            // 3.Restrict：阻止级联删除
            // 4.SetNull：在数据库服务端将关联了被删除实体对应表的表的外键设为 null
            .OnDelete(DeleteBehavior.Cascade);

        // 还可以通过年级实体来配置关联关系
        // modelBuilder.Entity<Grade>()
        //     .HasMany<Student>(g => g.Students)
        //     .WithOne(s => s.Grade)
        //     .HasForeignKey(s => s.CurrentGradeId);
    }
}