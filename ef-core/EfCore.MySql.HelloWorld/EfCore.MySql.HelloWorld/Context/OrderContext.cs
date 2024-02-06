using EfCore.MySql.HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfCore.MySql.HelloWorld.Context;

/// <summary>
/// 数据库上下文
/// </summary>
public class OrderContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    /// <summary>
    /// 配置数据库连接
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connStr = "server=localhost;port=13306;user=root;password=123456;database=learn_ef_core";
        optionsBuilder.UseMySQL(connStr)
            .LogTo(Console.WriteLine, LogLevel.Information);
    }
}