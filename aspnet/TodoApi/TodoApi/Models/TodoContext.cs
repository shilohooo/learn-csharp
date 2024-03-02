using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

/// <summary>
/// 数据上下文
/// </summary>
public class TodoContext(DbContextOptions options) : DbContext(options)
{
    /// <summary>
    /// 实体集
    /// </summary>
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}