using Microsoft.EntityFrameworkCore;
using Wpf.Integration.EfCore.Models;

namespace Wpf.Integration.EfCore.Context;

///  <summary>
/// 数据库上下文
/// </summary>
public class ProductContext : DbContext
{
    /// <summary>
    /// 产品实体集合
    /// DbSet 属性告诉 EF 哪些实体需要映射到数据库
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// 产品类别实体集合
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>
    /// 数据库连接配置
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connStr = @"Server=(localdb)\mssqllocaldb;Database=ProductDb;Trusted_Connection=True;";
        // UseLazyLoadingProxies() 方法启用延迟加载代理
        // 当父实体访问子实体时，EF 会自动加载子实体
        optionsBuilder.UseSqlServer(connStr).UseLazyLoadingProxies().LogTo(Console.WriteLine);
    }
}