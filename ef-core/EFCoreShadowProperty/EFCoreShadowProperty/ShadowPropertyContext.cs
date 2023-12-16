using Microsoft.EntityFrameworkCore;

namespace EFCoreShadowProperty;

/// <summary>
/// 数据上下文
/// </summary>
public class ShadowPropertyContext : DbContext
{
    /// <summary>
    /// 阴影属性：创建时间
    /// </summary>
    public const string CreatedTime = "CreatedTime";

    /// <summary>
    /// 阴影属性：更新时间
    /// </summary>
    public const string UpdatedTime = "UpdatedTime";

    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connStr = @"Server=(localdb)\MSSQLLocalDB;Database=ShadowPropertyDb;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connStr);
    }

    /// <summary>
    /// 给学生实体配置阴影属性
    /// 这里通过 Property() 方法的泛型指定阴影属性的数据类型，通过方法参数指定阴影属性名称。
    /// 假设指定的阴影属性名称与实体中已存在的属性名称一致，EF Core 不会再创建一个阴影属性，
    /// 而是直接将实体中的同名属性当作阴影属性。
    /// 配置好之后，生成数据库迁移并更新数据库，就可以在学生表中看到这两个字段了。
    /// </summary>
    /// <param name="modelBuilder">实体模型 builder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().Property<DateTime>(CreatedTime);
        modelBuilder.Entity<Student>().Property<DateTime>(UpdatedTime);
        // 也可以使用下面这种方式为所有实体配置通用的阴影属性
        // var entityTypes = modelBuilder.Model.GetEntityTypes();
        // foreach (var entityType in entityTypes)
        // {
        //     entityType.AddProperty(CreatedTime, typeof(DateTime));
        //     entityType.AddProperty(UpdatedTime, typeof(DateTime));
        // }
    }

    /// <summary>
    /// 重写父类逻辑，自动给实体添加创建时间和更新时间
    /// </summary>
    /// <returns>受影响的行数</returns>
    public override int SaveChanges()
    {
        // 从 ChangeTracker 中获取所有处于 "Added" 和 "Modified" 状态的实体
        var entityEntries = ChangeTracker.Entries()
            .Where(entry => entry.State is EntityState.Added or EntityState.Modified);
        // 遍历设置创建时间和更新时间
        foreach (var entityEntry in entityEntries)
        {
            var now = DateTime.Now;
            entityEntry.Property(UpdatedTime).CurrentValue = now;
            // 如果实体状态为 "Added"，则设置创建时间
            if (entityEntry.State is EntityState.Added)
            {
                entityEntry.Property(CreatedTime).CurrentValue = now;
            }
        }

        return base.SaveChanges();
    }
}